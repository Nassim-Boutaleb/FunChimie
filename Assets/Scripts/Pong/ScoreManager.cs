using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRI.HitBoxTemplate.ScoreManager
{
	public class ScoreManager : MonoBehaviour
	{
		private static ScoreManager _instance;
		public static ScoreManager Instance
		{
			get
			{
				if (_instance == null)
					Debug.LogError("ScoreManager is null.");

				return (_instance);
			}
		}

		private void Awake()
		{
			_instance = this;
		}

		public int blueScore = 0;
		public int redScore = 0;

		void ResetScore()
		{
			blueScore = 0;
			redScore = 0;
		}

		// Start is called before the first frame update
		void Start()
		{
        
		}

		// Update is called once per frame
		void Update()
		{
        
		}
	}
}
