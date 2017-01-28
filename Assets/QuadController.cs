using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuadController : MonoBehaviour {

	public GameObject textObject;
	public GameObject canvas;

	private Text text;

	void OnTriggerEnter(Collider other) {

		text = textObject.GetComponent<Text> ();

		if (other.gameObject.tag == "Player") {
			float rotX = other.gameObject.transform.eulerAngles.x;
			float rotZ = other.gameObject.transform.eulerAngles.z;
			float rotY = other.gameObject.transform.eulerAngles.y;

			if ((rotX < 30 || rotX > 330 && rotX < 360)) {
				text.text = "Nice!";
			} else {
				text.text = "Flopped";
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			canvas.SetActive (true);
		}
		if (Jump.getState () == Jump.State.WIND) {
			text.text = "Still tucking!";
		}
		CameraController.isFollowingPlayer = false;
	}

}
