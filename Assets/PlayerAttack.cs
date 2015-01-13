using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	// Use this for initialization
	void Awake () 
	{
		animation.Stop ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.Z) && !animation.isPlaying)
		{
			animation.Play();
		}
	}
}