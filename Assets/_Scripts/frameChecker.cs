﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class frameChecker : MonoBehaviour {

	private float time;
	public bool moving = false;
	public fastEnemyScript otherScript;

	void Start (){
		otherScript = GameObject.FindObjectOfType(typeof(fastEnemyScript)) as fastEnemyScript;
	}

	void Update () {
		time = animation["C4D Animation Take"].time;
		if(time > 1.5){
			animation["C4D Animation Take"].time = 0;
		}
		if(time >= 0.1 && time <= 1.167){
			if(moving == false){
				otherScript.startMove();
				moving = true;
			}
		}
		else {
			if(moving == true){
				otherScript.stopMove();
				moving = false;
			}
		}
	}
}