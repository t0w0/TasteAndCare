using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

	Vector2 position;
	Vector2 velocity;
	public float dist;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (Random.Range (0, 1080), Random.Range (0, 1080));

	}
	
	// Update is called once per frame
	void Update () {
		dist = Vector3.Distance (transform.position, Input.mousePosition);
		if (Input.GetButton ("Fire1")) {
			Vector3 mouseP = Input.mousePosition;
			transform.position = Vector3.Slerp (transform.position, mouseP, 0.1f/dist);
		}
	}
}
