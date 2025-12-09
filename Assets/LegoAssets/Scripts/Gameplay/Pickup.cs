using System;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Pickup : MonoBehaviour {

	//public GameObject MyPrefab;
	//GameObject myPrefab;
	public int coinValue = 10;

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			EventManager.RaiseCoinCollected(coinValue);
			// ScoreController.score += 10;
			// ScoreController.currentGold ++;
			//myPrefab = Instantiate(MyPrefab, this.transform.position, MyPrefab.transform.rotation) as GameObject;
			gameObject.SetActive(false);
		}
	}
}
