using UnityEngine;
using System.Collections;

public class ObjectDefaultScript : MonoBehaviour {

	public GameObject player;
	public Sprite postersprite1;
	public Sprite postersprite2;

	private bool interactable = true;

	// Use this for initialization
	void Start () {
		Random.seed = (int)Time.time;
		Vector3 curPos = new Vector3 (this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
		float halfWidth = this.gameObject.transform.renderer.bounds.extents.x;
		float halfHeight = this.gameObject.transform.renderer.bounds.extents.y;
		Vector3 newPos = new Vector3 (curPos.x  + Random.Range (72.0f, 120.0f), curPos.y, curPos.z);//this.gameObject.transform.position.y
		
		Vector2 topLeft = new Vector2(newPos.x- halfWidth, newPos.y+halfHeight);
		Vector2 topRight= new Vector2(newPos.x+ halfWidth , newPos.y-halfHeight);
		
		while (Physics2D.OverlapArea (topLeft, topRight)!=null) {
			newPos.x = newPos.x + Random.Range (1.0f, 10.0f);
			topLeft = new Vector2(newPos.x- halfWidth , newPos.y+halfHeight);
			topRight= new Vector2(newPos.x+ halfWidth, newPos.y-halfHeight);
		} 
		this.gameObject.transform.position = newPos;
		if (this.gameObject.GetComponent<PatientScript> () != null) {
			this.gameObject.GetComponent<PatientScript> ().CorruptPatient ();
		}

		if (this.GetComponent<Animator> () != null) {
			this.GetComponent<Animator> ().speed = 0.3f;
		}
	}

	// Update is called once per frame
	void Update () {
		if (this.tag == "POINT") {
			this.gameObject.transform.position =  (new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, 6.0f));
		}
	}
	public void SetPlayer(GameObject player){
		this.player = player;
	}

	void OnBecameInvisible() {
		print ("NPC Out of view");

		SetInteractable ();

		if (this.tag == "POSTER"){
			SpriteRenderer sprRndr = GetComponent<SpriteRenderer>();
			float rand = Random.Range(0.0f,1.0f);
			if(rand<0.5f){
				sprRndr.sprite = postersprite1;
			}else{
				sprRndr.sprite = postersprite2;
			}
		}

		Vector3 curPos = new Vector3 (this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
		float halfWidth = this.gameObject.transform.renderer.bounds.extents.x;
		float halfHeight = this.gameObject.transform.renderer.bounds.extents.y;
		Vector3 newPos = new Vector3 (curPos.x  + Random.Range (72.0f, 120.0f), curPos.y, curPos.z);//this.gameObject.transform.position.y

		Vector2 topLeft = new Vector2(newPos.x- halfWidth, newPos.y+halfHeight);
		Vector2 topRight= new Vector2(newPos.x+ halfWidth , newPos.y-halfHeight);

		while (Physics2D.OverlapArea (topLeft, topRight)!=null) {
			newPos.x = newPos.x + Random.Range (1.0f, 10.0f);
			topLeft = new Vector2(newPos.x- halfWidth , newPos.y+halfHeight);
			topRight= new Vector2(newPos.x+ halfWidth, newPos.y-halfHeight);
		} 
		this.gameObject.transform.position = newPos;
		if (this.gameObject.GetComponent<PatientScript> () != null) {
			this.gameObject.GetComponent<PatientScript> ().CorruptPatient ();
		}
	}

	void OnTriggerEnter2D  (Collider2D other ) {
		print ("triggers");
		if (other.tag == "SLOW" || other.tag == "POINT" || other.tag == "DOOR" || other.tag == "POSTER") {
			this.gameObject.transform.Translate(new Vector3( Screen.width/100.0f+Random.Range(30.0f,50.0f) ,0 , 0));
		}

		//if(other.tag == "DOOR"){
		//	this.gameObject.transform.Translate(new Vector3( Screen.width/100.0f+Random.Range(30.0f,50.0f) ,0 , 0));
		//}

		//if(this.tag== "SLOW" && other.tag == "DOOR"){
		//	this.gameObject.transform.Translate(new Vector3( Screen.width/100.0f+Random.Range(30.0f,50.0f) ,0 , 0));
		//}
	}

	void OnCollisionEnter2D (Collision2D other) {
		print ("collision");
	}

	public void SetInteractable()
	{
		interactable = true;
	}

	public void SetUnInteractable()
	{
		interactable = false;
	}

	public bool GetInteractable()
	{
		return interactable;
	}

}
