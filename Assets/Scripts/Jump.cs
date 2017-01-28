using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float angularSpeedL = 100f;
	public float angularSpeedH = 200f;
	private Animator animator;

	private float speed = 6f;
	private Rigidbody rigidBody;
	private float currentRotation;
	private float previousRotation = 90f;
	private static float fullflips = 0;

	public enum State {
		IDLE, JUMP, WIND, UNWIND, INWATER
	};
	private static State state;

	// Use this for initialization
	void Start () {
		fullflips = 0;
		animator = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody> ();
		state = State.IDLE;
	}
	
	// Update is called once per frame
	void Update () {

		if (state == State.IDLE) {
			if (Input.GetMouseButton (0)) {
				Invoke ("jump", 0.5f);
				animator.SetTrigger ("jump");
			}
		} else if (state == State.JUMP) {
			if (Input.GetMouseButton (0)) {
				state = State.WIND;
				animator.SetTrigger ("wind");
			}
			rigidBody.angularVelocity = -Vector3.forward * angularSpeedL;
		} else if (state == State.WIND) {

			if (!Input.GetMouseButton (0)) {
				state = State.UNWIND;
				animator.SetTrigger ("unwind");
			}
			rigidBody.angularVelocity = -Vector3.forward * angularSpeedH;
		} else if (state == State.UNWIND) {
			if (Input.GetMouseButton (0)) {
				state = State.WIND;
				animator.SetTrigger ("wind");
			}
			rigidBody.angularVelocity = -Vector3.forward * angularSpeedL;
		}

		//For calculating full rotations of the object
		currentRotation = transform.eulerAngles.y;
		if (previousRotation == 90 && currentRotation == 270 || previousRotation == 270 && currentRotation == 90) {
			fullflips += 0.5f;
			Debug.Log (fullflips);
		}
		previousRotation = currentRotation;
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "pool") {
			state = State.INWATER;
			animator.SetTrigger ("unwind");
		}
	}

	public static float getFullFlips() {
		return fullflips;
	}

	void jump() { 
		rigidBody.velocity = (Vector3.right + Vector3.up) * speed;
		state = State.JUMP;
	}

	public static State getState() {
		return state;
	}
}
