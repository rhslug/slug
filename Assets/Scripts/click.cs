using UnityEngine;
using System.Collections;

public class click : MonoBehaviour {

	LineRenderer line;
	CardboardHead head;
	// Use this for initialization
	void Start () {
		Cardboard.SDK.TapIsTrigger = true;
		head = Camera.main.GetComponent<StereoController>().Head;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Cardboard.SDK.CardboardTriggered) {

		}
	}

}
