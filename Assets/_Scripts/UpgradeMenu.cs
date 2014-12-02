using UnityEngine;
using System.Collections;

public class UpgradeMenu : MonoBehaviour {

					//screen width en height heeft een rare bug. NAVRAGEN___________________________
	public Rect UpgradePopUp = new Rect(1280/2 - 200,720-100,400,100);
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
