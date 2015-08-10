using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class beam : MonoBehaviour {
	LineRenderer line;
	CardboardHead head;
	public Text gui;
	public Text score;
	AudioSource playerAudio;
	bool nowPlaying = false;
	int blinks = 0;
	Color blinkColor;
	Color ScoreColor;


	//public GameObject slug;
	// Use this for initialization
	void Start () {
		Cardboard.SDK.TapIsTrigger = true;
		//print ("init");
		line = GetComponent<LineRenderer>();
		line.enabled = false;
		head = Camera.main.GetComponent<StereoController>().Head;
		line.material = new Material (Shader.Find("Particles/Additive"));
		playerAudio = GetComponent <AudioSource> ();
		//slug = GameObject.Find ("Slug").transform;
		blinkColor.r = 255;
		blinkColor.g = 0;
		blinkColor.b = 0;
		blinkColor.a = 1;

		ScoreColor.r = 20;
		ScoreColor.g = 20;
		ScoreColor.b = 20;
		ScoreColor.a = 0;
	}



	
	// Update is called once per frame
	void Update () {
				if (nowPlaying == false) {
						blinks++;
						score.GetComponent<Text> ().color = ScoreColor;
						if (blinks / 40 % 2 == 1)
								blinkColor.a = 0;
						else
								blinkColor.a = 1;

						gui.GetComponent<Text> ().color = blinkColor;
				} else {
						blinkColor.a = 0;
						ScoreColor.a = 1;
						gui.GetComponent<Text> ().color = blinkColor;
						score.GetComponent<Text> ().color = ScoreColor;
				}
		

		if (Cardboard.SDK.CardboardTriggered) {
			if(GameObject.Find("GameManager").GetComponent<global>().gameStarted) {
				StopCoroutine("fire");
				StartCoroutine("fire");
				playerAudio.Play();
			} else {
				GameObject.Find("GameManager").GetComponent<global>().gameStarted = true;
				GameObject.Find("SlugMaker").GetComponent<makeSlug>().startSpawn();
				nowPlaying = true;
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
							if(GameObject.Find("SlugMaker").GetComponent<makeSlug>().interval > 1)
								GameObject.Find("SlugMaker").GetComponent<makeSlug>().interval -= 0.025f;
							Debug.Log(GameObject.Find("GameManager").GetComponent<global>().score);
							Destroy(hit.collider.gameObject);
				score.GetComponent<Text>().text = "Score : " + GameObject.Find("GameManager").GetComponent<global>().score;
						}
				}
	
				yield return null;

				line.enabled = false;
		}
}
