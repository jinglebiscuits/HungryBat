using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	
	public AudioSource flying;
	public AudioSource pursuing;
	private float timer = 0.0f;

	// Use this for initialization
	void Start ()
	{
		timer = Time.time;
		flying.GetComponent<AudioSource>().loop = true;
		flying.GetComponent<AudioSource>().Play ();
		//pursuing.audio.Play ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Time.time - timer > 128.0f)
		{
			MoveBat.bugCount = 0;
			Application.LoadLevel("Cave");
		}
	}
}
