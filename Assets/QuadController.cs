using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuadController : MonoBehaviour {

	public GameObject commentTextObject;
	public GameObject flipTextObject;

	public GameObject canvas;

	private Text commentText;
	private Text fliptext;

	void OnTriggerEnter(Collider other) {

		commentText = commentTextObject.GetComponent<Text> ();
		fliptext = flipTextObject.GetComponent<Text> ();

		if (other.gameObject.tag == "Player") {
			float rotX = other.gameObject.transform.eulerAngles.x;
			float rotZ = other.gameObject.transform.eulerAngles.z;
			float rotY = other.gameObject.transform.eulerAngles.y;

			if ((rotX < 30 || rotX > 330 && rotX < 360)) {
				commentText.text = "Awesome!";
			} else {
				commentText.text = "Flopped";
			}
			fliptext.text = "Flips : " + Jump.getFullFlips ();
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			canvas.SetActive (true);
		}
		if (Jump.getState () == Jump.State.WIND) {
			commentText.text = "Still tucking!";
		}
		CameraController.isFollowingPlayer = false;
	}

}
