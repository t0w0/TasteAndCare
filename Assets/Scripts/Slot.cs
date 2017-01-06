using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {

	public GameObject item {
		get {
			if (transform.childCount > 0) {
				return transform.GetChild (0).gameObject;
			} else {
				return null;
			}
		}
	}

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		Debug.Log ("Drop");
		if (!item) {
			DragHandler.itemBeingDragged.transform.SetParent (transform);
			DragHandler.itemBeingDragged.transform.rotation = transform.rotation;
		}
	}
	#endregion
}
