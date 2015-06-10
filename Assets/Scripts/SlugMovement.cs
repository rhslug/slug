using UnityEngine;
using System.Collections;

public class SlugMovement : MonoBehaviour {
	
	Transform player;   
	NavMeshAgent nav;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		nav.SetDestination (player.position);
	}
}
