using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientQuantity : MonoBehaviour {

	public Stats stat;

	public float quantity = 1;
	public float max =  2.5f;
	public float min = 0;
	public float add = 0.5f;

	public Text quant;
	public Text name;
	public Image sprite;
	
	// Update is called once per frame
	void Update () {
		
	}

	public void More () {
		if (quantity < max) {
			quantity += add;
			transform.parent.GetComponent<Quantity> ().ActualiseQuantity ();
			StatsManager.AddQuantity (stat, quantity);
		}
	}
	public void Less () {
		if (quantity > min) {
			quantity -= add;
			transform.parent.GetComponent<Quantity> ().ActualiseQuantity ();
			StatsManager.LessQuantity (stat, quantity);
		}
	}
}
