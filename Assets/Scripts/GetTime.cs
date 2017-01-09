using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetTime : MonoBehaviour {
	void Update () {
		GetComponent<Text> ().text = System.DateTime.Now.Hour + " : " + System.DateTime.Now.Minute;
	}
}
