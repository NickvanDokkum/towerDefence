using UnityEngine;
using System.Collections;

public class GoldScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter(Collision col)
	{
		print("Col. coin");
		if(col.gameObject.tag == "Player")
		{
			Globals.Gold += 9 + Globals.waveNumber;
			Destroy(col.gameObject);
		}
	}
}
