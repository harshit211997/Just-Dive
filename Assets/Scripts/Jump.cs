using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float speed = 5f;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.AddForce ((Vector3.right + Vector3.up) * speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
