using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

	public GameObject EnemyFast;
	public GameObject EnemyStrong;
	private float spawnTimer;
	private float timeReset = 3;
	private float enemyNum;
	public bool spawnable = true;

	void Start () {
		spawnTimer = timeReset;
	}

	void Update () {
		if(spawnable == true) {
			if (spawnTimer < 0){
				enemyNum = Random.Range(0, 1);
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
