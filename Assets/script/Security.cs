using UnityEngine;
using System.Collections;

public class Security : MonoBehaviour {
	[SerializeField]
	public PlayerScript player;
	public float Position1Offset;
	public float Position2Offset;
	public float CustomOffset;
	public Sprite ElbowDrop;
	public Sprite JUMPsprite;

	private float Xoffset;
	private float TargetPositionX;
	private float guardSpeed;
	private bool Timer;
	private int TimePassed;
	public bool Dive;
	// Use this for initialization
	void Start () {
		Xoffset = Position2Offset - CustomOffset;
		Timer = false;
		TimePassed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<Animator> () != null) {

			this.GetComponent<Animator> ().speed = 5.0f;
		} else {

			Timer = true;
		}
		//Target location
		TargetPositionX= player.transform.position.x-Xoffset;

		float targetDiff = TargetPositionX - this.gameObject.transform.position.x;

		guardSpeed = (targetDiff / 10) + player.playerSpeed;

	
		if (Timer == true && Dive == true) {
			SpriteRenderer sprRndr = GetComponent<SpriteRenderer>();
			sprRndr.sprite = JUMPsprite;
			this.gameObject.transform.localScale = new Vector3(0.3f,0.3f,1.0f);
			TimePassed++;


			if(TimePassed > 16){

				sprRndr.sprite = ElbowDrop;
				this.gameObject.transform.localScale = new Vector3(0.3f,0.3f,1.0f);
				Xoffset = CustomOffset;
			}

		}

		//Movement
		this.gameObject.transform.Translate(new Vector3 (guardSpeed,0.0f, 0.0f));


		if (player.HitObject == true){
			//move forward

			if(Xoffset == Position1Offset - CustomOffset){
				//Xoffset = CustomOffset;
				// Kill the [player
				if(Dive == true){
				Destroy(GetComponent<Animator>());
				}


			}

			if(Xoffset == Position2Offset - CustomOffset){
				Xoffset = Position1Offset - CustomOffset;
			}


		}

		if (player.HitGoodObject == true){
			//move forward


			if(Xoffset == Position1Offset - CustomOffset){
				Xoffset = Position2Offset - CustomOffset;
			}
			
		
			
		}
	}


}
