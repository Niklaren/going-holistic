using UnityEngine;
using System.Collections;

public class posterSlapScript : MonoBehaviour {

	public Sprite postersprite1;
	public Sprite postersprite2;
	public Sprite postersprite3;
	public Sprite postersprite4;

	// Use this for initialization
	void Start () {
		SpriteRenderer sprRndr = GetComponent<SpriteRenderer>();

		float rand = Random.Range(0.0f,4.0f);
		if(rand<1.0f){
			sprRndr.sprite = postersprite1;
		}else if(rand<2.0f){
			sprRndr.sprite = postersprite2;
		}else if(rand<3.0f){
			sprRndr.sprite = postersprite3;
		}else{
			sprRndr.sprite = postersprite4;
		}

		this.gameObject.transform.localScale = new Vector3 (2.5f, 2.5f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnBecameInvisible() {
		Destroy (this);
	}
}
