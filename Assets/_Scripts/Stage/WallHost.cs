using UnityEngine;
using System.Collections;

public class WallHost : MonoBehaviour {

	public Transform[] walls;
	private int HP;
	private bool _OnHover = false;
	private int currentWallLevel = 0;
	private int damages;

	// Use this for initialization
	void Start () 
	{
		//Hoe zet je dit object in een leeg game object?
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
						Transform trans = (Transform)Instantiate(walls[currentWallLevel], new Vector3(transform.position.x,10f,transform.position.z), transform.rotation);
						trans.parent = transform;
						if(currentWallLevel == 1){
							HP = 3;
						}
						else if (currentWallLevel == 2){
							HP = 5;
						}
						else if (currentWallLevel == 3){
							HP = 10;
						}
					}
				}
			}
		}
	}
	void OnCollisionStay(Collision hit){
		if(hit.gameObject.GetComponent<fastEnemyScript>().attack == true){
			if(hit.gameObject.tag == "Enemy2"){
				print(hit.gameObject.GetComponent<fastEnemyScript>());
				damages = 1;
				damaged();
			}
		}
	}
	void removeOldChild()
	{
		Transform trans = this.transform.GetChild(currentWallLevel);
		trans.transform.parent = null;

		Destroy ((trans as Transform).gameObject);
	}
	void damaged(){
		if(currentWallLevel != 0){
			switch (damages)
			{
				case 1:
					HP--;
				break;
				case 2:
					HP-=2;
				break;
			}
			if (HP < 0){
				removeOldChild();
				currentWallLevel = 0;

			}
			print(HP);
		}
	}
}
