using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour {

	public static RectTransform rect;
	public static Vector2[] goalVector;
	public static Stats myStats;
	public static Stats initialStats;

	// Use this for initialization
	void Start () {
		rect = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		foreach (RectTransform tr in rect) {
			if (i != 0 && myStats != null) {
				float percent = ((myStats.stats [i - 1]*400)/100) ;
				if (tr.offsetMin.y != percent ) {
					tr.offsetMin = Vector2.Lerp (tr.offsetMin,  new Vector2 (300 - percent, tr.offsetMin.y), 0.1f);
				}
			}
			i++;
		}
	}
	public static void InitRecipe (Stats stat) {
		initialStats = stat;
	}

	public static void ActualizeStats (Stats stats) {
		myStats = stats;
		rect.GetChild(0).GetComponent<Text> ().text = stats.name;
		rect.GetChild (1).GetChild (1).GetComponent<Text> ().text = stats.stats [0] + " %";
		rect.GetChild (2).GetChild (1).GetComponent<Text> ().text = stats.stats [1] + " %";
		rect.GetChild (3).GetChild (1).GetComponent<Text> ().text = stats.stats [2] + " %";
		rect.GetChild (4).GetChild (1).GetComponent<Text> ().text = stats.stats [3] + " %";
		rect.GetChild (5).GetChild (1).GetComponent<Text> ().text = stats.stats [4] + " %";
	}

	public static void AddQuantity (Stats st, float quant) {
		for (int i = 0 ; i < myStats.stats.Length ; i ++ ) {

			myStats.stats [i] = initialStats.stats[i] + 5;
			if (myStats.stats [i] < 0)
				myStats.stats[i] = 0f;
		
		}
		ActualizeStats (myStats);
	}
	public static void LessQuantity (Stats st, float quant) {
		for (int i = 0 ; i < myStats.stats.Length ; i ++ ) {

			myStats.stats [i] =   initialStats.stats[i] - 5;
			if (myStats.stats [i] < 0)
				myStats.stats[i] = 0f;

		}
		ActualizeStats (myStats);
	}
}
