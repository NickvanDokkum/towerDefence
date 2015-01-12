using UnityEngine;
using System.Collections;

public class MainCity : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Globals.BaseLives <= 0)
		{
			Debug.Log("Hey, congratz. your base was just destroyed");
		}
	
	}
}
