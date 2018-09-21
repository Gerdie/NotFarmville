using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	[SerializeField] private Sprite[] images;
	private FarmTile[] farmTiles;
	public FarmTile baseTile;

	// Use this for initialization
	void Start () {
		float[] xPositions = {-0.439f, 0.45f, 0.454f, 1.338f, 1.34f, 1.346f, 2.217f, 2.221f, 3.109f};
		float[] yPositions = {-0.53f, -1.27f, 0.21f, -0.536f, -2.01f, 0.952f, 0.217f, -1.274f, -0.53f};
		farmTiles = new FarmTile[xPositions.Length * yPositions.Length];

		for ( int i=0; i < xPositions.Length; i++ ) {

			FarmTile currentTile;
			if (i == 0) {
				currentTile = baseTile;
			} else {
				currentTile = Instantiate(baseTile) as FarmTile;
			}

			int randomImgIndex = Random.Range (0, images.Length);
			currentTile.LayTile (i, xPositions[i], yPositions[i], images[randomImgIndex]);
			farmTiles [i] = currentTile;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
