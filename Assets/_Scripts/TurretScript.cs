using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretScript : MonoBehaviour {

	public static TurretScript singleton;
	
	public GameObject myProjectile;
	public float reloadTime = 3f;
	public float reloadTimeReset = 3;
	//public float timeBetweenFires = 0.1f;
	//public uint rapidFireAmount = 2;
	public Transform spawnPos;
	
	public Transform myTarget = null;

	public List<Transform> blueEnemyList = new List<Transform>();
	public List<Transform> redEnemyList = new List<Transform>();

	private Quaternion desiredRotation;

	public turret2Controller otherScript;

	private float fire = 0;
	public float fireReset = 2.31f;
	private bool fired = true;

	void Start () {
		fire = fireReset;
		otherScript = GameObject.FindObjectOfType(typeof(turret2Controller)) as turret2Controller;
	}

	void Update () {
		if(Input.GetKeyDown("f")){
			if(!Globals.focusTank){
				Globals.focusTank = true;
			}
			else if (Globals.focusTank) {
				Globals.focusTank = false;
			}
			Debug.Log(Globals.focusTank);
		}
		if(Globals.focusTank){
			if(blueEnemyList.Count > 0)
			{
				if(blueEnemyList[0] == null)
				{
					blueEnemyList.Remove (blueEnemyList[0]);
				}
				if(blueEnemyList.Count > 0){
					myTarget = blueEnemyList[0].transform;
				}
				else {
					myTarget = null;
				}
			}
			else if(redEnemyList.Count > 0)
			{
				if(redEnemyList[0] == null)
				{
					redEnemyList.Remove (redEnemyList[0]);
				}
				if(redEnemyList.Count > 0){
					myTarget = redEnemyList[0].transform;
				}
				else {
					myTarget = null;
				}
			}
			else
			{
				myTarget = null;
			}
		}
		else {
			if(redEnemyList.Count > 0)
			{
				if(redEnemyList[0] == null)
				{
					redEnemyList.Remove (redEnemyList[0]);
				}
				if(redEnemyList.Count > 0){
					myTarget = redEnemyList[0].transform;
				}
				else {
					myTarget = null;
				}
			}
			else if(blueEnemyList.Count > 0)
			{
				if(blueEnemyList[0] == null)
				{
					blueEnemyList.Remove (blueEnemyList[0]);
				}
				if(blueEnemyList.Count > 0){
					myTarget = blueEnemyList[0].transform;
				}
				else {
					myTarget = null;
				}
			}
			else
			{
				myTarget = null;
			}
		}

		if (myTarget!=null)
		{
			transform.LookAt(myTarget);   

			if(reloadTime <= 0)
			{
				fired = false;
				reloadTime = reloadTimeReset;
			}
			else
			{
				reloadTime -= Time.deltaTime;
			}
		}
		if(fired == false){
			if(fire <= 0){
				fired = true;
				FireProjectile();
			}
			else{
				if(fire == fireReset){
					otherScript.Shoot();
				}
				fire -= Time.deltaTime;
			}
		}
		/*if (Globals.roundActive == false && collider.enabled == true) 
			collider.enabled = false;
		else if(Globals.roundActive == true && collider.enabled == false) 
			collider.enabled = true;*/
	}
	
	void OnTriggerEnter(Collider other){
		
		if (other.gameObject.tag == "Enemy1")
		{
			redEnemyList.Add (other.gameObject.transform);
		}
		if (other.gameObject.tag == "Enemy2")
		{
			blueEnemyList.Add (other.gameObject.transform);
		}
	}
	
	void OnTriggerExit(Collider other){
		
		if (other.gameObject.transform == myTarget)
		{
			myTarget = null;   
		}
		if (other.gameObject.tag == "Enemy1")
		{
			redEnemyList.Remove (other.gameObject.transform);
		}
		if (other.gameObject.tag == "Enemy2")
		{
			blueEnemyList.Remove (other.gameObject.transform);
		}
	}
	
	
	void FireProjectile(){
		fire = fireReset;
		Instantiate (myProjectile, spawnPos.transform.position, gameObject.transform.rotation);
	}
}