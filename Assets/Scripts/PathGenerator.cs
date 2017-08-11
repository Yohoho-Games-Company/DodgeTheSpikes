using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
	[SerializeField] private GameObject _cube;
	public List<GameObject> cubes;

	private float cubex, cubey, cubez = 0.0f;
	
	
	// Use this for initialization
	void Start ()
	{
		while (cubes.Count < 5)
		{
			AddOnePoint();
		}
		cubes[1].GetComponent<CubeController>().enabled = true;
	}

	private void AddOnePoint()
	{
		GameObject go = Instantiate(_cube, new Vector3(cubex, cubey, cubez), Quaternion.identity);
		cubes.Add(go);
		cubex += Random.Range(-1.5f, 1.5f);
		cubez += 5;
	}

	public Vector3 GetNextPointAndRemove()
	{
		cubes[1].GetComponent<CubeController>().enabled = false;
		cubes[2].GetComponent<CubeController>().enabled = true;
		Vector3 pos = cubes[1].transform.position;
		Destroy(cubes[0]);
		cubes.RemoveAt(0);
		AddOnePoint();
		return pos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
