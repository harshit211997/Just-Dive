using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject gameObject;
	public static bool isFollowingPlayer = true;

	private float distance = 70;
	private float offset = 17;

	void Start() {
		isFollowingPlayer = true;
	}

	// Update is called once per frame
	void Update () {
		if (isFollowingPlayer) {
			Transform target = gameObject.GetComponent<Transform> ();
			transform.position = new Vector3 (
				target.position.x + 10, 
				target.position.y + offset,
				target.position.z - distance
			);
		}
	} 

	public static void followPlayer() {
		isFollowingPlayer = true;
	}

	public static void unfollowPlayer() {
		isFollowingPlayer = false;
	}
}
