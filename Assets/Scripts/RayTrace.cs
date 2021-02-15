using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTrace : MonoBehaviour
{
	[SerializeField]
	private GameObject screen;
	private GameObject player;

	private float _deltaX;
	private float _deltaZ;
	private float _cornerX;
	private float _cornerY;
	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Player1");
		_deltaX = screen.transform.lossyScale.x * 10 / 1280;
		_deltaZ = screen.transform.lossyScale.z * 10 / 1080;
		_cornerX = screen.transform.position.x - screen.transform.lossyScale.x * 5;
		_cornerY = screen.transform.position.z - screen.transform.lossyScale.z * 5;
	}

	private Ray Init_Ray(int x, int z)
	{
		Vector3 _pxlPos = screen.transform.position;
		_pxlPos.x = _cornerX + (_deltaX * x);
		_pxlPos.z = _cornerY + (_deltaZ * z);
		//Debug.DrawRay(player.transform.position, _rayDir);
		Ray _ray = new Ray(player.transform.position, _pxlPos - player.transform.position);

		return _ray;
	}

	// Update is called once per frame
	void Update()
	{
		for (int x = 0; x < 1280; x++)
		{
			for (int z = 0; z < 1080; z++)
			{
				Ray _ray = Init_Ray(x, z);
			}
		}
	}
}
