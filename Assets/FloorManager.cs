using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

	private int rows = 25;
	private int lines = 25;
	public Transform Floor;

	// Use this for initialization
	void Awake () 
	{
		for(int i = 0;i < lines; i++)
		{
			for(int j = 0; j < rows; j++)
			{
				var go = Instantiate(Floor, new Vector3(i*10f, 0,j*10f), transform.rotation);
			}
		}
	}
}
