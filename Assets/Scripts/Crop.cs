using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Crop : MonoBehaviour {
	//fields
	public int age;
	private float initialXPos;
	private float initialYPos;
	//properties
	public abstract string cropName { get; }
	public abstract Sprite[] growthStages { get; }
	public abstract List<int> yieldPerGrowthStage { get; }
	public abstract List<float> xOffsets { get; }
	public abstract List<float> yOffsets { get; }

	// Set initial state
	public void Create (float xPos, float yPos) {
		initialXPos = xPos;
		initialYPos = yPos;
		age = 0;
		GetComponent<SpriteRenderer> ().sprite = growthStages[age];
		SetPosition (0);
	}

	public void Grow () {
		if (age == growthStages.Length - 1) {
			return;
		}
		age += 1;
		if (age <= growthStages.Length - 1) {
			GetComponent<SpriteRenderer> ().sprite = growthStages[age];
			SetPosition(age);
		}
	}

	void SetPosition(int idx) {
		this.transform.position = new Vector3 (initialXPos + xOffsets[idx], initialYPos + yOffsets[idx], -0.2f);
	}

	public int Harvest() {
		int harvestAmt = yieldPerGrowthStage[age];
		GetComponent<SpriteRenderer> ().sprite = null;
		age = 0;
		return harvestAmt;
	}
}
