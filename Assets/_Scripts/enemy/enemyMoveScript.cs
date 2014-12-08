using UnityEngine;
using System.Collections;

public class enemyMoveScript : MonoBehaviour {

	private float timer = 3;
	private bool slowed = false;
	public int slowSpeed = 3;

	private NavMeshAgent agent;
	[SerializeField]
	private GameObject target;

	void Start () {
		if(target == null) {
			target = Globals.end;
		}
		agent = GetComponent<NavMeshAgent> ();
		agent.SetDestination (target.transform.position);
	}
	void OnTriggerEnter(Collider other){
		if(other.collider.tag == "BulletSlow"){
			Slow();
		}
	}
	void Slow () {
		agent.speed = slowSpeed;
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
