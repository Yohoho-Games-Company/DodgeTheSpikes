using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BallJump : MonoBehaviour
{

	private float _posX, _posY, _posZ;
	private Vector3 _ballpos;
	
	public GameObject CubesGenerator;

	void Start ()
	{
		_posX = 0;
		_posY = 0.8f;
		_posZ = 0;
		_ballpos = new Vector3(_posX, _posY, _posZ);
		transform.position = _ballpos;
	}
	
	void Update ()
	{
		if (Input.GetKeyDown("space"))
		{
			Jump();
		}
	}

	void Jump()
	{
		Vector3 pos = CubesGenerator.GetComponent<PathGenerator>().GetNextPointAndRemove() + new Vector3(0, _posY, 0);
		transform.DOMove(pos, 1f);	
	}
}
