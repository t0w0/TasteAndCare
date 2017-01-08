using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour {

	public GameObject item {
		get {
			if (transform.childCount > 0) {
				return transform.GetChild (0).gameObject;
			} else {
				return null;
			}
		}
	}
}
