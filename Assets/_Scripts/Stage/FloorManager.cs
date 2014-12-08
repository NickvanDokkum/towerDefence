using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

	private int rows = 25;
	private int lines = 25;
	public Transform Floor;
	public bool BuildMode = false;
	
	// Use this for initialization
	void Awake () 
	{
		Globals.Gold = 300;
		//maakt een veld aan van het aantal rows x het aantal lines
		for(int i = 0;i < lines; i++)
		{
			for(int j = 0; j < rows; j++)
			{
				Transform trans = (Transform)Instantiate(Floor, new Vector3(i*10f, -0.5f,j*10f), transform.rotation);
				trans.parent = transform;
			}
		}
	}

	void Update()
	{
		//zet de build mode aan of uit(voor alle scripts)
		if(Input.GetKeyUp(KeyCode.Space))
		{
			Debug.Log(BuildMode);
			if (BuildMode) 
				BuildMode = false;
			else
				BuildMode = true;
		}
	}
}
