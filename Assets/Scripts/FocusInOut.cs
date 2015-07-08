using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FocusInOut : MonoBehaviour {

	public Text gui;

	public void SetGazedAt() {
			gui.GetComponent<Text> ().color = Color.red;
	}
	
	public void GazedOut()
	{
		gui.GetComponent<Text> ().color = Color.white;
	}
}
