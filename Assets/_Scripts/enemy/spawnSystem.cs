using UnityEngine;
using System.Collections;

public class spawnSystem : MonoBehaviour {

	private int spawnPoint;
	private EnemySpawnScript spawnScript;
	public GameObject[] spawnPoints;
	private float timer = 30;
	public float resetTimer = 150;
	private bool buildtime = true;

	void Start () {
		Globals.BuildMode = true;
	}
	void Update () {
		if(timer <= 30 && buildtime == false){
			Globals.BuildMode = true;
			buildtime = true;
		}
		else if(timer <= 0){
			timer = resetTimer;
			buildtime = false;
			Globals.BuildMode = false;
			spawnPoint = Random.Range(-1,spawnPoints.Length);
			spawnScript = spawnPoints [spawnPoint].GetComponent<EnemySpawnScript> ();
			spawnScript.spawnable = true;
			print(spawnPoint);
		}
		timer -= Time.deltaTime;
	}
}
