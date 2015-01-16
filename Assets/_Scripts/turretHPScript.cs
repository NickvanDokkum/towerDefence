using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class turretHPScript : MonoBehaviour {
	
	public TurretScript otherScript;
	private int HP;
	private bool activeHP = false;

	void Start () {
		if(this.gameObject.tag == "Turret"){
			HP = 10;
			otherScript = GameObject.FindObjectOfType(typeof(TurretScript)) as TurretScript;
		}
	}

	void OnCollisionEnter(Collision hit){
		//enemies.Add (hit.gameObject);
	}

	void OnCollisionStay(Collision hit){
		if (hit.gameObject.tag == "Enemy2") {
			if(hit.gameObject.GetComponent<fastEnemyScript>().attack == true){
				HP -= 1;
			}
		}
		else if (hit.gameObject.tag == "Enemy1") {
			HP -= 2;
		}
		if (HP <= 0) {
			Destroy(this.gameObject);
		}
	}
}
