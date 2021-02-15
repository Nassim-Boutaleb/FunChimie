using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRI.ConnectedGymnasium.MusicalChair
{
	public class ChairManager : MonoBehaviour
	{
		private static ChairManager _instance;
		public static ChairManager Instance
		{
			get
			{
				if (_instance == null)
					Debug.LogError("Chair Manager is NULL.");
				return (_instance);
			}
		}

		private GameObject[] _players; // active players
		public int nbPlayers; // number of players still alive in the game

		[SerializeField]
		private GameObject mainStage; // The big-ass red circle
		[SerializeField]
		AudioSource musicSource;

		// Materials for the MainStage color changes
		[SerializeField]
		private Material black;
		[SerializeField]
		private Material red;

		private float _musicTime; // how long to play the music for before stopping
		private float _waited = 0; // how long the music has played
		public bool music = true; // is the music playing
		public int nbChairTaken = 0; // nb of chairs claimed by players

		[SerializeField]
		private GameObject chairPrefab;
		[SerializeField]
		private GameObject chairParent;
		private List<GameObject> chairList = new List<GameObject>();
		public bool _newRound { get; private set; } = true;

		private void Awake()
		{
			_instance = this;
			_players = GameObject.FindGameObjectsWithTag("Player");
			nbPlayers = _players.Length;
			NextRound();
			musicSource.Pause();
		}

		// Setting the stage for the next round
		private void SetStage()
		{
			foreach (var chair in chairList)
			{
				Destroy(chair);
			}
			chairList.Clear();
			for (int i = 0; i < nbPlayers - 1; i++)
			{
				GameObject chair = Instantiate(chairPrefab, chairParent.transform);
				if (nbPlayers > 2)
					chair.transform.position = RotatePointAroundAxis(chair.transform.position, i * (360 / (nbPlayers - 1)), Vector3.up);
				else
					chair.transform.position = Vector3.zero;
				chairList.Add(chair);
			}
			mainStage.GetComponent<MeshRenderer>().material = red;
		}

		private void NextRound()
		{
			SetStage();
			_musicTime = Random.Range(5f, 15f);
			_waited = 0;
			nbChairTaken = 0;
			foreach(var player in _players)
				player.GetComponent<PlayerPos_MusicalChair>().safe = false;
			_newRound = true;
		}

		private void NewGame()
		{
			foreach (var player in _players)
			{
				PlayerPos_MusicalChair playerScript = player.GetComponent<PlayerPos_MusicalChair>();
				playerScript.alive = true;
				player.GetComponent<MeshRenderer>().enabled = true;
			}
			nbPlayers = _players.Length;
			NextRound();
		}

		// Update is called once per frame
		void Update()
		{
			if (_newRound) // waiting for player to get out of the red circle before starting round
			{
				foreach (var player in _players)
					if (Vector3.Magnitude(player.transform.position - mainStage.transform.position) < 20f)
						return;
				_newRound = false;
				musicSource.UnPause();
				music = true;
			}
			if (_waited < _musicTime && music) // waiting for the music to cut
			{
				_waited += Time.deltaTime;
				if (chairList.Count > 0)
					foreach (var chair in chairList)
						chair.transform.position = RotatePointAroundAxis(chair.transform.position, 1, Vector3.up);
			}
			else if (music) // wait is over
			{
				musicSource.Pause();
				music = false;
				mainStage.GetComponent<MeshRenderer>().material = black;
			}
			else if (nbChairTaken == nbPlayers - 1) // Every chair has been taken
			{
				foreach (var player in _players)
				{
					PlayerPos_MusicalChair playerScript = player.GetComponent<PlayerPos_MusicalChair>();
					if (playerScript.alive == true && playerScript.safe == false)
					{
						playerScript.alive = false;
						player.GetComponent<MeshRenderer>().enabled = false;
						nbPlayers--;
					}
				}
				if (nbPlayers != 1)
					NextRound();
			}
			else if (nbPlayers == 1) // Gameover
			{
				NewGame();
			}
		}

		private Vector3 RotatePointAroundAxis(Vector3 point, float angle, Vector3 axis)
		{
			Quaternion q = Quaternion.AngleAxis(angle, axis);
			return q * point;
		}
	}
}
