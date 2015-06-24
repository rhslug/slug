using UnityEngine;
using System.Collections;

public class makeSlug : MonoBehaviour {

	public GameObject Slug;
	// Use this for initialization
	void Start () {
		InvokeRepeating("spawn", 1, 1);
	}

	void spawn () {
		GameObject s = Instantiate(Slug, new Vector3(Random.Range(-35,35), 15, Random.Range(-35,35)), Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
