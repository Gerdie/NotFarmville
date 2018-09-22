using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour {
	[SerializeField] Sprite[] growthStages;
	[SerializeField] float[] xOffsets;
	[SerializeField] float[] yOffsets;
	public int age;
	private float initialXPos;
	private float initialYPos;

	// Set initial state
	public void Create (float xPos, float yPos) {
		initialXPos = xPos;
		initialYPos = yPos;
		age = 0;
		GetComponent<SpriteRenderer> ().sprite = growthStages[age];
		SetPosition (0);
	}

	public void Grow () {
		age += 1;
		if (age < growthStages.Length) {
			GetComponent<SpriteRenderer> ().sprite = growthStages[age];
			SetPosition(age);
		}
	}

	void SetPosition(int idx) {
		this.transform.position = new Vector3 (initialXPos + xOffsets[idx], initialYPos + yOffsets[idx], -0.2f);
	}

	public void OnMouseClick() {
		Destroy (this);
	}
}
