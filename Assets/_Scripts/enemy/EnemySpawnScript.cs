using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

	public GameObject Enemy;
	private float timer = 3;

	void Update () {
		if(Globals.roundActive == true) {
			if (timer < 0){
				Instantiate (Enemy, this.transform.position, this.transform.rotation);
				timer = 3;
			}
			else {
				timer -= Time.deltaTime;
			}
		}
	}
}
