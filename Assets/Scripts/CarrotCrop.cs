using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCrop : Crop {
	private Sprite[] _growthStages;

	public override string cropName {
		get {
			return "carrot";
		}
	}

	public override Sprite[] growthStages {
		get {
			return _growthStages;
		}
	}

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

	void Start () {
		// TODO: replace with AssetBundle.LoadFromFile
		// https://docs.unity3d.com/ScriptReference/AssetBundle.LoadFromFile
		_growthStages = Resources.LoadAll<Sprite>("Carrot");
	}
}
