using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

	//public GameObject Player;
	public int tileNumber;

	// Use this for initialization
	void Start () {
	
		this.gameObject.transform.Translate(new Vector3(this.gameObject.renderer.bounds.size.x * tileNumber, 1.0f ,0));
	}

	// Update is called once per frame
	void Update () {
		bool Visible = gameObject.renderer.isVisible;

//		if (Visible == false) {
//			if(this.gameObject.transform.position.x < Player.transform.position.x){
//				this.gameObject.transform.Translate(new Vector3(this.gameObject.renderer.bounds.size.x * 2.0f , 0 ,0));
//			}
//		}
	}

	void OnBecameVisible(){
		print ("background became vis");
		}

	void OnBecameInvisible() {
		print ("background became invis");
		this.gameObject.transform.Translate(new Vector3(this.gameObject.renderer.bounds.size.x * 3.0f , 0 ,0));
	}
}
