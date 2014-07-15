using UnityEngine;
using System.Collections;

public class PlaneScript : MonoBehaviour {

	public PlayerScript player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate(player.playerSpeed,0.0f,0.0f);
	}
}
