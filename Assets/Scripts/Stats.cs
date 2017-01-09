using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	public string name;

	public float[] stats = { 
		0,
		0,
		0,
		0,
		0
	};

	private int[] recommended = {
		2700,
		9,
		1080,
		1215,
		450
	};

	public void Start () {
		for (int i = 0; i < stats.Length; i++) {
			stats [i] = Mathf.RoundToInt(stats [i] * 100 / recommended [i]);
		}
	}

	
}
