using UnityEngine;
using System.Collections;

public class HeightController : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		float height = Random.Range(1, 7) * 40f;
		gameObject.GetComponent<Transform> ().localScale =  new Vector3(4.998868f, height, 5.071169f);
		player.GetComponent<Transform> ().position = new Vector3 (0, height / 2, 0);
	}

}
