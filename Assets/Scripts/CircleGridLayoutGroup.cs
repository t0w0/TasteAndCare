using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGridLayoutGroup : MonoBehaviour {

	public float angle = 30;
	public float radius = 1000;
	private float actualAngle = 0;

	// Use this for initialization
	void Start () {

		foreach (Transform child in transform) {
			
			child.localPosition = new Vector2 (Mathf.Cos(actualAngle * Mathf.Deg2Rad)*radius, Mathf.Sin(actualAngle * Mathf.Deg2Rad)*radius);
			child.localRotation = Quaternion.Euler(new Vector3 (0, 0, actualAngle-90));
			actualAngle = actualAngle + angle;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
