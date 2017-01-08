using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlateManager : MonoBehaviour,  IDropHandler {

	public RecipeManager recipeManager;
	public StepsManager stepsManager;
	public List<Transform> slots = new List<Transform>(); 

	public void Start () {
		recipeManager.InitIngredients ();
		for (int i = 0 ; i < transform.childCount ; i++) {
			slots.Add (transform.GetChild(i));
		}

	}

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		for (int i = 0; i < slots.Count; i++) {
			if (!slots[i].GetComponent<Slot>().item) {
				DragHandler.itemBeingDragged.transform.SetParent (slots[i]);
				DragHandler.itemBeingDragged.transform.rotation = slots[i].rotation;
				recipeManager.ActualizePlate ();
				recipeManager.ActualizeIngredients ();
				return;
			}
		}
	}
	#endregion
}
