using UnityEngine;
using CRI.HitBoxTemplate.ScoreManager;

public class BallMovement : MonoBehaviour
{
	[SerializeField]
	private float init_speed = 0.02f;
	[SerializeField]
	private float _speed_inc = 0.01f;
	[SerializeField]
	private float _speed;
	private Vector3 _direction = Vector3.left;
	private float timer = 0f;

	//Death variables
	[SerializeField]
	private DeathParticles deathParticles;

	// Start is called before the first frame update
	void Awake()
	{
		_speed = 0;
		_direction = RotatePointAroundAxis(_direction, Random.Range(-45, 46), Vector3.up);
		if (Random.Range(0, 2) == 0)
			_direction = -_direction;
	}

	void New_Ball()
	{
		deathParticles.PlayDeathParticles(this.transform.position);
		this.transform.position = Vector3.zero;
		this.GetComponent<Rigidbody>().velocity = Vector3.zero;

		_speed = 0;
		timer = 0;
		_direction = RotatePointAroundAxis(_direction, Random.Range(-45, 46), Vector3.up);
	}

	private void Collision_PlayerBar(Collision collision)
	{
		Vector3 contactPoint = collision.GetContact(0).point;
		float angle = (contactPoint.z - collision.transform.position.z) * 18; // calculating the angle to bounce the ball back

		if (collision.gameObject.name == "Mass1")
		{
			if (contactPoint.x > collision.transform.position.x) // ignoring collision if PlayerBar is in front of the ball
				return;
			_direction = RotatePointAroundAxis(Vector3.left, angle, Vector3.up).normalized;
		}
		else
		{
			if (contactPoint.x < collision.transform.position.x) // ignoring collision if PlayerBar is in front of the ball
				return;
			_direction = RotatePointAroundAxis(Vector3.right, angle, Vector3.down).normalized;
		}
		this.GetComponent<Rigidbody>().velocity = Vector3.zero;
		_speed += _speed_inc;
	}

	private void Collision_Wall(Collision collision)
	{
		if (collision.gameObject.name == "Upper")
			_direction = Vector3.Reflect(_direction, Vector3.back).normalized;
		else if (collision.gameObject.name == "Lower")
			_direction = Vector3.Reflect(_direction, Vector3.forward).normalized;
	}

	void Score(Collision collision)
	{
		if (collision.gameObject.name == "Blue Team (1)")
		{
			_direction = Vector3.left;
			ScoreManager.Instance.redScore++;
			Debug.Log("Red Team Scores");
			New_Ball();
		}
		else if (collision.gameObject.name == "Red Team (2)")
		{
			_direction = Vector3.right;
			ScoreManager.Instance.blueScore++;
			Debug.Log("Blue Team Scores");
			New_Ball();
		}
	}

	private void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.tag == "PlayerBar")
		{
			AudioManager.instance.Play("hit");
			Collision_PlayerBar(collision);
		}
		else if (collision.gameObject.tag == "Wall")
		{
			AudioManager.instance.Play("hit");
			Collision_Wall(collision);
		}

		else if (collision.gameObject.tag == "Goal")
		{
			AudioManager.instance.Play("death");
			Score(collision);
		}
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (timer < 2f)
			timer += Time.deltaTime;
		else if (timer < 5f)
		{
			_speed = init_speed;
			timer = 5f;
		}
		else
			this.GetComponent<Rigidbody>().MovePosition(this.transform.position + ((_direction * _speed) * Time.fixedDeltaTime));
	}

	private Vector3 RotatePointAroundAxis(Vector3 point, float angle, Vector3 axis)
	{
		Quaternion q = Quaternion.AngleAxis(angle, axis);
		return q * point;
	}
}
