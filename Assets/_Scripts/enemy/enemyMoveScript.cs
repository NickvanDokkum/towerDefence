using UnityEngine;
using System.Collections;

public class enemyMoveScript : MonoBehaviour {

	private float timer = 3;
	private bool slowed = false;

	private NavMeshAgent agent;
	[SerializeField]
	private GameObject target;

	void Start () {
		target = Globals.end;
		agent = GetComponent<NavMeshAgent> ();
		agent.SetDestination (target.transform.position);
	}
	void OnTriggerEnter(Collider other){
		if(other.collider.tag == "BulletSlow"){
			Slow();
		}
	}
	void Slow () {
		agent.speed = 3;
		timer = 3;
		slowed = true;
	}
	void Update () {
		if(slowed == true){
			if(timer <= 0){
				agent.speed = 5;
			}
			else {
				timer -= Time.deltaTime;
			}
		}
	}
}
