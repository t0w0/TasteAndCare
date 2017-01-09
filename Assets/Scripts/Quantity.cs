using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quantity : MonoBehaviour {

	public Recipe recipe;
	public IngredientQuantity[] ingredients;

	public void InitIngredients () {
		transform.GetChild (0).GetComponent<Text> ().text = recipe.name;
		for (int i = 0; i < ingredients.Length; i++) {
			if (recipe.ingredients.Count > i) {
				ingredients [i].transform.gameObject.SetActive (true);
				ingredients [i].name.text = recipe.ingredients [i].GetComponent<Stats> ().name;
				ingredients [i].quant.text = 100 + " g";
				ingredients [i].sprite.sprite = recipe.ingredients [i].GetComponent<Image> ().sprite;
				ingredients [i].stat = recipe.ingredients [i].GetComponent<Stats> ();
			} else {
				ingredients [i].transform.gameObject.SetActive (false);
			}
		}
		StatsManager.ActualizeStats (recipe.transform.GetComponent<Stats> ());
	}
		
	public void ActualiseQuantity () {
		for (int i = 0; i < ingredients.Length; i++) {
			if (recipe.ingredients.Count > i) {
				ingredients [i].quant.gameObject.SetActive (true);
				ingredients [i].quant.text = ingredients [i].quantity*100 + " g";
			} else {
				ingredients [i].quant.gameObject.SetActive (false);
			}
		}
		StatsManager.ActualizeStats (recipe.transform.GetComponent<Stats> ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
