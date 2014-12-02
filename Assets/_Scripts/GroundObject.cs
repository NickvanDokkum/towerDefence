using UnityEngine;
using System.Collections;

public class GroundObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter()
	{
		renderer.material.color = Color.blue;
	}

	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}
}
