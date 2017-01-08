using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour {

	public PlateManager plateManager;

	public Transform recipeBook;
	public List<Recipe> recipes = new List<Recipe>();

	public GameObject[] ingredients;

	public List<Transform> slotsMenu = new List<Transform>(); 
	public Transform[] ingredientsInPlate;

	public void Start () {
		foreach (Transform tr in recipeBook) {
			recipes.Add (tr.GetComponent<Recipe>());
		}
		foreach (Transform tr in transform) {
			foreach (Transform sl in tr) {
				slotsMenu.Add (sl);
			}
		}
		InitIngredients ();
	}

	public void InitIngredients () {
	
		ingredientsInPlate = new Transform[plateManager.slots.Length];
		for (int i = 0; i < recipes.Count; i++) {
			foreach (Transform slot in slotsMenu) {
			
				if (0 == 0){} // vérifier si le composant n'estpas présent dans la liste pour une recette antécédante

			}
			GameObject ingr = Instantiate (recipes [i].ingredients [0]) as GameObject;
			ingr.transform.parent = slotsMenu [i];
		
		}
	}

	public void ActualizePlate () {
		for (int i = 0; i < plateManager.slots.Length; i++) {
			if (plateManager.slots [i].GetComponent<Slot> ().item) {
				ingredientsInPlate [i] = plateManager.slots [i].GetChild (0);
			}
		}
	}

	public void ActualizeIngredients() {
	
		foreach (Transform ingr in ingredientsInPlate) {
		
			

		} 
	}
}
