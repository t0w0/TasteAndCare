using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

	public AgentGenerator agentGenerator;

	public float force = 5f;

	Vector2 position;
	Vector2 velocity;
	public float dist;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (Random.Range (0, Screen.width), Random.Range (0, Screen.width));
		agentGenerator = transform.parent.GetComponent<AgentGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float agentDist = Screen.width;
		dist = Vector3.Distance (transform.position, Input.mousePosition);
		if (Input.GetButton ("Fire1")) {
			Vector3 mouseP = Input.mousePosition;
			transform.position = Vector3.Slerp (transform.position, mouseP, 0.1f/dist);
		}
		if (dist < 50)
			force = 100;
		else
			force = 5;
		foreach (Transform tr in agentGenerator.agents) {
			if (agentDist > Vector3.Distance (transform.position, tr.position) && tr != transform) {
				agentDist = Vector3.Distance (transform.position, tr.position);
				Vector3[] points = {transform.position, tr.position};
				GetComponent<LineRenderer> ().SetPositions (points);
				GetComponent<LineRenderer> ().startWidth = GetComponent<LineRenderer> ().endWidth = Random.Range(1,2);
			}
		}
		transform.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-force, force), Random.Range(-force, force)));
	}
}
