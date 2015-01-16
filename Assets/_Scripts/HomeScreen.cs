using UnityEngine;
using System.Collections;

public class HomeScreen : MonoBehaviour {

	public bool gameStarted = false;
	private bool animationStarted = false;
	
	// Update is called once per frame
	void Update () 
	{
		if(!animation.isPlaying )
		{
			if(gameStarted == false)
			{
				animation.Play ("CastleAnimation");
				animation["CastleAnimation"].speed = 0.5f;
			}
			if(gameStarted == true)
			{
				if(animationStarted == false)
				{
					animation.Play("startGame");
					animationStarted = true;
				}
				else
					Application.LoadLevel(1);
			}
		}
		else if(gameStarted == true)
		{
			animation["CastleAnimation"].speed = 2f;
		}
	}

	public void startGame()
	{
		gameStarted = true;
	}
}
