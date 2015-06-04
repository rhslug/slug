using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	[SerializeField]
	private GUIText timeText = null;

	private float playTime = 0.0f;

	void Start ()
	{
		//GameParameters.GetInstance().InitializeGame();

	}


	void Update ()
	{
		playTime += Time.deltaTime;
		timeText.text = playTime.ToString("00.00");
	}


}
