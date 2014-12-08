using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private float speed = 10.0F;
	private float rotationSpeed = 100.0F;

	private float mouseSensivity = 10.0f;
	
	private float verticalRotation = 0;
	private float upDownRange = 60.0f;

	void Update() 
	{
		if (Input.GetKey(KeyCode.Escape) && Screen.lockCursor == true)
			Screen.lockCursor = false;
		else
			Screen.lockCursor = true;


		float rotHorizontal = Input.GetAxis ("Mouse X") * mouseSensivity;
		transform.Rotate (0, rotHorizontal, 0);
		
		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
		
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);



		float translation = Input.GetAxis("Vertical") * speed;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;

		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);


	
	}
}