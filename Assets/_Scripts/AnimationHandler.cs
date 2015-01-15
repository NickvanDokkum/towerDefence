using UnityEngine;
using System.Collections;

public class AnimationHandler : MonoBehaviour {

	public int neededFocus;
	private bool cameraActive = false;

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonUp(0) && Globals.CurrentFocus == neededFocus && !animation.isPlaying)
		{
			if(neededFocus == 1)
			{
				animation.Play();
			}
			//--------------------
			if(neededFocus == 2)
			{
				if(cameraActive == false)
				{
					animation.Play("CameraSwitch");
					cameraActive = true;
				}
				else
				{
					animation.Play("CameraBack");
					cameraActive = false;
				}
			}
		}
	}
}