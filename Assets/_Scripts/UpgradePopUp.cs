using UnityEngine;
using System.Collections;

public class UpgradePopUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Globals.upgradeShow)
			gameObject.GetComponent<CanvasGroup>().alpha = 1f;
		else
			gameObject.GetComponent<CanvasGroup>().alpha = 0f;
	}
}
