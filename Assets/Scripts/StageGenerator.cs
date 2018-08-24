using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class StageGenerator : MonoBehaviour {
	const int StageTipSize = 30;

	int currentTipIndex;

	public Transform character;
	public int startTipIndex;
	public int preInstantiate;
	public List<GameObject> generatedStageList = new List<GameObject> ();
    [SerializeField] private GameObjectChances gameObjectChances;

    //// Random generation

    [SerializeField] private GameObjectChances stages;
    // Use for random generation of enemy
    public List<GameObject> enemyPoints = new List<GameObject>();



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
	GameObject GenerateStage (int tipIndex)
	{
	    GameObject stageObject = Instantiate (stages.RollForObject(),
	        new Vector3 (0, 0, tipIndex * StageTipSize), Quaternion.identity);
        // place enemies on the stage.
        // min x = -2.5, max x = 2.5
        // y = 0
        // 5 < x < 25
	    const int numberOfEnemiesToSpawn = 3;
	    int enemyIndex = Random.Range(0, enemyPoints.Count);
	    BoundsRegion boundsRegion = stageObject.GetComponentInChildren<BoundsRegion>();
        
	    for (int i = 0; i < numberOfEnemiesToSpawn; ++i)
	    {
	        GameObject enemy = (GameObject) Instantiate(enemyPoints[enemyIndex], stageObject.transform);
	        Vector3 pos = boundsRegion.GetRandomPoint();
            enemy.transform.localPosition = new Vector3(
                pos.x,
                0,
                pos.z
                );
	    }

	    GameObject powerup = gameObjectChances.RollForObject();
	    if (powerup != null)
	    {
	        GameObject spawnedPowerup = Instantiate(powerup, stageObject.transform);
	        Vector3 pos = boundsRegion.GetRandomPoint();
            spawnedPowerup.transform.localPosition = new Vector3(
                pos.x,
                1,
                pos.z
                );
	    }

		return stageObject;
	}

	// Delete the oldest stage
	void DestroyOldestStage() {
		GameObject oldStage = generatedStageList[0];
		generatedStageList.RemoveAt (0);
		Destroy (oldStage);
	}

    public GameObject GetOldestStage()
    {
        return generatedStageList[0];
    }

    public GameObject GetStage(int index)
    {
        return generatedStageList[index];
    }
}
