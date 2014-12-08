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
		UpgradePopUp = GUI.Window (0, UpgradePopUp, UpgradeMenuFunction, "Upgrades");
	}
	
	void UpgradeMenuFunction(int windowID)
	{
		//wall
		if(GUI.Button(new Rect(25,30,50,50),"test"))
		{
		}

		//turret 1
		if(GUI.Button(new Rect(125,30,50,50),"test"))
		{
		}

		//turret 2
		if(GUI.Button(new Rect(225,30,50,50),"test"))
		{
		}

		//turret 3
		if(GUI.Button(new Rect(325,30,50,50),"test"))
		{
		}
	}
}
