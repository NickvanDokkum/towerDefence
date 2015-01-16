using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class frameChecker : MonoBehaviour {

	private float time;
	public bool moving = false;
	public fastEnemyScript otherScript;
	private bool walking = true;
	public int HP = 100;
	public GameObject coin;
	public bool dieing = false;
	private float timer;
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "BulletDamage")
		{
			HP -= 50;
			Destroy(other.gameObject);
		}
		else if (other.gameObject.tag == "BulletFast")
		{
			HP -= 10;
			Destroy(other.gameObject);
		}
		else if (other.gameObject.tag == "BulletNorm")
		{
			HP -= 25;
			Destroy(other.gameObject);
		}
		else if (other.gameObject.tag == "BulletSlow")
		{
			HP -= 15;
			Destroy(other.gameObject);
		}
		if(HP <= 0) {
			Globals.Score += 9 + Globals.waveNumber;
			dieing = true;
			Dieing();
		}
	}

	void Start (){
		otherScript = GameObject.FindObjectOfType(typeof(fastEnemyScript)) as fastEnemyScript;
	}
	
	void Update () {
		if(dieing == true){
			timer = animation["enemy_death"].time;
			print(timer);
			if(timer >= animation["enemy_death"].length){
				int coinsTotal = Random.Range(0,4);
				for(int i = 0; i < coinsTotal; i++)
				{
					Instantiate(coin, new Vector3(transform.position.x + Random.Range(-2,2),transform.position.y,transform.position.z + Random.Range(-2,2)),Quaternion.identity);
				}
				Destroy (gameObject);
				Destroy(this);
			}
		}
		else if(walking == true){
			time = animation["enemy_walk"].time;
			if(time >= 1.5){
				animation["enemy_walk"].time = 0;
			}
			if(time >= 0.15 && time <= 1.0){
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
	public void Walking(){
		walking = true;
		animation.Stop ();
		animation.Play ("enemy_walk");
	}
	public void Attacking(){
		walking = false;
		animation.Stop ();
		animation.Play ("enemy_attack");
	}
	public void Dieing(){
		walking = false;
		animation.Stop ();
		animation.Play ("enemy_death");
	}
}
