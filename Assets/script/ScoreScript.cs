using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	
	public PlayerScript player;
	TextMesh textMesh;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh>().text = player.playerScore.ToString ();
	}
}
