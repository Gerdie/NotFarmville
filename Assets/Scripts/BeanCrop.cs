using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanCrop : Crop {
	[SerializeField] Sprite[] _growthStages;

	public override Sprite[] growthStages {
		get {
			return _growthStages;
		}
	}
	public override List<float> xOffsets {
		get {
			return new List<float>(){0f,0.1f,0.1f,0.1f};
		}
	}
	public override List<float> yOffsets {
		get {
			return new List<float>(){0.6f, 0.84f, 0.84f, 0.84f};
		}
	}
}
