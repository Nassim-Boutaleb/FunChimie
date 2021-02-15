using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_Probe : MonoBehaviour
{
	public float av_temp = 0.0f;
	public List<GameObject> part_list;

	private void OnTriggerEnter(Collider other)
	{
		part_list.Add(other.gameObject);
	}

	private void OnTriggerExit(Collider other)
	{
		part_list.Remove(other.gameObject);
	}

	private void Update()
	{
		float tmp = 0.0f;
		foreach(var part in part_list)
		{
			tmp += part.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
		}
		av_temp = tmp / part_list.Count;
	}
}
