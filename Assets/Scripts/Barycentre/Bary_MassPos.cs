using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRI.HitBoxTemplate.Example
{
	public class Bary_MassPos : MonoBehaviour
	{
		private Vector3 posGlob = Vector3.zero;
		private float totalMass;

		public void AddPosMass(Vector3 pos, float mass)
		{
			posGlob += (pos * mass);
			totalMass += mass;
		}

		void Update()
		{
			if (totalMass > 0)
			{
				Vector3 newPos = posGlob / totalMass;
				newPos.y = 0;
				this.transform.position = newPos;
			}
			totalMass = 0;
			posGlob = Vector3.zero;
		}
	}
}
