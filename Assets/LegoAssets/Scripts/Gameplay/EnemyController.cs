using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	Transform player;
	UnityEngine.AI.NavMeshAgent nav;

	public float delayEnemy = 3;
	public bool isWalking = false;
	
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	void Start() {
		StartCoroutine(DelayEnemy());
	}
	
	IEnumerator DelayEnemy() {
		yield return new WaitForSeconds(delayEnemy);
		isWalking = true;
	}

	
	// Update is called once per frame
	void Update () {
		if (isWalking) {
			nav.SetDestination (player.position);
		} else {
			nav.SetDestination (gameObject.transform.position);
		}
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Player") {

			GameObject gameController = GameObject.Find("GameController");
			if (gameController != null)
            {
				gameController.GetComponent<ScoreController>().Die();
			}

			GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
			
			foreach (GameObject enemy in enemys) {
				enemy.SendMessage("PlayerDie");
			}

			col.gameObject.SetActive(false);
		}
	}

	private void OnEnable() => EventManager.OnPlayerWin += HandlePlayerWin;
	private void OnDisable() => EventManager.OnPlayerWin -= HandlePlayerWin;

	private void HandlePlayerWin()
	{
		isWalking = false;
	}
	
	// public void PlayerDie(){
	// 	isWalking = false;
	// }
}
