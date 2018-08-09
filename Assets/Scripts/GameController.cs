using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public NejikoController nejiko;
	public Text scoreLabel;
	public LifePanel lifePanel;

	public void Update () {
		// Update Score label
		int score = CalcScore();
		scoreLabel.text = "Score : " + score + "m";

		// Update Life Panel
		lifePanel.UpdateLife(nejiko.Life());

		// Close game when life count become 0
		if (nejiko.Life () <= 0) {
			// Stop more update
			enabled = false;

			// Update high score
			if (PlayerPrefs.GetInt ("HighScore") < score) {
				PlayerPrefs.SetInt("HighScore", score);
			}

			// Call ReturnToTile in 2 seconds
			Invoke("ReturnToTitle", 2.0f);
		}
	}
	
	int CalcScore () {
		// The moving distance of Nejiko become the score.
		return (int)nejiko.transform.position.z;
	}

	void ReturnToTitle() {
		// Change to Title Scene
		SceneManager.LoadScene("Title");
	}
}
