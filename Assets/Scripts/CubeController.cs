using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeController : MonoBehaviour
{

	private float _desireAngle;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("right"))
		{
			transform.DORotate(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + -90f), 0.2f);
		}
		
		if (Input.GetKeyDown("left") && !DOTween.IsTweening(transform))
		{
			transform.DORotate(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90f), 0.2f);
		}
		
		if (Input.GetKeyDown("up") && !DOTween.IsTweening(transform))
		{
			transform.DORotate(new Vector3(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z), 0.2f);
		}
		
		if (Input.GetKeyDown("down") && !DOTween.IsTweening(transform))
		{
			transform.DORotate(new Vector3(transform.eulerAngles.x - 90, transform.eulerAngles.y, transform.eulerAngles.z), 0.2f);
		}
	}
}