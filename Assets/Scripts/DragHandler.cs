using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler ,IEndDragHandler, IPointerEnterHandler {
	
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	Transform startParent;

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}
	#endregion
	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}
	#endregion
	#region IEndDragHandler implementation
	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
		if (transform.parent == startParent) {
			transform.position = startPosition;
		}
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		//transform.position = startPosition;
	}
	#endregion
	#region IPointerEnterHandler implementation
	public void OnPointerEnter (PointerEventData eventData)
	{
		StatsManager.ActualizeStats (transform.GetComponent<Stats> ());
	}
	#endregion
}
