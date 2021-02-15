using UnityEngine;
using CRI.HitBoxTemplate.Example;
using CRI.ConnectedGymnasium.Pong;

namespace CRI.ConnectedGymnasium
{
	public class PlayerPos_Pong : MonoBehaviour
	{
		Mass_Pong _massPos;
		[SerializeField]
		[Tooltip("Team number")]
		public int _team = 0;

		[SerializeField]
		[Tooltip("Mass of the player")]
		private float mass;

		private void Awake()
		{
			if (_team != 0)
				_massPos = GameObject.Find("Mass" + _team).GetComponent<Mass_Pong>();
			else
				_massPos = null;
		}

		private void Team_Swap(Collider other)
		{
			if (other.gameObject.name == "Blue Team (1)" && _team != 1)
			{
				if (_team == 2)
					PongManager.Instance.nbPlayerRed--;
				_team = 1;
				_massPos = GameObject.Find("Mass" + _team).GetComponent<Mass_Pong>();
				this.GetComponent<MeshRenderer>().material = GameObject.Find("Mass" + _team).GetComponent<MeshRenderer>().material;
				PongManager.Instance.nbPlayerBlue++;
			}
			else if (other.gameObject.name == "Red Team (2)" && _team != 2)
			{
				if (_team == 1)
					PongManager.Instance.nbPlayerBlue--;
				_team = 2;
				_massPos = GameObject.Find("Mass" + _team).GetComponent<Mass_Pong>();
				this.GetComponent<MeshRenderer>().material = GameObject.Find("Mass" + _team).GetComponent<MeshRenderer>().material;
				this.GetComponent<BoxCollider>().isTrigger = true;
				PongManager.Instance.nbPlayerRed++;
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			Debug.Log("Touched Trigger");
			if (other.gameObject.tag == "Goal" && PongManager.Instance.gameStart == false)
				Team_Swap(other);
		}

		// Update is called once per frame
		void Update()
		{
			if (_massPos)
				_massPos.AddPosMass(this.transform.position, mass);
		}
	}
}