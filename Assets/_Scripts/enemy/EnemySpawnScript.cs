using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

	public GameObject EnemyFast;
	public GameObject EnemyStrong;
	private float spawnTimer;
	public float timeReset = 3;
	private float enemyNum;

	void Start () {
		spawnTimer = timeReset;
	}

	void Update () {
		if(Globals.roundActive == true) {
			if (spawnTimer < 0){
				enemyNum = Random.Range(0, 2);
				if(enemyNum == 1){
					Instantiate (EnemyFast, this.transform.position, this.transform.rotation);
				}
				else {
					Instantiate (EnemyStrong, this.transform.position, this.transform.rotation);
				}
				spawnTimer = timeReset;
			}
			else {
				spawnTimer -= Time.deltaTime;
			}
		}
	}
}
