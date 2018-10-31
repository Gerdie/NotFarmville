using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	public Dictionary<string, int> items;

	// Use this for initialization
	void Start () {
		items = new Dictionary<string, int>();
		// TODO: automate this according to mapping?
		RegisterItem ("carrot");
		RegisterItem ("carrot seed");
		SetItemQty ("carrot seed", 5);
		RegisterItem ("bean");
		RegisterItem ("bean seed");
		SetItemQty ("bean seed", 3);
	}

	public void RegisterItem (string itemName) {
		items [itemName] = 0;
	}

	public void IncrementItem(string itemName, int itemAmt) {
		int curAmt = items [itemName];
		items [itemName] = curAmt + itemAmt;
		Debug.Log (items [itemName] + " " + itemName + " in inventory");
	}

	public void DecrementItem(string itemName) {
		int curAmt = items [itemName];
		items [itemName] = curAmt - 1;
		Debug.Log (items [itemName] + " " + itemName + " in inventory");
	}

	public int GetItemQty(string itemName) {
		return items [itemName];
	}

	public void SetItemQty(string itemName, int qty) {
		items [itemName] = qty;
	}
}
