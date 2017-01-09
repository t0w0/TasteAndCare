using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsManager : MonoBehaviour {

	public RecipeManager recipeManager;

	public bool welcome = false;
	public bool protein = false;
	public bool garnish = false;
	public bool quantity = false;
	public bool wait = false;

	// Use this for initialization
	void Start () {
		welcome = true;
	}

	public void GoToProteinStep () {
		
		protein = true;
		GetComponent<Animator> ().SetBool ("protein", protein);
	}

	public void GoToGarnishStep () {
	
		garnish = true;
		GetComponent<Animator> ().SetBool ("garnish", garnish);
		recipeManager.ActualizeIngredients ();

	}

}
