using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CRI.ConnectedGymnasium
{
	public class PlayerManager : MonoBehaviour
	{
		public bool _checkTrackers = true;
		public GameObject[] _trackers { get; private set; }
		public GameObject[] _players { get; private set; }
		public int nbPlayer { get; private set; } = 0;

		//Getting a list of all trackers and a list of all players
		void Awake()
		{
			Debug.Log("Start");
			GameObject[] _trackerstmp = GameObject.FindGameObjectsWithTag("Tracker");
			_trackers = SortArrayKey(_trackerstmp, "Tracker");
			Debug.Log(_trackers[0]);
			GameObject[] _playerstmp = GameObject.FindGameObjectsWithTag("Player");
			_players = SortArrayKey(_playerstmp, "Player");
			Debug.Log(_players[0]);
			Init_Players();
		}

		GameObject[] SortArrayKey(GameObject[] _oldArray, string key)
		{
			GameObject[] _newArray = new GameObject[_oldArray.Length];
			for(int i = 0; i < _oldArray.Length; i++)
			{
				for (int j = 0; j < _oldArray.Length; j++)
				{
					if (_oldArray[j].name == key + (i + 1))
					{
						_newArray[i] = _oldArray[j];
						break;
					}
				}
			}
			return _newArray;
		}

		// Setting every player as inactive
		void Init_Players()
		{
			foreach (var player in _players)
			{
				player.SetActive(false);
			}
		}

		public void Reset_Players()
		{
			foreach (var player in _players)
			{
				if (player.activeSelf == true)
				{
					player.transform.SetParent(this.transform);
					player.transform.localPosition = Vector3.zero;
					nbPlayer--;
					player.SetActive(false);
				}
			}
			foreach (var tracker in _trackers)
			{
				tracker.GetComponent<ActiveTracker>().active = false;
			}

		}

		void Update()
		{
			if (_checkTrackers)
				CheckForActiveTrackers();
		}

		// Checking every tracker for activity and linking it to a player if it is active
		void CheckForActiveTrackers()
		{
			foreach (var tracker in _trackers)
			{
				if (tracker.GetComponent<ActiveTracker>().toActivate == true && tracker.GetComponent<ActiveTracker>().active == false)
				{
					foreach (var player in _players)
					{
						if (player.activeSelf == false)
						{
							player.SetActive(true);
							player.transform.SetParent(tracker.transform);
							player.transform.localPosition = Vector3.zero;
							tracker.GetComponent<ActiveTracker>().active = true;
							nbPlayer++;
							Debug.Log(player.name + " is paired with " + tracker.name);
							break;
						}
					}
				}
			}
		}
	}
}