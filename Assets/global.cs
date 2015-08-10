using UnityEngine;
using System.Collections;

public class global : MonoBehaviour {
	public bool gameStarted = false;
	public int score = 0;
	// Use this for initialization
	void Start () {
		DG.Tweening.DOTween.Init ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
