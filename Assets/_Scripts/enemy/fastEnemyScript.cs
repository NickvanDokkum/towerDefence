using UnityEngine;
using System.Collections;

public class fastEnemyScript : MonoBehaviour {

	private float timer = 0.25f;
	private bool slowed = false;
	public float slowSpeed = 2.5f;
	private float lastPos;
	private float lastPos2;
	private float posMoved;
	public bool attacking = false;
	public bool attack = false;
	private float slowTimer = 3;
	public int moveSpeed = 4;
	private NavMeshAgent agent;
	[SerializeField]
	private GameObject target;
	private bool repath = false;

	void Start () {
		if(target == null) {
			target = Globals.end;
		}
		agent = GetComponent<NavMeshAgent> ();
		if(target != null){
			agent.SetDestination (target.transform.position);
		}
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
		if(target == null) {
			target = Globals.end;
			if(target != null){
				agent.SetDestination (target.transform.position);
			}
		}
		else{
			lastPos2 = lastPos;
			lastPos = Vector3.Distance(target.transform.position, this.transform.position);
			posMoved = lastPos - lastPos2;
			if(attack == false){
				if(posMoved < 0.001 && posMoved > -0.001){
					agent.speed = 0;
					attacking = true;
				}
			}
			else {
				attack = false;
			}
		}
		if(slowed == true){
			if(slowTimer <= 0){
				agent.speed = 5;
			}
			else {
				slowTimer -= Time.deltaTime;
			}
		}
		if(attacking == true){
			//print(timer);
			if(timer <= 0){
				//print("forward");
				transform.LookAt (target.transform);
				//transform.Translate (Vector3.forward*moveSpeed / 50);
				if(timer < -0.125f){
					timer = 0.25f;
					attacking = false;
					repath = true;
					if(slowed == false){
						agent.speed = 5;
					}
					else{
						agent.speed = slowSpeed;
					}
					attack = true;
				}
				else{
					timer -= Time.deltaTime;
				}
			}
			else {
				//print("backwards");
				//transform.Translate (Vector3.back*moveSpeed / 100);
				timer -= Time.deltaTime;
			}
		}
	}
}
