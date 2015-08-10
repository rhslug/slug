using UnityEngine;
using System.Collections;

public class makeSlug : MonoBehaviour {

	public GameObject Slug;
	public float interval = 3f;
	// Use this for initialization
	public void startSpawn() {
		Invoke("spawn", 3);
	}

	void Start () {

	}

	void spawn () {
		Debug.Log("S");
		Invoke ("spawn", interval);
		float r = Random.Range(0F, 4F);
		GameObject s;
		if(r >= 0 && r < 1)
			s = Instantiate(Slug, new Vector3(35, 3, -35+r*70), Quaternion.identity) as GameObject;
		if(r >= 1 && r < 2)
			s = Instantiate(Slug, new Vector3(-35, 3, -35+(r-1)*70), Quaternion.identity) as GameObject;
		if(r >= 2 && r < 3)
			s = Instantiate(Slug, new Vector3(-35+(r-2)*70, 3, 35), Quaternion.identity) as GameObject;
		if(r >= 3 && r <= 4)
			s = Instantiate(Slug, new Vector3(-35+(r-3)*70, 3, -35), Quaternion.identity) as GameObject;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
