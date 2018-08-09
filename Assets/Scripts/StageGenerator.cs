using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour {
	const int StageTipSize = 30;

	int currentTipIndex;

	public Transform character;
	public GameObject[] stageTips;
	public int startTipIndex;
	public int preInstantiate;
	public List<GameObject> generatedStageList = new List<GameObject> ();

	// Use this for initialization
	void Start () {
		currentTipIndex = startTipIndex - 1;
		UpdateStage (preInstantiate);
	}
	
	// Update is called once per frame
	void Update () {
		// Calculate index of current stage tip by character's position
		int charaPositionIndex = (int)(character.position.z / StageTipSize);

		// When enter next stage tip, update stage state
		if (charaPositionIndex + preInstantiate > currentTipIndex) {
			UpdateStage (charaPositionIndex + preInstantiate);
		}
	}

	// Make stage tips until particular index
	void UpdateStage (int toTipIndex) {
		if (toTipIndex <= currentTipIndex)
			return;

		// Make stage tips until particular index
		for (int i = currentTipIndex + 1; i <= toTipIndex; i++) {
			GameObject stageObject = GenerateStage (i);

			// Add created stage to List
			generatedStageList.Add(stageObject);

			// When stage count is over then maximum, delete old stage
			while(generatedStageList.Count > preInstantiate + 2) 
				DestroyOldestStage();

			currentTipIndex = toTipIndex;
		}
	}

	// Create Stage object in particular position
	GameObject GenerateStage (int tipIndex) {
		int nextStageTip = Random.Range (0, stageTips.Length);
		GameObject stageObject = (GameObject)Instantiate (stageTips [nextStageTip],
			     new Vector3 (0, 0, tipIndex * StageTipSize), Quaternion.identity);

		return stageObject;
	}

	// Delete the oldest stage
	void DestroyOldestStage() {
		GameObject oldStage = generatedStageList[0];
		generatedStageList.RemoveAt (0);
		Destroy (oldStage);
	}
}
