using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CRI.HitBoxTemplate.Example;

namespace CRI.ConnectedGymnasium
{
	public class PlayerPos_Maze : MonoBehaviour
	{
		Mass_Maze _massPos;

		[SerializeField]
		[Tooltip("Mass of the player")]
		private float mass;

		private void Start()
		{
			_massPos = GameObject.Find("Mass1").GetComponent<Mass_Maze>();
		}

		// Update is called once per frame
		void Update()
		{
			if (_massPos)
				_massPos.AddPosMass(this.transform.position, mass);
		}
	}
}
