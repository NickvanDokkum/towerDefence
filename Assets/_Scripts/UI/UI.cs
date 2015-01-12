using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour 
{
	public void MainMenu()
	{
		Debug.Log ("test1");
		Application.LoadLevel (0);
	}
	public void StartGame()
	{
		Debug.Log("test2");

		Application.LoadLevel (1);
	}
	public void QuitGame()
	{
		Debug.Log ("test3");

		Application.Quit();
	}

}