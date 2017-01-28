using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

	public void Replay() {
		SceneManager.LoadScene (0);
		GameObject.FindGameObjectWithTag ("canvas").SetActive (false);
	}
}
