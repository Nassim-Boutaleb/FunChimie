using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRI.HitBoxTemplate.Example
{
	public class Bary_TargetManager : MonoBehaviour
	{
		private static Bary_TargetManager _instance;
		public static Bary_TargetManager Instance
		{
			get
			{
				if (_instance == null)
					Debug.LogError("Target Manager is NULL.");
				return (_instance);
			}
		}


		private GameObject[] _targets; // active players
		public int nbTargetDown;

		// Start is called before the first frame update
		void Awake()
		{
			_instance = this;
			_targets = GameObject.FindGameObjectsWithTag("Target");
			nbTargetDown = 0;
		}

		public void ResetTargets()
		{
			foreach(var target in _targets)
			{
				target.SetActive(true);
			}
			nbTargetDown = 0;
		}

		private void Update()
		{
			if (nbTargetDown == _targets.Length)
				ResetTargets();
		}
	}
}