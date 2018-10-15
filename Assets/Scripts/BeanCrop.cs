using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanCrop : Crop {
	private Sprite[] _growthStages;

	public override string cropName {
		get {
			return "bean";
		}
	}

	public override Sprite[] growthStages {
		get {
			return _growthStages;
		}
	}

	public override List<int> yieldPerGrowthStage { 
		get {
			return new List<int> (){0,0,0,9};
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

	void Start () {
		// TODO: replace with AssetBundle.LoadFromFile
		// https://docs.unity3d.com/ScriptReference/AssetBundle.LoadFromFile
		_growthStages = Resources.LoadAll<Sprite>("Bean");
	}
}
