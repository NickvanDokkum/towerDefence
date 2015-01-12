using UnityEngine;
using System.Collections;

public class strongEnemyScript : MonoBehaviour {

	public GameObject target;
	private float timer = 0.25f;
	private float slowTimer = 3;
	private bool slowed = false;
	public int slowSpeed = 2;
	public int moveSpeed = 4;
	private bool attacking = false;
	private int wallHP;
	private float dist;
	private bool targReach = false;

	void Start () {
		target = Globals.end;
		if(target != null){
			transform.LookAt (target.transform);
		}
	}
	void Update () {
		if(target == null){
			target = Globals.end;
		}
		else{
			dist = Vector3.Distance(target.transform.position, this.transform.position);
			if(dist < 1){
				targReach = true;
			}
		}
		if(targReach == false){
			if(attacking == false){
				if(slowed == false){
					transform.Translate (Vector3.forward*moveSpeed / 50);
				}
				else {
					transform.Translate (Vector3.forward*moveSpeed / 75);
					slowTimer -= Time.deltaTime;
					if(slowTimer <= 0){
						slowed = false;
					}
				}
			}
			else {
				//print(timer);
				//attack animation
				if(timer <= 0){
					transform.Translate (Vector3.forward*moveSpeed / 50);
					attacking = false;
					timer = 0.25f;
					transform.LookAt (target.transform);
				}
				else {
					transform.Translate (Vector3.back*moveSpeed / 100);
					timer -= Time.deltaTime;
				}
			}
		}
	}
	void OnTriggerEnter(Collider other){
		if(other.collider.tag == "BulletSlow"){
			Slow();
		}
	}
	void Slow () {
		moveSpeed = slowSpeed;
		slowTimer = 3;
		slowed = true;
	}
	private string hitobject;
	
	void OnCollisionEnter(UnityEngine.Collision hit){
		hitobject = hit.gameObject.tag;
		if(hitobject == "Turret") {
			//print ("potato");
			attacking = true;
		}
	}
	/*void OnCollisionExit (UnityEngine.Collision hit){
		hitobject = hit.gameObject.tag;
		if(hitobject == "Turret"){
			//print("lemon");
		}
	}*/
}
