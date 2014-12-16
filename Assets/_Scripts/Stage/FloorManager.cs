﻿using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

	private int rows = Globals.rows;
	private int lines = Globals.lines;
	public Transform Floor;
	public Transform Tree;

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

				if(i < 3 || j < 4 || i > lines - 4 || j > rows - 4)
				{
					Transform tree = (Transform)Instantiate(Tree, new Vector3(Random.Range(1, 9) + i * 10, 3f, Random.Range(1, 9) + j * 10),Quaternion.Euler(0,Random.Range(1,360),0));
					tree.parent = transform;
				}
			}
		}
	}

	void Update()
	{
		//zet de build mode aan of uit(voor alle scripts)
		if(Input.GetKeyUp(KeyCode.B))
		{
			if (Globals.BuildMode) 
				Globals.BuildMode = false;
			else
				Globals.BuildMode = true;
		}
	}
}
