using UnityEngine;
using System.Collections;

public class turret2Controller : MonoBehaviour {

	void Start () {
		animation.Stop();
	}

	public void Shoot () {
		animation.Play ();
	}
}
