using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRI.HitBoxTemplate.Example
{
	public class Mass_Maze: MonoBehaviour
	{
		[SerializeField]
		private Material good;
		[SerializeField]
		private Material failed;
		private Vector3 posGlob = Vector3.zero;
		private float totalMass;
		private bool touched_wall = false;

		public void AddPosMass(Vector3 pos, float mass)
		{
			posGlob += (pos * mass);
			totalMass += mass;
		}

		private void OnCollisionEnter(Collision collision)
		{
			Debug.Log("Collision");
			if (collision.gameObject.tag == "Wall")
			{
				Debug.Log("You touched a wall, try again !");
				touched_wall = true;
				this.GetComponent<MeshRenderer>().material = failed;
			}
			else if (collision.gameObject.name == "Finish" && touched_wall == false)
				Debug.Log("Victory !");
			else if (collision.gameObject.name == "Start" && touched_wall == true)
			{
				Debug.Log("Reset");
				touched_wall = false;
				this.GetComponent<MeshRenderer>().material = good;
			}
		}

		void Update()
		{
			if (totalMass > 0)
				this.transform.position = posGlob / totalMass;
			totalMass = 0;
			posGlob = Vector3.zero;
		}
	}
}
