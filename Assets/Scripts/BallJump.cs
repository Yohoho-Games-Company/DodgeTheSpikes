using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallJump : MonoBehaviour
{
	public static event Action  OnCanRotateCube;

	private float _posX, _posY, _posZ;
	private float _timer;
	
	private float _velocity;
	private Vector3 _ballpos;
	private Vector3 _nextpos;
	
	public GameObject CubesGenerator;
	
	private bool _isCanJump;
	private bool _isFirstJump;
	private bool _isBounced;

	void Start ()
	{
		_isFirstJump = true;
		_posX = 0;
		_posY = 0.8f;
		_posZ = 0;
		_ballpos = new Vector3(_posX, _posY, _posZ);
		transform.position = _ballpos;
	}

	private void OnEnable()
	{
		CubeController.OnCubeAnimated += OnCubeAnimated;
	}

	private void OnCubeAnimated()
	{
		_isCanJump = true;
	}

	void Update ()
	{
		_timer += Time.deltaTime;
		
		if (_isCanJump || _timer >= 2f)
		{
			Jump();
		}
	}

	void Jump()
	{
		_nextpos = CubesGenerator.GetComponent<PathGenerator>().GetNextPosition();
		CubesGenerator.GetComponent<PathGenerator>().PathCubes[1].GetComponent<CubeController>().enabled = true;
		GameEvents.Send(OnCanRotateCube);
		transform.DOJump(_nextpos + new Vector3(0f, 3f, 0f), 1f, 1, 0.5f).OnComplete(JumpDown);
		_isCanJump = false;
		transform.DOMove(_nextpos + new Vector3(0f, 0.8f, 0f), 0.1f).OnComplete(JumpUp);
		CubesGenerator.GetComponent<PathGenerator>().RemovePastPointAndAddNewOne();
		
	}

	void FirstJump()
	{
		_isFirstJump = false;
		JumpUp();
	}

	public void JumpDown()
	{
		_isCanJump = false;
		_timer = 0f;
		transform.DOMove(_nextpos + new Vector3(0f, 0.8f, 0f), 0.1f).OnComplete(JumpUp);
		CubesGenerator.GetComponent<PathGenerator>().RemovePastPointAndAddNewOne();
	}

	void JumpUp()
	{
		CubesGenerator.GetComponent<PathGenerator>().PathCubes[1].GetComponent<CubeController>().enabled = true;
		_nextpos = CubesGenerator.GetComponent<PathGenerator>().GetNextPosition();
		GameEvents.Send(OnCanRotateCube);
		transform.DOJump(_nextpos + new Vector3(0f, 3f, 0f), 1f, 1, 0.5f).OnComplete(JumpDown);
		_timer = 0f;
	}

	public void GameOver()
	{
		SceneManager.LoadScene(0);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Spikes"))
		{
			GameOver();
		}
	}
}
