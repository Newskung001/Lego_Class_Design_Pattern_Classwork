using System;
using UnityEngine;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreController : MonoBehaviour {

	public TMP_Text ScoreText;
	public GameObject resetButton;
	public TMP_Text winText;
	public static int score;
	public static int totalGold;
	public static int currentGold;

	// Use this for initialization
	void Start () {
		score = 0;
		currentGold = 0;
		resetButton.SetActive(false);
		winText.gameObject.SetActive(false);
		GameObject[] golds = GameObject.FindGameObjectsWithTag ("Gold");
		if (golds != null)
			totalGold = golds.Length;
	}

	private void OnEnable() => EventManager.OnCoinCollected += AddScore;
	private void OnDisable() => EventManager.OnCoinCollected -= AddScore;

	private void AddScore(int coinValue)
	{
		score += coinValue;
		currentGold += 1;
		ScoreText.text = "Score : " + score.ToString();
		if (currentGold >= totalGold) WinGame();
	}
	


	void WinGame()
	{
		EventManager.RaisePlayerWin();
		// GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
		// foreach (GameObject enemy in enemys)
		// {
		// 	enemy.SendMessage("PlayerDie");
		// }
		winText.text = "YOU WIN !!!";
		winText.gameObject.SetActive(true);
		resetButton.SetActive(true);
	}

	// Update is called once per frame 
	// void Update () {
	// 	if (totalGold > 0) {
	// 		ScoreText.text = "Score : " + score.ToString();
	// 		if (currentGold >= totalGold)
	// 		{
	// 			GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
	// 			foreach (GameObject enemy in enemys)
	// 			{
	// 				enemy.SendMessage("PlayerDie");
	// 			}
	// 			winText.text = "YOU WIN !!!";
	// 			winText.gameObject.SetActive(true);
	// 			resetButton.SetActive(true);
	// 		}
	// 	}
	// }

	public void Die (){
		winText.text = "YOU DIE !!!";
		winText.gameObject.SetActive(true);
		resetButton.SetActive(true);
	}


	public void Restart(){
		UnityEngine.SceneManagement.SceneManager.LoadScene(0); 
	}
}
