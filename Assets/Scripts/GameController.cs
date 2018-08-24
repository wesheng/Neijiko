using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public NejikoController nejiko;
	public Text scoreLabel;
	public LifePanel lifePanel;
    public float score = 0.0f;

    public void Start()
    {
        score = 0.0f;
    }

    public void Update () {
        // Update Score label
        AddToScore(CalcScore());
		scoreLabel.text = "Score : " + (int)score;

		// Update Life Panel
		lifePanel.UpdateLife(nejiko.Life);

		// Close game when life count become 0
		if (nejiko.Life <= 0) {
			// Stop more update
			enabled = false;

			// Update high score
			if (PlayerPrefs.GetFloat ("HighScore") < score) {
				PlayerPrefs.GetFloat("HighScore", score);
			}

			// Call ReturnToTile in 2 seconds
			Invoke("ReturnToTitle", 2.0f);
		}
	}

    public float CalcScore()
    {
        return Time.deltaTime * (GlobalInfo.NejikoController.speedZ / (GlobalInfo.NejikoController.speedZ * 0.6f));
    }

    public void AddToScore(float scoreToAdd)
    {
        score += scoreToAdd;
    }

	void ReturnToTitle() {
		// Change to Title Scene
		SceneManager.LoadScene("Title");
	}
}
