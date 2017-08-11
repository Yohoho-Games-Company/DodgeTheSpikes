using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{

	public GameObject Obj;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Obj.GetComponent<Transform>().position.x, transform.position.y, Obj.GetComponent<Transform>().position.z - 3.2f);
	}
}
