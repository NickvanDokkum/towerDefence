using UnityEngine;
using System.Collections;

public class InGameUI : MonoBehaviour {

	private Rect UpgradePopUp = new Rect(1280/2 - 200,720-100,400,100);
	private bool BuildMode = false;

	void Update()
	{
		//wissel van build mode
		if(Input.GetKeyUp(KeyCode.Space))
		{
			if (BuildMode) 
				BuildMode = false;
			else
				BuildMode = true;
		}
	}

	void OnGUI()
	{
		GUI.Label (new Rect (100, 50, 200, 50), "You have currently: " + Globals.Gold + " Gold");
		GUI.Label (new Rect (100, 75, 200, 50), "your current score: " + Globals.Score);
		GUI.Label (new Rect (100, 100, 200, 50), "your base has: " + Globals.BaseLives + "lives");
		GUI.Label (new Rect (100, 125, 200, 50), "your player has: " + Globals.PlayerLives + "lives");


	}
}
