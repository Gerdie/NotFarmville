using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTile : MonoBehaviour {
	[SerializeField] Equip equip;
	public Sprite plowedImg;
	private int _id;
	private bool plowed;
	private bool planted;
	private float timeGrowing;
	private Crop crop;
	public BeanCrop beanCrop;
	public CarrotCrop carrotCrop;

	public int id {
		get { return _id; }
	}

	// Used for initialization
	public void LayTile (int id, float xPos, float yPos, Sprite image) {
		this._id = id;
		GetComponent<SpriteRenderer> ().sprite = image;
		this.transform.position = new Vector3 (xPos, yPos, -0.1f);
		plowed = false;
	}

	public void Plow() {
		GetComponent<SpriteRenderer> ().sprite = plowedImg;
		plowed = true;
	}

	public void Plant(string cropName) {
		if (cropName == "carrot") {
//			carrotCrop.Create(this.transform.position.x, this.transform.position.y);
			crop = carrotCrop;
		} else if (cropName == "bean") {
//			beanCrop.Create(this.transform.position.x, this.transform.position.y);
			crop = beanCrop;
		} else {
			Debug.LogError("Tried to Plant unknown crop: " + cropName);
		}
		crop.Create(this.transform.position.x, this.transform.position.y);
		planted = true;
		timeGrowing = 0;
	}

	void GrowPlant(float deltaTime) {
		timeGrowing += deltaTime;
		// Grow Crop every 10 seconds
		if (timeGrowing > 3) {
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
		if (plowed && equip.equippedTool == "bean seed") {
			Plant ("bean");
		} else if ( plowed && equip.equippedTool == "carrot seed" ) {
			Plant ("carrot");
		} else if ( !plowed && equip.equippedTool == "hoe" ) {
			Plow ();
		}
	}

}
