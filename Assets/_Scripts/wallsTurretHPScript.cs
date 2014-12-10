using UnityEngine;
using System.Collections;

public class wallsTurretHPScript : MonoBehaviour {

	private int HP;
	private bool activeHP = false;

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

	void OnCollisionEnter(UnityEngine.Collision hit){
		if (activeHP == true) {
			if (hit.gameObject.tag == "Enemy2") {
				HP -= 10;
			} else if (hit.gameObject.tag == "Enemy1") {
				HP -= 5;
			}
			if (HP <= 0) {
				//do your thing here, koen
				Destroy(this.gameObject);
				Destroy(this);
			}
		}
	}
}
