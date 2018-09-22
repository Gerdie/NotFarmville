using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTile : MonoBehaviour {
	public Sprite plowedImg;
	private int _id;
	private bool plowed;
	private bool planted;
	private float timeGrowing;
	public Crop crop;

	public int id {
		get { return _id; }
	}

	// Used for initialization
	public void LayTile (int _id, float xPos, float yPos, Sprite image) {
		GetComponent<SpriteRenderer> ().sprite = image;
		this.transform.position = new Vector3 (xPos, yPos, -0.1f);
		plowed = false;
	}

	public void Plow() {
		GetComponent<SpriteRenderer> ().sprite = plowedImg;
		plowed = true;
	}

	public void Plant() {
		crop.Create(this.transform.position.x, this.transform.position.y);
		planted = true;
		timeGrowing = 0;
	}

	void GrowPlant(float deltaTime) {
		timeGrowing += deltaTime;
		// Grow Crop every 10 seconds
		if (timeGrowing > 10) {
			crop.Grow ();
			timeGrowing = 0;
		}
	}

	void FixedUpdate() {
		if (planted) {
			GrowPlant(Time.deltaTime);
		}
	}

	public void OnMouseDown() {
		if ( plowed ) {
			Plant ();
		} else {
			Plow ();
		}
	}

}
