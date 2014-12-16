using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	private bool howToPlay = false;

	void OnGUI()
	{
		if(GUI.Button(new Rect(100,100,100,100), "Start Game"))
		{
			Application.LoadLevel(1);
		}

		if(GUI.Button(new Rect(200,200,100,100), "How To Play"))
		{
			if (!howToPlay)
				howToPlay = true;
			else
				howToPlay = false;
		}

		GUI.Label (new Rect (400, 400, 100, 100), "HighScore: 15740");

		if(howToPlay)
		{
			GUI.BeginGroup(new Rect(500,500,500,500));
			GUILayout.Label("Druk op spatie om in de buildmode te komen en je objecten kan bouwen");
			GUILayout.Label("Plaats je gebouwen met de nummers 1 tot en met 5");
			GUILayout.Label("Verdedig je basis door middel van het bouwen van torens op de juiste plekken");
			GUI.EndGroup();
		}
	}
}

