using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StepsManager : MonoBehaviour {

	public RecipeManager recipeManager;

	public bool welcome = false;
	public bool protein = false;
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

	public void Quantity () {

		quantity = true;
		GetComponent<Animator> ().SetBool ("quantity", quantity);

	}

	public void Wait () {

		wait = true;
		GetComponent<Animator> ().SetBool ("wait", wait);

	}

	public void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.LoadScene ("MainScene");
		}

	}


}
