using UnityEngine;
using System.Collections;

public class GroundObject : MonoBehaviour {

	private bool _Onhover = false;
	private bool ObjectBuilded = false;
	
	public Transform Wall;
	public Transform[] turrets;

	public Material ground;

	void Update()
	{
		if (_Onhover && ObjectBuilded == false) 
		{
			if (GameObject.Find("Floor").GetComponent<FloorManager>().BuildMode) 
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
				if (Input.GetKeyUp (KeyCode.Alpha5)) 
				{
					buildTurretFour();
					ObjectBuilded = true;
				}
			}
		}
	}


	//checkt of de muis op een plane staat en maakt de acties die hierbij horen mogelijk
	void OnMouseEnter()
	{
		if (GameObject.Find("Floor").GetComponent<FloorManager>().BuildMode) 
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
		var go = Instantiate(turrets[1], new Vector3(transform.position.x,0.55f,transform.position.z), transform.rotation);
	}

	void buildTurretThree()
	{
		var go = Instantiate(turrets[2], new Vector3(transform.position.x,0.55f,transform.position.z), transform.rotation);
	}

	void buildTurretFour()
	{
		var go = Instantiate(turrets[3], new Vector3(transform.position.x,0.55f,transform.position.z), transform.rotation);
	}
}
