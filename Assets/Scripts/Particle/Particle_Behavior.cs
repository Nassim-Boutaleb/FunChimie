using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRI.ConnectedGymnasium
{
	public class Particle_Behavior : MonoBehaviour
	{
		private float temperature;
		private MeshRenderer rend;

		// Start is called before the first frame update
		void Start()
		{
			temperature = Particle_Manager.Instance.init_temp;
			Vector3 _v = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
			this.GetComponent<Rigidbody>().AddForce(_v * temperature / 2, ForceMode.VelocityChange);
			rend = this.GetComponent<MeshRenderer>();
			//Particle_placement();
		}

		//Replacing particle when it leaves the screen
		private void Particle_placement()
		{
			if (this.transform.position.z > 27)
				this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 27 * 2);
			else if (this.transform.position.z < -27)
				this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 27 * 2);

			if (this.transform.position.x > 31)
				this.transform.position = new Vector3(this.transform.position.x - 31 * 2, this.transform.position.y, this.transform.position.z);
			else if (this.transform.position.x < -31)
				this.transform.position = new Vector3(this.transform.position.x + 31 * 2, this.transform.position.y, this.transform.position.z);
		}

		//Changing color based on the velocity of the particle, materials are in the particle manager for easy access
		private void Color_Change()
		{
			int temp = (int)(this.GetComponent<Rigidbody>().velocity.magnitude);

			if (temp >= 0 && temp <= 12)
				rend.material = Particle_Manager.Instance.temp_mat[temp];
			else if (temp < 0)
				rend.material = Particle_Manager.Instance.temp_mat[0];
			else if (temp > 12)
				rend.material = Particle_Manager.Instance.temp_mat[12];
		}

		// Update is called once per frame
		void Update()
		{
			//Particle_placement();
			Color_Change();
		}
	}
}