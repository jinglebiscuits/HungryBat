using UnityEngine;
using System.Collections;

public class PulseDistance : MonoBehaviour {
	
	public Material pulseMaterial;
	public static float distance = 0.0f;
	private float killDistance = 300.0f;
	public static float fadeDistance;
	public static float edgeSoftness;
	public static Vector4 playerPos;
	public Transform player;
	public static Transform target = null;
	public Mouth mouthScript;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerPos = new Vector4(0, 0, 0, 0);
		fadeDistance = 40;
		edgeSoftness = 0.01f;
		mouthScript = GameObject.Find("BatMouth").GetComponent<Mouth>();
		target = player;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//set origin of pulse

		playerPos = new Vector4(player.position.x, player.position.y, player.position.z, 0);
		distance += 200*Time.deltaTime;
		if(distance >= killDistance && !MoveBat.eating)
		{
			mouthScript.PulseSound(Mathf.Clamp(Mathf.Abs(killDistance/50.0f), 0.0f, 0.5f));
			distance = 0;
		}
		
		if (Input.GetButtonDown("Fire1") && !MoveBat.eating)
		{
			mouthScript.PulseSound();
			distance = 0;
		}

		RaycastHit hit;
		if(Physics.Raycast(player.transform.position, player.transform.forward, out hit))
		{
			//print(hit.transform.name);
			if(Input.GetButtonDown ("Fire1"))
			{
				target = hit.transform;
				//hit.transform.GetComponent<ColorObjects>().isTarget = true;
			}
		}
		
		if(target.tag == "Grub")
		{
			killDistance = Mathf.Abs(Vector3.Distance(target.position, player.position)) + 5.0f;
		}
		else
		{
			killDistance = 300.0f;
		}
	}
}
