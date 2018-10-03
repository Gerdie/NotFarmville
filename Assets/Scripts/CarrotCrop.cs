using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCrop : Crop {

	public override List<float> xOffsets {
		get {
			return new List<float>(){0f,0f,0f,0f};
		}
	}
	public override List<float> yOffsets {
		get {
			return new List<float>(){0.12f, 0.2f, 0.35f, 0.4f};
		}
	}
}
