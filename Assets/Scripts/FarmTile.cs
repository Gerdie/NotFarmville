using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTile : MonoBehaviour {
	[SerializeField] Equip equip;
	[SerializeField] Inventory inventory;
	public Sprite plowedImg;
	public Sprite unplowedImg;
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

	// Used for initialization in Controller.cs
	public void LayTile (int id, float xPos, float yPos, Sprite image) {
		this._id = id;
		GetComponent<SpriteRenderer> ().sprite = image;
		this.transform.position = new Vector3 (xPos, yPos, -0.1f);
		plowed = false;
	}

	public void Plow() {
		if ( planted ) {
			crop.Harvest();
			planted = false;
			timeGrowing = 0;
		}
		GetComponent<SpriteRenderer> ().sprite = plowedImg;
		plowed = true;
	}

	public void Plant(string cropName) {
		// TODO: Use() Seed here
		if (cropName == "carrot") {
			crop = carrotCrop;
		} else if (cropName == "bean") {
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
		// Grow Crop every 3 seconds
		if (timeGrowing > 3) {
			crop.Grow ();
			timeGrowing = 0;
		}
	}

	void HarvestPlant() {
		string harvestedCropName = crop.cropName;
		int harvestableAmt = crop.Harvest ();
		inventory.IncrementItem (harvestedCropName, harvestableAmt);
		GetComponent<SpriteRenderer> ().sprite = unplowedImg;
		planted = false;
		plowed = false;
	}

	void FixedUpdate() {
		if (planted) {
			GrowPlant(Time.deltaTime);
		}
	}

	public void OnMouseDown() {
		if ( equip.equippedTool == "hoe" ) {
			Plow ();
		} else if ( equip.equippedTool == "pail" ) {
			HarvestPlant ();
		} else if ( plowed && !planted ) {
			if (equip.equippedTool == "bean seed") {
				Plant ("bean");
			} else if (equip.equippedTool == "carrot seed") {
				Plant ("carrot");
			}
		}
	}

}
