using UnityEngine;
using System.Collections;

public class PauzeMenu : MonoBehaviour {

	//private Rect pauzePopup = new Rect(Screen.width/2 - 200,300,400,100);
	
	void Update () 
	{

		if(Input.GetKeyUp(KeyCode.P) && !Globals.paused)
		{
			Globals.paused = true;
			Time.timeScale = 0;
			gameObject.GetComponent<CanvasGroup>().alpha = 1f;
		}
		else if(Input.GetKeyUp(KeyCode.P) && Globals.paused)
		{
			Globals.paused = false;
			Time.timeScale = 1;
			gameObject.GetComponent<CanvasGroup>().alpha = 0f;
		}
	}

	/*void OnGUI()
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
	}*/
}
