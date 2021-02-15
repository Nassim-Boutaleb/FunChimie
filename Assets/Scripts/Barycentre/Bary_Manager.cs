using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CRI.HitBoxTemplate.Example
{
	public class Bary_Manager : MonoBehaviour
	{
		private static Bary_Manager _instance;
		public static Bary_Manager Instance
		{
			get
			{
				if (_instance == null)
					Debug.LogError("Bary Manager is NULL.");
				return (_instance);
			}
		}

		private void Awake()
		{
			_instance = this;
		}

		[SerializeField] private GameObject uiScore;
		[SerializeField] private GameObject uiTimer;

		private float _time = 0;
		private int _lastTimeSent = -1;
		public int score = 0;
		private int _lastScoreSent = -1;
		private bool _timerOn = true;


		private void Timer()
		{
			if (_timerOn)
			{
				_time += Time.deltaTime;
				if (_time >= _lastTimeSent + 1)
				{
					_lastTimeSent = (int)_time;
					uiTimer.GetComponent<Text>().text = "Timer : " + _lastTimeSent.ToString();
				}
			}
		}

		private void Score()
		{
			if (score != _lastScoreSent)
			{
				_lastScoreSent = score;
				uiScore.GetComponent<Text>().text = "Score : " + _lastScoreSent.ToString();
				if (score == 40)
					_timerOn = false;
			}
		}

		// Update is called once per frame
		void Update()
		{
			Timer();
			Score();
		}
	}
}
