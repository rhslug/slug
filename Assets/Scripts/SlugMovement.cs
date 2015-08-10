using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class SlugMovement : MonoBehaviour {
	
	Transform player;   
	NavMeshAgent nav;
	public Image ending;
	//float alphaf = 0f;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <NavMeshAgent> ();

	}
	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if (other.gameObject.name == "Player") {
			ending.GetComponent<CanvasGroup> ().DOFade(1, 3f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination (player.position);
	}
}
