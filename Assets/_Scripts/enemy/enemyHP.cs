using UnityEngine;
using System.Collections;

public class enemyHP : MonoBehaviour {

	private int HP = 100;
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "BulletDamage")
		{
			HP -= 50;
		}
		else if (other.gameObject.tag == "BulletFast")
		{
			HP -= 10;
		}
		else if (other.gameObject.tag == "BulletNorm")
		{
			HP -= 25;
		}
		Destroy (other.gameObject);
		if(HP < 0) {
			Destroy (gameObject);
		}
	}
}
