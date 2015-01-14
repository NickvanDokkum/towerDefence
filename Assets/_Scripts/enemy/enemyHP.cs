using UnityEngine;
using System.Collections;

public class enemyHP : MonoBehaviour {

	public int HP = 100;
	public GameObject coin;


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
			Globals.Score += 9 + Globals.waveNumber;
			int coinsTotal = Random.Range(1,3);
			for(int i = 0; i < coinsTotal; i++)
			{
				Instantiate(coin, new Vector3(transform.position.x + Random.Range(-5,5),transform.position.y,transform.position.z + Random.Range(-5,5)),Quaternion.identity);
			}
			Destroy (gameObject);
			Destroy(this);
		}
	}
}
