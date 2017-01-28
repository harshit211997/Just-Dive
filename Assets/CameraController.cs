using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject gameObject;
	public static bool isFollowingPlayer = true;

	private float distance = 70;
	private float offset = 17;
	private Vector3 velocity = Vector3.zero;
	private Vector3 targetPosition;
	private Vector3 initialPosition;

	void Start() {
		isFollowingPlayer = true;
		Transform target = gameObject.GetComponent<Transform> ();
		targetPosition = new Vector3 (
			target.position.x + 10,
			target.position.y + offset,
			target.position.z - distance
		);
		initialPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (isFollowingPlayer) {
			transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref velocity, 1f);
			Transform target = gameObject.GetComponent<Transform> ();
			targetPosition = new Vector3 (
				target.position.x + 10,
				target.position.y + offset,
				target.position.z - distance
			);
		} else {
			transform.position = Vector3.SmoothDamp (transform.position, initialPosition, ref velocity, 1f);
		}
	} 

	public static void followPlayer() {
		isFollowingPlayer = true;
	}

	public static void unfollowPlayer() {
		isFollowingPlayer = false;
	}
}
