using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTile : MonoBehaviour {
	private int _id;

	public int id {
		get { return _id; }
	}

	// Used for initialization
	public void LayTile (int _id, float xPos, float yPos, Sprite image) {
		GetComponent<SpriteRenderer> ().sprite = image;
		this.transform.position = new Vector3 (xPos, yPos, -0.1f);
	}

}
