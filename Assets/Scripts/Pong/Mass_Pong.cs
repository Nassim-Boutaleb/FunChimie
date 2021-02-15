using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRI.HitBoxTemplate.Example
{
	public class Mass_Pong : MonoBehaviour
	{
		private Vector3 posGlob = Vector3.zero;
		private float totalMass;
		private Rigidbody rb;

		private void Start()
		{
			rb = this.GetComponent<Rigidbody>();
		}

		public void AddPosMass(Vector3 pos, float mass)
		{
			posGlob += (pos * mass);
			totalMass += mass;
		}

		void Update()
		{
			if (totalMass > 0)
				rb.MovePosition(posGlob / totalMass);
			totalMass = 0;
			posGlob = Vector3.zero;
		}
	}
}
