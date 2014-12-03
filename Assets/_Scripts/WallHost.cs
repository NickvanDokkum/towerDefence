using UnityEngine;
using System.Collections;

public class WallHost : MonoBehaviour {

	public Transform[] walls;

	private bool _OnHover = false;
	private int currentWallLevel = 0;

	// Use this for initialization
	void Start () 
	{
		Transform trans = (Transform)Instantiate(walls[0], new Vector3(transform.position.x,0.55f,transform.position.z), transform.rotation);
		trans.parent = transform;
	}

	//kijkt of de muis op het object is
	void OnMouseEnter()
	{
		_OnHover = true;
	}

	void OnMouseExit()
	{
		_OnHover = false;
	}


	// Update is called once per frame
	void Update () 
	{
		Debug.Log (_OnHover);

		//kijkt of je een object kan upgraden
		if (Input.GetKeyUp (KeyCode.B)) 
		{
			if (_OnHover)
			{
				if(currentWallLevel < walls.Length)
				{
					if (GameObject.Find ("Floor").GetComponent<FloorManager> ().BuildMode) 
					{
						currentWallLevel++;
						var go = Instantiate(walls[currentWallLevel], new Vector3(transform.position.x,0.55f,transform.position.z), transform.rotation);
					}
				}
			}
		}
	}
}
