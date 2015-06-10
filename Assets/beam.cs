using UnityEngine;
using System.Collections;

public class beam : MonoBehaviour {
	LineRenderer line;
	CardboardHead head;
	// Use this for initialization
	void Start () {
		Cardboard.SDK.TapIsTrigger = true;
		print ("init");
		line = GetComponent<LineRenderer>();
		line.enabled = false;
		head = Camera.main.GetComponent<StereoController>().Head;

	}
	
	// Update is called once per frame
	void Update () {
		if (Cardboard.SDK.CardboardTriggered) {
			print (Cardboard.SDK.HeadRotation);
			StopCoroutine("fire");
			StartCoroutine("fire");
		}
	}

	IEnumerator fire() {
				line.enabled = true;
				Ray ray = head.Gaze;
				RaycastHit hit;
				line.SetPosition (0, this.transform.position);
				line.SetPosition (1, ray.GetPoint(100));

		/*
				if (Physics.Raycast (ray, out hit, 100)) {
						line.SetPosition (1, hit.point);
						if (hit.rigidbody) {
								hit.rigidbody.AddForceAtPosition (transform.forward_ * 10, hit.point);
						}
				} else
						line.SetPosition (1, ray.GetPoint (100));

*/
				yield return null;

				line.enabled = false;
		}
}
