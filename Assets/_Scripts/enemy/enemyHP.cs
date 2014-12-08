using UnityEngine;
using System.Collections;

public class enemyHP : MonoBehaviour {

	public int HP = 100;
	
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
		else if (other.gameObject.tag == "BulletSlow")
		{
			HP -= 15;
		}
		if(HP <= 0) {
			Globals.Gold += 9 + Globals.waveNumber;
			Destroy (gameObject);
			Destroy(this);
		}
	}
}
