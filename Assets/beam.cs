using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class beam : MonoBehaviour {
	LineRenderer line;
	CardboardHead head;
	public Text gui;
	AudioSource playerAudio;

	public GameObject slug;
	// Use this for initialization
	void Start () {
		Cardboard.SDK.TapIsTrigger = true;
		print ("init");
		line = GetComponent<LineRenderer>();
		line.enabled = false;
		head = Camera.main.GetComponent<StereoController>().Head;
		line.material = new Material (Shader.Find("Particles/Additive"));
		playerAudio = GetComponent <AudioSource> ();
		//slug = GameObject.Find ("Slug").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Cardboard.SDK.CardboardTriggered) {
			if(GameObject.Find("GameManager").GetComponent<global>().gameStarted) {
				StopCoroutine("fire");
				StartCoroutine("fire");
				playerAudio.Play();
			} else {
				GameObject.Find("GameManager").GetComponent<global>().gameStarted = true;
				print("gameStart");
			}
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
							GameObject.Find("GameManager").GetComponent<global>().score += 1;			
							Debug.Log(GameObject.Find("GameManager").GetComponent<global>().score);
							Destroy(hit.collider.gameObject);
				gui.GetComponent<Text>().text=GameObject.Find("GameManager").GetComponent<global>().score+"";
						}
				}
	
				yield return null;

				line.enabled = false;
		}
}
