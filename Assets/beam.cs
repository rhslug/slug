using UnityEngine;
using System.Collections;

public class beam : MonoBehaviour {
	LineRenderer line;
	CardboardHead head;

	public GameObject slug;
	// Use this for initialization
	void Start () {
		Cardboard.SDK.TapIsTrigger = true;
		print ("init");
		line = GetComponent<LineRenderer>();
		line.enabled = false;
		head = Camera.main.GetComponent<StereoController>().Head;
		line.material = new Material (Shader.Find("Particles/Additive"));
		//slug = GameObject.Find ("Slug").transform;
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

				if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.gameObject.name.Equals("Slug") || hit.collider.gameObject.name.Equals("Slug(Clone)")) {
							Destroy(hit.collider.gameObject);
						}
				}
	
				yield return null;

				line.enabled = false;
		}
}
