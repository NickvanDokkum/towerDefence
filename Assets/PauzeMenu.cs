using UnityEngine;
using System.Collections;

public class PauzeMenu : MonoBehaviour {

	private Rect pauzePopup = new Rect(Screen.width/2 - 200,300,400,100);

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(Input.GetKeyUp(KeyCode.P) && !Globals.paused)
			Globals.paused = true;
		else if(Input.GetKeyUp(KeyCode.P) && Globals.paused)
			Globals.paused = false;

		if (Globals.paused)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}

	void OnGUI()
	{
		if(Globals.paused)
		{
			pauzePopup = GUI.Window(1, pauzePopup, PauzeGUI, "Game is on pauze");
		}
	}

	void PauzeGUI(int windowID)
	{
		if(GUILayout.Button("Continue"))
		{
			Globals.paused = false;
		}
		if(GUILayout.Button("Main menu(Q voor nick)"))
		{
			Application.LoadLevel(0);
		}
	}
}
