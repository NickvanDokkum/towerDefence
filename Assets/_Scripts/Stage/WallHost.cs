using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallHost : MonoBehaviour {

	public Transform[] walls;

	private bool _OnHover = false;
	private int currentWallLevel = 0;
	private bool BuildAble = true;
	public List<int> wallYPos = new List<int>();

	
	// Use this for initialization
	void Start () 
	{
		//Hoe zet je dit object in een leeg game object?
		Transform trans = (Transform)Instantiate (walls [0], new Vector3 (transform.position.x, 0.55f, transform.position.z), Quaternion.Euler(0,0,0));//transform.rotation);
		trans.parent = transform;
		currentWallLevel++;
	}

	//kijkt of de muis op het object is
	void OnMouseEnter()
	{
		_OnHover = true;
		Debug.Log ("hover");
	}

	void OnMouseExit()
	{
		_OnHover = false;
	}


	// Update is called once per frame
	void Update () 
	{
		//kijkt of je een object kan upgraden
		if (Input.GetKeyUp (KeyCode.U) && BuildAble) 
		{
			Debug.Log("Buildable? " + BuildAble + walls.Length + currentWallLevel);
			if (_OnHover)
			{
				if(currentWallLevel <= walls.Length)
				{
					if(Globals.BuildMode)
					{
						removeOldChild();

						Transform trans = (Transform)Instantiate(walls[currentWallLevel], new Vector3(transform.position.x,wallYPos[currentWallLevel],transform.position.z), Quaternion.Euler(90,0,0));
						trans.parent = transform;
						currentWallLevel++;
						print(currentWallLevel);

						if(currentWallLevel == walls.Length)
						{
							BuildAble = false;
						}
					}
				}
			}
		}
	}
	void removeOldChild()
	{
		GameObject.Destroy (transform.GetChild (0).gameObject);
	}
}
