using UnityEngine;
using System.Collections;

public class PatientScript : MonoBehaviour {

	public Sprite Patient1;
	public Sprite CuredPatient1;
	public Sprite Patient2;
	public Sprite CuredPatient2;
	public Sprite Patient3;
	public Sprite CuredPatient3;

	private float numTag;

	// Use this for initialization
	void Start () {
		SpriteRenderer sprRndr = GetComponent<SpriteRenderer>();
		numTag = Random.Range (0.0f, 3.0f);
		if (numTag < 1.0) {
			//Patient 1 
			sprRndr.sprite = Patient1;
		} else if (numTag < 2.0) {
			//Patient 2 
			sprRndr.sprite = Patient2;
		} else {
			//Patient 3 
			sprRndr.sprite = Patient3;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CurePatient(){
		SpriteRenderer sprRndr = GetComponent<SpriteRenderer>();
		if (sprRndr.sprite == Patient1) {
			//Patient 1 
			sprRndr.sprite = CuredPatient1;
		} else if (sprRndr.sprite == Patient2) {
			//Patient 2 
			sprRndr.sprite = CuredPatient2;
		} else if (sprRndr.sprite == Patient3) {
			//Patient 3 
			sprRndr.sprite = CuredPatient3;
		}
	}

	public void CorruptPatient(){
		SpriteRenderer sprRndr = GetComponent<SpriteRenderer>();
		numTag = Random.Range (0.0f, 3.0f);
		if (numTag < 1.0) {
			//Patient 1 
			sprRndr.sprite = Patient1;
		} else if (numTag < 2.0) {
			//Patient 2 
			sprRndr.sprite = Patient2;
		} else {
			//Patient 3 
			sprRndr.sprite = Patient3;
		}
	}

	void OnBecameInvisible() {
		this.gameObject.transform.Translate(new Vector3( Screen.width/100.0f+Random.Range(30.0f,50.0f) ,0 , 0));
		//if (this.gameObject.GetComponent<PatientScript> () != null) {
		//	this.gameObject.GetComponent<PatientScript> ().
		CorruptPatient ();
		//}
	}

}
