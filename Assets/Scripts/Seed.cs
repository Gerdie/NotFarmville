using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seed : MonoBehaviour {
	[SerializeField] Inventory inventory;
	[SerializeField] string seedName;
	[SerializeField] Button seedButton;

	public void Start() {
//		UpdateButtonText ();
	}

	public void Use () {
		// TODO: make sure this never gets negative
		inventory.DecrementItem (seedName);
		UpdateButtonText ();
	}

	private string GetDisplayText() {
		return seedName + " " + inventory.GetItemQty (seedName).ToString ();
	}

	public void UpdateButtonText() {
		seedButton.GetComponentInChildren<Text>().text = GetDisplayText();
	}
}
