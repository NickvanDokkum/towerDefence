using UnityEngine;
using System.Collections;

public class GroundObject : MonoBehaviour {

	private bool _Onhover = false;
	private bool ObjectBuilded = false;
	
	//public Transform Wall;
	//public Transform[] turrets;
	public Transform[] buildAbleObjects;
	private int objectNumber;
	public Material ground;
	

	void Update()
	{
		if (_Onhover && ObjectBuilded == false) 
		{
			if(GameObject.Find("Floor").GetComponent<FloorManager>().BuildMode)
			{
				Debug.Log(GameObject.Find("Floor").GetComponent<FloorManager>().BuildMode);
				//start de functies om het gewenste object neer te zetten op de door jou gekoze locatie
				if (Input.GetKeyUp (KeyCode.Alpha1) && Globals.Gold >= 10) 
				{
					objectNumber = 0;
					placeObjectToBuild();
					ObjectBuilded = true;
					Globals.Gold -= 10;
				}
				
				if (Input.GetKeyUp (KeyCode.Alpha2) && Globals.Gold >= 25) 
				{
					objectNumber = 1;
					placeObjectToBuild();
					ObjectBuilded = true;
					Globals.Gold -= 25;
				}
				
				if (Input.GetKeyUp (KeyCode.Alpha3) && Globals.Gold >= 30) 
				{
					objectNumber = 2;
					placeObjectToBuild();
					ObjectBuilded = true;
					Globals.Gold -= 30;
				}
				
				if (Input.GetKeyUp (KeyCode.Alpha4) && Globals.Gold >= 50) 
				{
					objectNumber = 3;
					placeObjectToBuild();
					ObjectBuilded = true;
					Globals.Gold -= 50;
				}
				if (Input.GetKeyUp (KeyCode.Alpha5) && Globals.Gold >= 40) 
				{
					objectNumber = 4;
					placeObjectToBuild();
					ObjectBuilded = true;
					Globals.Gold -= 40;
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



	// Functie voor het plaatsen van de objecten

	void placeObjectToBuild()
	{
		Debug.Log (Globals.Gold);
		Transform trans = (Transform)Instantiate(buildAbleObjects[objectNumber], new Vector3(transform.position.x,0.5f,transform.position.z), transform.rotation);
		trans.parent = transform;
	}
}
