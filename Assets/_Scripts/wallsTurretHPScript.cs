using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class wallsTurretHPScript : MonoBehaviour {

	private int HP;
	private bool activeHP = false;
	private List<Transform> enemies = new List<Transform>();

	void Start () {
		if(this.gameObject.tag == "Wall"){
			HP = 10;
			activeHP = true;
		}
		else if(this.gameObject.tag == "Turret"){
			HP = 10;
			activeHP = true;
		}
	}

	void OnCollisionEnter(Collision hit){
		//enemies.Add (hit.gameObject);
	}

	void OnCollisionStay(Collision hit){
		if (hit.gameObject.tag == "Enemy2") {
			HP -= 10;
		}
		else if (hit.gameObject.tag == "Enemy1") {
			HP -= 5;
		}
		if (HP <= 0) {
			Destroy(this.gameObject);
		}
	}
}
