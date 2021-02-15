using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CRI.ConnectedGymnasium
{
	public class Heater : MonoBehaviour
	{
		[SerializeField]
		private float power = 100;
		// Start is called before the first frame update
		void Start()
		{

		}

		private void OnCollisionEnter(Collision collision)
		{
			Rigidbody rb;
			rb = collision.collider.gameObject.GetComponent<Rigidbody>();
			Vector3 v = (collision.GetContact(0).point - this.transform.position).normalized;
			rb.AddForce(v * power);
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}