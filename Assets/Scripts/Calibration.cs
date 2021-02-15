using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CRI.ConnectedGymnasium
{
	public class Calibration : MonoBehaviour
	{
		[SerializeField] private GameObject CenterCalibration;
		[SerializeField] private GameObject UpperCalibration;
		private GameObject tracker1;
		private GameObject tracker2;
		private GameObject players;
		private GameObject playerManager;

		private void Awake()
		{
			players = GameObject.Find("Players");
			tracker1 = GameObject.Find("Player1");
			tracker2 = GameObject.Find("Player2");
			playerManager = GameObject.Find("PlayerManager");

		}

		private void ResetCalibration()
		{
			players.transform.position = Vector3.zero;
			players.transform.localScale = Vector3.one;
			players.transform.localRotation = Quaternion.Euler(Vector3.zero);
		}

		public void Calibrate()
		{
			// resetting a potential previous calibration
			ResetCalibration();

			Vector3 rotation = Vector3.zero;
			rotation.y = Vector3.SignedAngle((tracker2.transform.position - tracker1.transform.position).normalized, (UpperCalibration.transform.position - CenterCalibration.transform.position).normalized, Vector3.up);
			players.transform.rotation = Quaternion.Euler(rotation);
			Debug.Log(rotation);

			Vector3 scale = Vector3.zero;
			scale.x = (UpperCalibration.transform.position - CenterCalibration.transform.position).magnitude / (tracker2.transform.position - tracker1.transform.position).magnitude;
			scale.y = 1;
			scale.z = scale.x;
			Debug.Log("scale " + scale);
			players.transform.localScale = scale;

			players.transform.position += CenterCalibration.transform.position - tracker1.transform.position;
			Debug.Log(players.transform.position);

			players.GetComponent<CalibrationSettings>().SaveSettings();

			this.gameObject.SetActive(false);

			playerManager.GetComponent<PlayerManager>().Reset_Players();
		}
	}
}
