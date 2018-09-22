using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour {
	[SerializeField] Sprite[] growthStages;
	public int age;

	// Set initial state
	public void Create (float xPos, float yPos) {
		age = 0;
		GetComponent<SpriteRenderer> ().sprite = growthStages[age];
		this.transform.position = new Vector3 (xPos, yPos + .4f, -0.2f);
	}

	public void Grow () {
		age += 1;
		if (age < growthStages.Length) {
			GetComponent<SpriteRenderer> ().sprite = growthStages[age];
		}
	}

	public void OnMouseClick() {
		Destroy (this);
	}
}
