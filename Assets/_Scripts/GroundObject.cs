using UnityEngine;
using System.Collections;

public class GroundObject : MonoBehaviour {

	private bool _Onhover = false;
	private bool ObjectBuilded = false;
	private bool BuildMode = false;

	public Transform Wall;
	public Transform[] turrets;

	public Material ground;

	void Update()
	{
		//wissel van build mode
		if(Input.GetKeyUp(KeyCode.Space))
		{
			if (BuildMode) 
				BuildMode = false;
			else
				BuildMode = true;
		}

		if (_Onhover) 
		{
			if (ObjectBuilded == false) 
			{
				//start de functies om het gewenste object neer te zetten op de door jou gekoze locatie
				if (Input.GetKeyUp (KeyCode.Alpha1)) 
				{
					buildWall();
					ObjectBuilded = true;
				}
				
				if (Input.GetKeyUp (KeyCode.Alpha2)) 
				{
					buildTurretOne();
					ObjectBuilded = true;
				}
				
				if (Input.GetKeyUp (KeyCode.Alpha3)) 
				{
					buildTurretTwo();
					ObjectBuilded = true;
				}
				
				if (Input.GetKeyUp (KeyCode.Alpha4)) 
				{
					buildTurretThree();
					ObjectBuilded = true;
				}
			}
		}
	}


	void OnMouseEnter()
	{
		if (BuildMode) 
			renderer.material.color = Color.blue;

		_Onhover = true;
	}

	void OnMouseExit()
	{
		// turn the things of on mouse enter off
		renderer.material = ground;

		_Onhover = false;
	}	



	// Functies voor het plaatsen van de objecten
	void buildWall()
	{
		var go = Instantiate(Wall, new Vector3(transform.position.x,0.55f,transform.position.z), transform.rotation);
	}

	void buildTurretOne()
	{
		var go = Instantiate(turrets[0], new Vector3(transform.position.x,0.55f,transform.position.z), transform.rotation);

	}

	void buildTurretTwo()
	{
		Debug.Log ("3");
	}

	void buildTurretThree()
	{
		Debug.Log ("4");
	}
}
