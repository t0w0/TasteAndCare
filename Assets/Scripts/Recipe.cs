using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {

	public string name;
	public string description;
	public List<GameObject> ingredients;
	public Sprite picto;

	public void Start () {
		name = gameObject.name;
	}

}
