﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentGenerator : MonoBehaviour {

	public int numberOfAgent = 50;
	public GameObject agent;
	public List <Transform> agents = new List<Transform> ();  
	public Color[] colors;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < numberOfAgent; i++) {
		
			GameObject agentGenerated = Instantiate (agent) as GameObject;
			agentGenerated.transform.parent = transform;
			agentGenerated.GetComponent<Image> ().color = colors [Random.Range (0, colors.Length)];	
			agents.Add (agentGenerated.transform);
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
