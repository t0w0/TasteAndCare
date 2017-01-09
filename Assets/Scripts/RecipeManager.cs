using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour {

	public PlateManager plateManager;
	public StepsManager stepsManager;
	public Quantity quantity;
	public AgentGenerator agentManager;
	public Transform recipeBook;
	public List<Recipe> recipes = new List<Recipe>();
	public List<Recipe> possibleRecipes = new List<Recipe> ();
	public List<Recipe> impossibleRecipes = new List<Recipe> ();

	public Image recipeCreated;

	public GameObject[] ingredients;

	public List<Transform> slotsMenu = new List<Transform> ();
	public List<GameObject> ingredientsInMenu = new List<GameObject> ();
	public List<GameObject> ingredientsInPlate = new List<GameObject> ();

	public GameObject acceptButton;

	public void Start () {
		foreach (Transform tr in recipeBook) {
			recipes.Add (tr.GetComponent<Recipe>());
		}
		foreach (Transform tr in transform) {
			foreach (Transform sl in tr) {
				slotsMenu.Add (sl);
			}
		}
		possibleRecipes = recipes;
		InitIngredients ();
	}

	public void InitIngredients () {
		for (int i = 0; i < recipes.Count; i++) {
			if (ingredientsInMenu.Count == 0)
				ingredientsInMenu.Add (recipes [i].ingredients [ingredientsInPlate.Count]);
			else {
				if (!ingredientsInMenu.Contains (recipes [i].ingredients [ingredientsInPlate.Count]))
					ingredientsInMenu.Add (possibleRecipes [i].ingredients [ingredientsInPlate.Count]);
			}
		}
		for (int i = 0; i < ingredientsInMenu.Count; i++) {
			GameObject inst = Instantiate (ingredientsInMenu[i]) as GameObject;
			inst.transform.parent = slotsMenu[i];
		} 
	}

	public void ActualizePlate () {
		ingredientsInPlate.Clear ();
		foreach (Transform slot in plateManager.slots) {
			if (slot.GetComponent<Slot> ().item) {
				ingredientsInPlate.Add (slot.GetComponent<Slot>().item);
			}
		}
	}

	public void ActualizeIngredients() {
		
		for (int i = 0; i < recipes.Count; i++) {
			bool exist = false;
			foreach (GameObject ing in recipes[i].ingredients) {
				if (ing.GetComponent<Stats> ().name == ingredientsInPlate [ingredientsInPlate.Count - 1].GetComponent<Stats> ().name)
					exist = true;
			}
			if (!exist) 
				impossibleRecipes.Add (recipes [i]);
		}
		for (int i = 0; i < impossibleRecipes.Count; i++) {
			recipes.Remove (impossibleRecipes [i]);
		}
		ingredientsInMenu.Clear ();
		foreach (Transform slot in slotsMenu) {
			if (slot.childCount != 0)
				Destroy(slot.GetChild(0).gameObject);
		}
		if (possibleRecipes.Count > 2) {
			InitIngredients ();


		} else {
			acceptButton.SetActive (true);
			recipeCreated.enabled = true;
			recipeCreated.sprite = possibleRecipes [0].picto;
		}
	}

	public void ClearEverything () {

		ingredientsInMenu.Clear ();
		impossibleRecipes.Clear ();
		possibleRecipes.Clear ();
		ingredientsInPlate.Clear ();
		recipes.Clear ();
		recipeCreated.enabled = false;
		acceptButton.SetActive (false);
		foreach (Transform tr in recipeBook) {
			recipes.Add (tr.GetComponent<Recipe>());
		}
		foreach (Transform slot in slotsMenu) {
			if (slot.childCount != 0)
				Destroy(slot.GetChild(0).gameObject);
		}
		foreach (Transform slot in plateManager.slots) {
			if (slot.childCount != 0)
				Destroy(slot.GetChild(0).gameObject);
		}
		InitIngredients ();

	}

	public void AcceptRecipe () {

		if (stepsManager.quantity == false) {
			stepsManager.Quantity ();
			StatsManager.InitRecipe (possibleRecipes [0].transform.GetComponent<Stats> ());
			quantity.recipe = possibleRecipes [0];
			quantity.InitIngredients ();
		} else {
			stepsManager.Wait ();
			agentManager.ActualizeColor ();
		}

	}
}
