using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class turretHPScript : MonoBehaviour {

	private int HP;
	private bool activeHP = false;
	private List<Transform> enemies = new List<Transform>();

	void Start () {
		if(this.gameObject.tag == "turret"){
			HP = 10;
			activeHP = true;
		}
	}

	void OnCollisionEnter(Collision hit){
		//enemies.Add (hit.gameObject);
	}

	void OnCollisionStay(Collision hit){
		if (hit.gameObject.tag == "Enemy2") {
			HP -= 2;
		}
		else if (hit.gameObject.tag == "Enemy1") {
			HP -= 1;
		}
		if (HP <= 0) {
			Destroy(this.gameObject);
		}
	}
}
