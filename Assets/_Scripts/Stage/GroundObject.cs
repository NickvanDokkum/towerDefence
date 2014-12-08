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
				if (Input.GetKeyUp (KeyCode.Alpha1)) 
				{
					objectNumber = 0;
					placeObjectToBuild();
					ObjectBuilded = true;
				}
				
				if (Input.GetKeyUp (KeyCode.Alpha2)) 
				{
					objectNumber = 1;
					placeObjectToBuild();
					ObjectBuilded = true;
				}
				
				if (Input.GetKeyUp (KeyCode.Alpha3)) 
				{
					objectNumber = 2;
					placeObjectToBuild();
					ObjectBuilded = true;
				}
				
				if (Input.GetKeyUp (KeyCode.Alpha4)) 
				{
					objectNumber = 3;
					placeObjectToBuild();
					ObjectBuilded = true;
				}
				if (Input.GetKeyUp (KeyCode.Alpha5)) 
				{
					objectNumber = 4;
					placeObjectToBuild();
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



	// Functie voor het plaatsen van de objecten

	void placeObjectToBuild()
	{
		Transform trans = (Transform)Instantiate(buildAbleObjects[objectNumber], new Vector3(transform.position.x,0.55f,transform.position.z), transform.rotation);
		trans.parent = transform;
	}
}
