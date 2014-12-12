using UnityEngine;
using System.Collections;

public class WallHost : MonoBehaviour {

	public Transform[] walls;

	private bool _OnHover = false;
	private int currentWallLevel = 0;

	// Use this for initialization
	void Start () 
	{
		//Hoe zet je dit object in een leeg game object?
		Transform trans = (Transform)Instantiate (walls [0], new Vector3 (transform.position.x, 0.55f, transform.position.z), Quaternion.Euler(270,0,0));//transform.rotation);
		trans.localScale += new Vector3(2.76f,0,0);
		trans.parent = transform;
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
		if (Input.GetKeyUp (KeyCode.B)) 
		{
			Debug.Log("test1");
			if (_OnHover)
			{
				Debug.Log("test2");
				if(currentWallLevel < walls.Length)
				{
					if(GameObject.Find("Floor").GetComponent<FloorManager>().BuildMode)
					{
						removeOldChild();

						currentWallLevel++;
						Transform trans = (Transform)Instantiate(walls[currentWallLevel], new Vector3(transform.position.x,1f,transform.position.z), Quaternion.Euler(270,0,0));
						trans.localScale = new Vector3(1.6f,1,1);
						trans.parent = transform;
					}
				}
			}
		}
	}
	void removeOldChild()
	{
		Transform trans = this.transform.GetChild(currentWallLevel);
		trans.transform.parent = null;

		Destroy ((trans as Transform).gameObject);
	}
}
