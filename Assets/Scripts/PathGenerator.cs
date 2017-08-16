using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
	public GameObject FirstCube;
	
	public List<GameObject> EasyCubes;
	public List<GameObject> MediumCubes;
	public List<GameObject> HardCubes;
	
	public List<GameObject> PathCubes;

	private float cubex, cubey, cubez = 0.0f;
	
	
	// Use this for initialization
	void Start ()
	{
		while (PathCubes.Count < 5)
		{
			if (PathCubes.Count == 0)
			{
				GameObject go = Instantiate(FirstCube, new Vector3(cubex, cubey, cubez), Quaternion.identity);
				PathCubes.Add(go);
				cubex += Random.Range(-1.5f, 1.5f);
				cubez += 5;
			}
			AddOnePoint();
		}
	}

	private void AddOnePoint()
	{
		GameObject go = Instantiate(EasyCubes[Random.Range(1, 5)], new Vector3(cubex, cubey, cubez), Quaternion.identity);
		PathCubes.Add(go);
		cubex += Random.Range(-1.5f, 1.5f);
		cubez += 5;
		if (PathCubes.Count > 5)
		{
			RemovePastPointAndAddNewOne();
		}
	}

	public Vector3 GetNextPosition()
	{
		Vector3 pos = PathCubes[1].transform.position;
		return pos;
	}

	public Vector3 GetNextPointAndRemove()
	{
		Vector3 pos = PathCubes[1].transform.position;
		AddOnePoint();
		return pos;
	}

	public void RemovePastPointAndAddNewOne()
	{
		Destroy(PathCubes[0]);
		PathCubes.RemoveAt(0);
		AddOnePoint();
	}
}
