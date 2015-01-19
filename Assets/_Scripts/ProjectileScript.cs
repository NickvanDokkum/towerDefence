using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {
	private float mySpeed = 1.5f;
	private float myRange = 3.0f;
	
	private float myDist;

	void Start () {

	}

	void Update () {
		transform.Translate (Vector3.forward*mySpeed);
		myDist += Time.deltaTime * mySpeed;
		if (myDist>=myRange)
		{
			Destroy (gameObject);
		}
	}
}