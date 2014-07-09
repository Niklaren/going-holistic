using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public PlayerScript Player;
	public float Xoffset;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate(Player.playerSpeed,0.0f,0.0f);//Vector3.forward * Time.deltaTime);
	}
}
