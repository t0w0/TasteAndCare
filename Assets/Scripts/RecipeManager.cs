using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour {

	public PlateManager plateManager;

	public Transform recipeBook;
	public List<Recipe> recipes = new List<Recipe>();
	public List<Recipe> possibleRecipes = new List<Recipe> ();
	public List<Recipe> impossibleRecipes = new List<Recipe> ();

	public GameObject[] ingredients;

	public List<Transform> slotsMenu = new List<Transform> ();
	public List<GameObject> ingredientsInMenu = new List<GameObject> ();
	public List<GameObject> ingredientsInPlate = new List<GameObject> ();

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
		bool exist = false;

		for (int i = 0; i < recipes.Count; i++) {
			if (ingredientsInMenu.Count == 0)
				ingredientsInMenu.Add (recipes [i].ingredients [ingredientsInPlate.Count]);
			else {
				foreach (GameObject ing in ingredientsInMenu) {
					if (ing.GetComponent<Stats> ().name == possibleRecipes [i].ingredients [ingredientsInPlate.Count].GetComponent<Stats> ().name) {
						exist = true;
					}
				}
				if (!exist) {
					ingredientsInMenu.Add (possibleRecipes [i].ingredients [ingredientsInPlate.Count]);
				}
			}
			exist = false;
		}

		foreach (GameObject ing in ingredientsInMenu) {
			GameObject inst = Instantiate (ing) as GameObject;
			for (int i = 0 ; i < ingredientsInMenu.Count ; i ++) {
				if (!slotsMenu[i].GetComponent<Slot> ().item) {
					inst.transform.parent = slotsMenu[i];
					break;
				}
			}
		
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
		ingredientsInMenu.Clear ();
		foreach (Transform slot in slotsMenu) {
			if (slot.childCount != 0)
				Destroy(slot.GetChild(0).gameObject);
		}

		foreach (GameObject ingr in ingredientsInPlate) {
			
			for (int i = 0; i < recipes.Count; i++) {
				if (recipes[i].ingredients [ingredientsInPlate.Count-1].GetComponent<Stats> ().name != ingr.GetComponent<Stats> ().name) {
					impossibleRecipes.Add (recipes[i]);
				} 
			}
			for (int i = 0; i < impossibleRecipes.Count; i++) {
				recipes.Remove (impossibleRecipes [i]);
			}
		}
		if (possibleRecipes.Count > 2) {
			InitIngredients ();
		}
	}
}
