using UnityEngine;
using System.Collections;

public class enemyMoveScript : MonoBehaviour {

	private NavMeshAgent agent;
	[SerializeField]
	private GameObject target;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.SetDestination (target.transform.position);
	}
}
