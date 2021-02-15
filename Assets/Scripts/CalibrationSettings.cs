using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CRI.ConnectedGymnasium
{
	public class CalibrationSettings : MonoBehaviour
	{
		[SerializeField]
		private bool _resetSavedCalibration = false;

		// Flush saved calibration
		private void Update()
		{
			if (_resetSavedCalibration)
			{
				PlayerPrefs.DeleteAll();
				_resetSavedCalibration = false;
			}
		}

		// Load previous calibration on Players awake
		private void Awake()
		{
			LoadRotation();
			LoadScale();
			LoadOffset();
		}

		// Loading saved rotation
		private void LoadRotation()
		{
			if (!PlayerPrefs.HasKey("RotationPlayerX"))
			{
				PlayerPrefs.SetFloat("RotationPlayerW", this.transform.localRotation.w);
				PlayerPrefs.SetFloat("RotationPlayerX", this.transform.localRotation.x);
				PlayerPrefs.SetFloat("RotationPlayerY", this.transform.localRotation.y);
				PlayerPrefs.SetFloat("RotationPlayerZ", this.transform.localRotation.z);

				PlayerPrefs.Save();
			}
			else
			{
				Quaternion rotation;

				rotation.w = PlayerPrefs.GetFloat("RotationPlayerW");
				rotation.x = PlayerPrefs.GetFloat("RotationPlayerX");
				rotation.y = PlayerPrefs.GetFloat("RotationPlayerY");
				rotation.z = PlayerPrefs.GetFloat("RotationPlayerZ");

				this.transform.localRotation = rotation;
			}
		}

		// Loading saved scale
		private void LoadScale()
		{
			if (!PlayerPrefs.HasKey("ScalePlayerX"))
			{
				PlayerPrefs.SetFloat("ScalePlayerX", this.transform.localScale.x);
				PlayerPrefs.SetFloat("ScalePlayerY", this.transform.localScale.y);
				PlayerPrefs.SetFloat("ScalePlayerZ", this.transform.localScale.z);

				PlayerPrefs.Save();
			}
			else
			{
				Vector3 scale;

				scale.x = PlayerPrefs.GetFloat("ScalePlayerX");
				scale.y = PlayerPrefs.GetFloat("ScalePlayerY");
				scale.z = PlayerPrefs.GetFloat("ScalePlayerZ");

				this.transform.localScale = scale;
			}
		}

		// Loading saved offset
		private void LoadOffset()
		{
			if (!PlayerPrefs.HasKey("OffsetPlayerX"))
			{
				PlayerPrefs.SetFloat("OffsetPlayerX", this.transform.localPosition.x);
				PlayerPrefs.SetFloat("OffsetPlayerY", this.transform.localPosition.y);
				PlayerPrefs.SetFloat("OffsetPlayerZ", this.transform.localPosition.z);

				PlayerPrefs.Save();
			}
			else
			{
				Vector3 pos;

				pos.x = PlayerPrefs.GetFloat("OffsetPlayerX");
				pos.y = PlayerPrefs.GetFloat("OffsetPlayerY");
				pos.z = PlayerPrefs.GetFloat("OffsetPlayerZ");

				this.transform.localPosition = pos;
			}
		}

		// Saving current Calibration
		public void SaveSettings()
		{
			PlayerPrefs.SetFloat("RotationPlayerW", this.transform.localRotation.w);
			PlayerPrefs.SetFloat("RotationPlayerX", this.transform.localRotation.x);
			PlayerPrefs.SetFloat("RotationPlayerY", this.transform.localRotation.y);
			PlayerPrefs.SetFloat("RotationPlayerZ", this.transform.localRotation.z);

			PlayerPrefs.SetFloat("ScalePlayerX", this.transform.localScale.x);
			PlayerPrefs.SetFloat("ScalePlayerY", this.transform.localScale.y);
			PlayerPrefs.SetFloat("ScalePlayerZ", this.transform.localScale.z);

			PlayerPrefs.SetFloat("OffsetPlayerX", this.transform.localPosition.x);
			PlayerPrefs.SetFloat("OffsetPlayerY", this.transform.localPosition.y);
			PlayerPrefs.SetFloat("OffsetPlayerZ", this.transform.localPosition.z);

			PlayerPrefs.Save();
		}
	}
}
