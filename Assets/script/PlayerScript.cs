using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float playerSpeed;
	public float playerAcceration;
	public float playerDEAcceration;
	public float Yumpmax;
	public float playerTopSpeed, playerTopTopSpeed;
	public float playerSlow;
	public float playerScore;

	public GameObject Slower;
	public GameObject Point;
	public GameObject slapPoster;
	private bool YumpAvailable;
	private bool YumpDoing;
	private bool eDown;

	public bool HitObject;
	public bool HitGoodObject;

	public Sprite Jump;
	
	public AudioClip FootstepSound;
	public AudioClip HealSound;
	public AudioClip JumpSound;
	public AudioClip AttackSound;
	public AudioClip CaughtSound;
	public AudioClip PosterSound;

	public GameObject Pow;
	public GameObject Thunk;
	public GameObject Thwack;

	public GUISkin skin;

	private float PointA, PointB , PosterDistance;


	// Use this for initialization
	void Awake(){
		playerSpeed = 0.03f;
		playerAcceration = 0.002f;
		playerDEAcceration = 0.002f;
		playerTopSpeed = 0.12f;
		playerTopTopSpeed = 0.2f;
		PointA =  0.0f;
		PointB = PosterDistance = 3.0f;
		Yumpmax = 20.0f;
		YumpAvailable = true;
		YumpDoing = false;
		//this.gameObject.animation.name = "run";

		audio.volume = 1.0f;
	}

	void Start () {

		playerScore = 0.0f;

		this.GetComponent<Animator> ().speed = playerSpeed / 0.2f;
	}

	bool my2Dintersect(Bounds boundsA, Bounds boundsB ){
		return boundsA.min.x <= boundsB.max.x && boundsA.max.x >= boundsB.min.x && boundsA.min.y <= boundsB.max.y && boundsA.max.y >= boundsB.min.y;
	}

	// Update is called once per frame
	void Update () {

		HitObject = false;
		HitGoodObject = false;

		if (Input.GetKeyDown(KeyCode.W) && YumpAvailable == true){
			YumpAvailable = false;
			YumpDoing = true;
			rigidbody2D.velocity = new Vector3(0, 17.0f, 0);
			this.GetComponent<SpriteRenderer>().sprite = Jump;
			this.GetComponent<Animator> ().speed = 0.0f;
			//print("jump");
			audio.clip = JumpSound;
			audio.Play();
		}
		if (Input.GetKeyUp(KeyCode.W)){
			YumpDoing = false;

		}
		if (Input.GetKey (KeyCode.W) && YumpDoing) {
			if(rigidbody2D.velocity.y < Yumpmax){
				rigidbody2D.AddForce(new Vector2(0,10));
			}
		}

		if (Input.GetKeyDown(KeyCode.Q)) {
			GameObject patient = GameObject.FindGameObjectWithTag("POINT");
			if(this.my2Dintersect(patient.collider2D.bounds,this.collider2D.bounds)){

				playerScore += 1.0f;
				if(playerSpeed < playerTopTopSpeed ){
					playerSpeed *= 1.5f;
				}

				Vector3 position = patient.transform.position;
				GameObject obj = Instantiate(Thunk, position,Quaternion.identity) as GameObject;

				audio.clip = HealSound;
				audio.Play();
				
				patient.gameObject.GetComponent<PatientScript>().CurePatient();
			}
		}

		

		if (Input.GetKeyDown(KeyCode.E)) {
			GameObject poster = GameObject.FindGameObjectWithTag("POSTER");
			if(this.my2Dintersect(poster.collider2D.bounds,this.collider2D.bounds)){
				print("rip");
				playerSpeed *= 1.3f;
				HitGoodObject = true;

				Vector3 position = poster.transform.position;
				position.x -= 0.2f;
				//SPAWN NEW POSTER SPRITE ON TOP
				GameObject obj = Instantiate(slapPoster, position,Quaternion.identity) as GameObject;

				audio.clip = PosterSound;
				audio.Play();

				if(playerSpeed < playerTopTopSpeed ){
					playerSpeed *= 1.2f;
				}

			}
		}

		//if (Input.GetKeyDown("S")){
		//	print("slide");
		//}
		this.gameObject.transform.Translate(playerSpeed,0.0f,0.0f);//Vector3.forward * Time.deltaTime);

		//Acceleration
		if (playerSpeed < playerTopSpeed) {
			playerSpeed += playerAcceration;
		}

		if (playerSpeed > playerTopSpeed) {
			playerSpeed -= playerDEAcceration;
		}


	}

	void OnGUI () {
		GUI.skin = skin;
		GUI.Label (new Rect (1080, 20, 300, 30), "" + playerScore);
	}

	void OnTriggerEnter2D  (Collider2D other ) {
		if (other.tag == "SLOW") {
			HitObject = true;
			playerSpeed *= 0.5f;

			audio.clip = AttackSound;
			audio.Play();

			other.gameObject.transform.Translate(new Vector3(Random.Range(30.0f,50.0f) ,0 , 0));

			Vector3 position = this.transform.position;
			GameObject obj = Instantiate(Thwack, position,Quaternion.identity) as GameObject;

//			Destroy(other.gameObject);
//			//Spawn New bad peepz
//			GameObject obj = Instantiate(Slower) as GameObject;			
//			obj.GetComponent<ObjectDefaultScript>().SetPlayer(this.gameObject);


			
		}

		if (other.tag == "POINT") {
//			bject);
		}

//		
		if (other.tag == "COPS") {

			Vector3 position = this.transform.position;
			//GameObject obj = Instantiate(Pow, position,Quaternion.identity) as GameObject;


			audio.clip = CaughtSound;
			audio.Play();

			//GOTO END SCREEN
			Application.LoadLevel("EndScreen");
		}

	}
	
	void OnCollisionEnter2D (Collision2D other) {
		if (other.collider.tag == "FLOOR"){
			YumpAvailable = true;
			this.GetComponent<Animator> ().speed = playerSpeed / 0.2f;
		}


	}
}
