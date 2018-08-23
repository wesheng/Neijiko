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
		score += Time.deltaTime;
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

	void ReturnToTitle() {
		// Change to Title Scene
		SceneManager.LoadScene("Title");
	}
}
