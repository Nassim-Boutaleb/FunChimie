using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRI.HitBoxTemplate.Example
{
	public class Bary_Target : MonoBehaviour
	{
		//Death variables
		[SerializeField]
		private DeathParticles deathParticles;

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.tag == "Mass")
			{
				AudioManager.instance.Play("death");
				deathParticles.PlayDeathParticles(this.transform.position);

				Bary_Manager.Instance.score++;
				this.gameObject.SetActive(false);
				Bary_TargetManager.Instance.nbTargetDown++;
			}
		}
	}
}
