using System;
using UnityEngine;
using DG.Tweening;

public class CubeController : MonoBehaviour
{
	
	Vector3 pos = Vector3.zero;
	private bool _isCanRotate;
	public static event Action  OnCubeAnimated;

	private void OnEnable()
	{
		BallJump.OnCanRotateCube += OnCanRotateCube;
	}
	
	private void OnDisable()
	{
		BallJump.OnCanRotateCube -= OnCanRotateCube;
	}

	private void OnCanRotateCube()
	{
		_isCanRotate = true;
	}


	// Update is called once per frame
	void Update ()
	{

		if (_isCanRotate)
		{
			if (Input.GetKeyDown("right"))
			{
				pos = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + -90f);
			}

			if (Input.GetKeyDown("left"))
			{
				pos = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90f);
			}

			if (Input.GetKeyDown("up"))
			{
				pos = new Vector3(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z);
			}

			if (Input.GetKeyDown("down"))
			{
				pos = new Vector3(transform.eulerAngles.x - 90, transform.eulerAngles.y, transform.eulerAngles.z);
			}

			if (pos != Vector3.zero)
			{
				_isCanRotate = false;
				transform.DORotate(pos, 0.1f)
					.OnComplete(() =>
				{
					GameEvents.Send(OnCubeAnimated);
				});
				pos = Vector3.zero;
			}
		}
	}
}