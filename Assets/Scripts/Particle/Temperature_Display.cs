using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CRI.ConnectedGymnasium
{
	public class Temperature_Display : MonoBehaviour
	{
		[SerializeField] private Text scoreText;
		[SerializeField] private Text probeText;
		[SerializeField] private GameObject probe;

		// Update is called once per frame
		void Update()
		{
			scoreText.text = "Av temp in the room : " + Particle_Manager.Instance.averageSpeed.ToString();
			probeText.text = "Av temp in the probe : " + probe.GetComponent<Zone_Probe>().av_temp + "\n\nNb of part in probe : " + probe.GetComponent<Zone_Probe>().part_list.Count;

		}
	}
}