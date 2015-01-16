using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallHost : MonoBehaviour {

	public Transform[] walls;
	private bool _OnHover = false;
	private int currentWallLevel = 0;
	private int damages;
	private bool BuildAble = true;


	// Use this for initialization
	void Start () 
	{
		Globals.Gold += 3000;

		//Hoe zet je dit object in een leeg game object?
		Transform trans = (Transform)Instantiate (walls [0], new Vector3 (transform.position.x + 5, -0.5f, transform.position.z), Quaternion.Euler(0,0,0));//transform.rotation);
		trans.parent = transform;
		currentWallLevel++;
	}

	// Update is called once per frame
	void Update () 
	{
		//kijkt of je een object kan upgraden
		if (Input.GetKeyUp (KeyCode.U) && BuildAble) 
		{
			if (_OnHover)
			{
				if(currentWallLevel <= walls.Length)
				{
					if(Globals.BuildMode && Globals.price <= Globals.Gold)
					{
						removeOldChild();

						if(currentWallLevel == 1)
						{
							Transform trans = (Transform)Instantiate(walls[currentWallLevel], new Vector3(transform.position.x + 2.43f,-0.5f,transform.position.z), Quaternion.Euler(0,0,0));
							trans.parent = transform;
						}

						if(currentWallLevel == 2)
						{
							Transform trans1 = (Transform)Instantiate(walls[currentWallLevel], new Vector3(transform.position.x,4.5f,transform.position.z), Quaternion.Euler(0,0,0));
							trans1.parent = transform;
						}


						currentWallLevel++;

						Globals.Gold -= Globals.price;
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

	//kijkt of de muis op het object is
	void OnMouseOver()
	{
		_OnHover = true;
		if(BuildAble)
		{
			Globals.upgradeShow = true;
			Globals.price = 50 * currentWallLevel * 10;
		}
		Debug.Log (Globals.price + " / " + Globals.Gold);
	}
	
	void OnMouseExit()
	{
		_OnHover = false;
		Globals.upgradeShow = false;
	}
}