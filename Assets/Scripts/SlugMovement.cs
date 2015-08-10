using UnityEngine;
using System.Collections;

public class SlugMovement : MonoBehaviour {
	
	Transform player;   
	NavMeshAgent nav;
	GameObject player1;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <NavMeshAgent> ();

	}/*
	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if (other.gameObject == player1) {
			Debug.Log("fuck you human");
		}
	}*/
	
	// Update is called once per frame
	void Update () {
		
		nav.SetDestination (player.position);
	}
}
