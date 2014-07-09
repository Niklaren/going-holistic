using UnityEngine;
using System.Collections;

public class backbuttonscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown ()
	{
		Application.LoadLevel("MainMenu");
	}
}
