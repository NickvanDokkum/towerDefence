using UnityEngine;
using System.Collections;

public class CreateEnd : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Globals.end = this.gameObject;
	}
}
