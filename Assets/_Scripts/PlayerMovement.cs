using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private float speed = 10.0F;
	private float rotationSpeed = 100.0F;

	private float mouseSensivity = 10.0f;
	
	private float verticalRotation = 0;
	private float upDownRange = 60.0f;

	private float jumpSpeed = 160;
	private bool isJumping;


	void Update() 
	{
		if (Input.GetKeyDown(KeyCode.Space) && isJumping == false) 
		{
			rigidbody.AddForce(Vector3.up * jumpSpeed * 2);
			isJumping = true;
		}

		if (Input.GetKey(KeyCode.Escape) && Screen.lockCursor == true || Globals.paused)
			Screen.lockCursor = false;
		else if (!Globals.paused)
			Screen.lockCursor = true;

		print (Globals.paused);
		if(!Globals.paused)
		{
		float rotHorizontal = Input.GetAxis ("Mouse X") * mouseSensivity;
		transform.Rotate (0, rotHorizontal, 0);
		
		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);

		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);
		}



		float translation = Input.GetAxis("Vertical") * speed;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;

		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);


	
	}

	void OnCollisionEnter(Collision collision)
	{
		isJumping = false;
	}
}