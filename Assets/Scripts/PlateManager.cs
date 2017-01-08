using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlateManager : MonoBehaviour,  IDropHandler {

	public RecipeManager recipeManager;
	public StepsManager stepsManager;
	public Transform[] slots; 

	public void Start () {
		slots = new Transform[transform.childCount];
		recipeManager.InitIngredients ();
		for (int i = 0 ; i < slots.Length ; i++) {
			slots[i] = transform.GetChild(i);
		}

	}

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		for (int i = 0; i < slots.Length; i++) {
			if (i == 0) {
				//stepsManager.GoToGarnishStep ();
			}
			if (!slots[i].GetComponent<Slot>().item) {
				DragHandler.itemBeingDragged.transform.SetParent (slots[i]);
				DragHandler.itemBeingDragged.transform.rotation = slots[i].rotation;
				recipeManager.ActualizePlate ();
				return;
			}
		}
	}
	#endregion
}
