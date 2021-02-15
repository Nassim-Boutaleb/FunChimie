using UnityEngine;

namespace CRI.ConnectedGymnasium.MusicalChair
{
	public class PlayerPos_MusicalChair : MonoBehaviour
	{
		public bool safe = false;
		public bool alive = true;

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.tag == "Chair" && ChairManager.Instance.music == false && ChairManager.Instance._newRound == false)
				ClaimChair(collision);
		}

		private void ClaimChair(Collision collision)
		{
			if (collision.gameObject.GetComponent<Chair>().chairTaken == false && safe == false)
			{
				collision.gameObject.GetComponent<MeshRenderer>().material = this.GetComponent<MeshRenderer>().material;
				collision.gameObject.GetComponent<Chair>().chairTaken = true;
				safe = true;
				ChairManager.Instance.nbChairTaken++;
			}
		}
	}
}
