using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	UnityEngine.AI.NavMeshAgent navigationAgent;
	Animator animator;
	float baseSpeed, baseAcceleration;

	// Use this for initialization
	void Start () {
		navigationAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		animator = GetComponent<Animator> ();
		baseSpeed = navigationAgent.speed;
		baseAcceleration = navigationAgent.acceleration;
	}

	public void CancelPowerUp(PowerupType type)
	{
		switch (type)
		{
			case PowerupType.SpeedBoost:
				navigationAgent.speed = baseSpeed;
				break;
			case PowerupType.AccelerationBoost:
				navigationAgent.acceleration = baseAcceleration;
				break;
		}	
	}

	public void ApplyPowerUp(PowerupType type, float duration)
	{
		switch (type)
		{
			case PowerupType.SpeedBoost:
				StartCoroutine(SpeedBoost(duration, 3.5f));
				break;
		}
	}

	IEnumerator SpeedBoost(float duration, float multiplier)
	{
		navigationAgent.speed = baseSpeed * multiplier;
		yield return new WaitForSeconds(duration);
		navigationAgent.speed = baseSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMove ();

		if (animator) {
			float v = navigationAgent.velocity.x;
			if (v != 0){
				animator.SetBool("Moving",true);
			}else{
				animator.SetBool("Moving",false);
			}
		}
	}

	void PlayerMove (){
		if (Input.GetMouseButtonUp (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//Debug.Log(ray);

			if(Physics.Raycast(ray, out hit, 500)){
				//Debug.DrawLine(ray.origin,hit.point,Color.red,1.0f);
				//Debug.Log(hit.point);
				navigationAgent.SetDestination(hit.point);
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Gold") {
			GetComponent<AudioSource>().Play();
		}
	}
}
