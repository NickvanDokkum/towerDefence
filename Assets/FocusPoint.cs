using UnityEngine;
using System.Collections;

public class FocusPoint : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float mouseScroll = Mathf.Floor(Input.GetAxis ("Mouse ScrollWheel") * 100);

		if(mouseScroll >= 0)
		{
			Globals.CurrentFocus += 1;
			if(Globals.CurrentFocus > 6)
				Globals.CurrentFocus = 1;
			Debug.Log(Globals.CurrentFocus);
			moveScrollBar();
		}
		if(mouseScroll <= 0)
		{
			Globals.CurrentFocus -= 1;
			if(Globals.CurrentFocus < 1)
				Globals.CurrentFocus = 6;
			Debug.Log(Globals.CurrentFocus);
			moveScrollBar();
		}
	}

	void moveScrollBar()
	{
		transform.position = new Vector3(290 + Globals.CurrentFocus * 100,50,0);
	}
}