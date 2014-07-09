using UnityEngine;
using System.Collections;

public class Killed : MonoBehaviour {

	public float lifetime;
	private float ticker;

	// Use this for initialization
	void Start () {

		ticker = UnityEngine.Time.realtimeSinceStartup;
		print (ticker);
	}
	
	// Update is called once per frame
	void Update () {

		if(UnityEngine.Time.realtimeSinceStartup - ticker >= lifetime)
		{
			Destroy(this.gameObject);
		}
	
	}
}
