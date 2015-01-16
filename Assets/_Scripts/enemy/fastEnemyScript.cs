using UnityEngine;
using System.Collections;

public class fastEnemyScript : MonoBehaviour {

	private float timer = 0.25f;
	private bool slowed = false;
	public float slowSpeed = 2.5f;
	private float lastPos;
	private float lastPos2;
	private float lastPos3;
	private float posMoved;
	public bool attacking = false;
	public bool attack = false;
	private float slowTimer = 3;
	public float moveSpeed = 4;
	private NavMeshAgent agent;
	[SerializeField]
	private GameObject target;
	private bool repath = false;
	private bool move = false;
	public frameChecker otherScript;
	private bool dead = false;

	void Start () {
		otherScript = GameObject.FindObjectOfType(typeof(frameChecker)) as frameChecker;
		target = Globals.end;
		agent = GetComponent<NavMeshAgent> ();
		agent.SetDestination (target.transform.position);
		repath = true;
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
		if(lastPos < 5){
			Globals.BaseLives -= 50;
			Destroy(gameObject);
			Destroy(this);
		}
		if(dead == false){
			if(move == true){
				lastPos3 = lastPos2;
				lastPos2 = lastPos;
				var vectorToTarget = target.transform.position - transform.position;
				vectorToTarget.y = 0;
				lastPos = vectorToTarget.magnitude;
				posMoved = lastPos - lastPos3;
				if(attack == false && move == true){
					if(posMoved < 0.001 && posMoved > -0.001){
						agent.speed = 0;
						attacking = true;
						otherScript.Attacking();
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
				if(timer <= 0){
					transform.LookAt (target.transform);
					if(timer < -0.125f){
						timer = 0.25f;
						attacking = false;
						otherScript.Walking();
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
					timer -= Time.deltaTime;
				}
			}
		}
	}
	public void startMove (){
		move = true;
		if(slowed == false){
			agent.speed = 5;
		}
		else{
			agent.speed = slowSpeed;
		}
	}
	public void stopMove(){
		move = false;
		agent.speed = 0;
	}
	public void death(){
		dead = true;
		agent.speed = 0;
	}
}
