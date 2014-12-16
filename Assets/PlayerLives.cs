using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour {

	private Vector3 v3pos = Vector3.zero;

	void Start()
	{
		v3pos = new Vector3 (0.15f,0.8f,0.8f);
	}

	void Update () 
	{
		transform.position = Camera.main.ViewportToWorldPoint (v3pos);
//		transform.rotation = Camera.main.ViewportToWorldPoint (v3pos);
	}
}
