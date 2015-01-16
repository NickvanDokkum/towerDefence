using UnityEngine;
using System.Collections;

public class GroundObject : MonoBehaviour {

	private bool _Onhover = false;
	public bool ObjectBuilded = false;
	
	//public Transform Wall;
	//public Transform[] turrets;
	public Transform[] buildAbleObjects;
	private int objectNumber;
	public Material ground;


	void Start()
	{
		if(this.transform.position.x <= 160 && this.transform.position.x >= 90)
		{
			if(this.transform.position.z <= 160 && this.transform.position.z >= 80)
			{
				ObjectBuilded = true;
			}
		}
	}


	void Update()
	{
		if(Input.GetMouseButtonUp(0) && _Onhover == true)
		{
			if(Globals.CurrentFocus > 2)
			{
				objectNumber = Globals.CurrentFocus - 3;
				Debug.Log(objectNumber + " / " + Globals.CurrentFocus);
				placeObjectToBuild();
			}
		}

		/*if (_Onhover && ObjectBuilded == false) 
		{
			if(Globals.BuildMode)
			{
				Debug.Log("Buildmode = " + Globals.BuildMode);
				//start de functies om het gewenste object neer te zetten op de door jou gekoze locatie
				if (Input.GetKeyUp (KeyCode.Alpha1) && Globals.Gold >= 10) 
				{
					objectNumber = 0;
					placeObjectToBuild();
					Globals.Gold -= 10;
				}
				
				if (Input.GetKeyUp (KeyCode.Alpha2) && Globals.Gold >= 25) 
				{
					objectNumber = 1;
					placeObjectToBuild();
					Globals.Gold -= 25;
				}
				
				if (Input.GetKeyUp (KeyCode.Alpha3) && Globals.Gold >= 30) 
				{
					objectNumber = 2;
					placeObjectToBuild();
					Globals.Gold -= 30;
				}
				
				if (Input.GetKeyUp (KeyCode.Alpha4) && Globals.Gold >= 50) 
				{
					objectNumber = 3;
					placeObjectToBuild();
					Globals.Gold -= 50;
				}
				if (Input.GetKeyUp (KeyCode.Alpha5) && Globals.Gold >= 40) 
				{
					objectNumber = 4;
					placeObjectToBuild();
					Globals.Gold -= 40;
				}
			}
		}*/
	}


	//checkt of de muis op een plane staat en maakt de acties die hierbij horen mogelijk

	void OnMouseExit()
	{
		// turn the things of on mouse enter off
		renderer.material = ground;

		_Onhover = false;
	}

	void OnMouseOver()
	{
		if(Globals.BuildMode && ObjectBuilded == false)
		{
			renderer.material.color = Color.blue;
			_Onhover = true;
		}
	}

	// Functie voor het plaatsen van de objecten

	void placeObjectToBuild()
	{
		Debug.Log (Globals.Gold);
		Transform trans = (Transform)Instantiate(buildAbleObjects[objectNumber], new Vector3(transform.position.x,0f,transform.position.z), transform.rotation);
		trans.parent = transform;
		ObjectBuilded = true;
	}
}
