using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float angularSpeedL = 100f;
	public float angularSpeedH = 200f;
	private Animator animator;

	private float speed = 8f;
	private Rigidbody rigidBody;
	private float currentRotation;
	private float previousRotation;
	private static float fullflips = 0;

	public enum State {
		IDLE, JUMP, WIND, UNWIND, INWATER
	};
	private static State state;

	// Use this for initialization
	void Start () {
		previousRotation = 90f;
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
				Invoke ("rotateFast", 0.3f);
			}
		} else if (state == State.WIND) {

			if (!Input.GetMouseButton (0)) {
				state = State.UNWIND;
				if (animator.GetBool ("wind")) {
					animator.ResetTrigger ("wind");
				}
				animator.SetTrigger ("unwind");
				rigidBody.angularVelocity = -Vector3.forward * angularSpeedL;
			}
		} else if (state == State.UNWIND) {
			if (Input.GetMouseButton (0)) {
				state = State.WIND;
				animator.SetTrigger ("wind");
				Invoke ("rotateFast", 0.3f);
			}
		}

		//For calculating full rotations of the object
		currentRotation = transform.eulerAngles.y;
		if (Mathf.Abs(previousRotation - currentRotation) > 150) {
			fullflips += 0.5f;
		}
		previousRotation = currentRotation;

		//Apply gravity
		GetComponent<Rigidbody> ().AddForce(new Vector3(0, -10, 0));
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "pool") {
			state = State.INWATER;
		}
	}

	public static float getFullFlips() {
		return fullflips;
	}

	void jump() { 
		state = State.JUMP;
		rigidBody.velocity = (Vector3.right + 1.1f * Vector3.up) * speed;
		rigidBody.angularVelocity = -Vector3.forward * angularSpeedL;
	}

	void rotateFast() {
		rigidBody.angularVelocity = -Vector3.forward * angularSpeedH;
	}

	public static State getState() {
		return state;
	}
}
