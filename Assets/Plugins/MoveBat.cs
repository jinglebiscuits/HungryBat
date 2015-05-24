using UnityEngine;
using System.Collections;

public class MoveBat : MonoBehaviour {
	
	public float speed = 5.0f;
	public float maxSpeed = 50.0f;
	public float minSpeed = 5.0f;
	private float t = 0;//timer
	public static bool eating = false;
	private float eatTimer = 0;
	public float eatTime = 3.0f;
	public static bool drinking = false;
	public Mouth mouthScript;
	private int caveMask = 1 << 9;
	public Transform batCam;
	private PlaceGrub placeGrubScript;
	public static int bugCount = 0;
	public TextMesh bugCountText;
	
	// Use this for initialization
	void Start ()
	{
		Cursor.visible = false;
		mouthScript = GameObject.Find ("BatMouth").GetComponent<Mouth>();
		placeGrubScript = GameObject.Find ("Scripts").GetComponent<PlaceGrub>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.Escape))
			Application.Quit();
		if(!eating)
		{
			Vector3 relativeForward = batCam.TransformDirection(Vector3.forward);
			Vector3 relativeRight = batCam.TransformDirection(Vector3.right);
			if(Input.GetAxis("Vertical") > 0)
				transform.GetComponent<Rigidbody>().MovePosition(transform.position + speed * relativeForward * Input.GetAxis("Vertical") * Time.deltaTime);
			else if(Input.GetAxis("Vertical") < 0)
				transform.GetComponent<Rigidbody>().MovePosition(transform.position + 5.0f * relativeForward * Input.GetAxis("Vertical") * Time.deltaTime);
			
			if(Input.GetAxis("Horizontal") > 0)
				IncreaseSpeed();
			else if(Input.GetAxis("Horizontal") < 0)
				DecreaseSpeed();
			
			DetectCave();
				
			if(Input.GetButtonDown("Jump"))
			{
				t = Time.time;
			}
			if(Input.GetButtonUp("Jump"))
			{
				if((Time.time - t) <= 0.25f)
				{
					transform.GetComponent<Rigidbody>().MovePosition(transform.position + Vector3.up);
				}
				t = 0;
				
			}
			
			if(Input.GetButton("Jump") && (Time.time - t) > 0.25f)
			{
				float upSpeed = (200.0f - transform.position.y)*10.0f/200.0f;
				if(transform.position.y < 180.0f)
					upSpeed = 30.0f;
				transform.GetComponent<Rigidbody>().MovePosition(transform.position + Vector3.up * upSpeed * Time.deltaTime);
			}			
		}
		else
		{
			if(Time.time - eatTimer > eatTime)
			{
				eatTimer = 0;
				eating = false;
			}
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Grub" && other.transform == PulseDistance.target)
		{
			PulseDistance.target = GameObject.FindWithTag("Cave").transform;
			print(PulseDistance.target);
			Destroy (other.gameObject);
			print (GameObject.FindGameObjectsWithTag("Grub").Length/14 +"skeeters");
			if(GameObject.FindGameObjectsWithTag("Grub").Length/14 < 5)
				placeGrubScript.SpawnSkeeters();
			eating = true;
			mouthScript.EatSound();
			eatTimer = Time.time;
			bugCount ++;
			bugCountText.text = "Bugs eaten: "+bugCount;
		}
		
		if(other.tag == "Water")
		{
			drinking = true;
			print("I'm drinking water");
		}
	}
	
	void IncreaseSpeed()
	{
		if(speed < maxSpeed)
			speed += 10.0f*Time.deltaTime;
		else
			speed = maxSpeed;
	}
	
	void DecreaseSpeed()
	{
		if(speed > minSpeed)
			speed -= 10.0f * Time.deltaTime;
		else
			speed = minSpeed;
	}
	
	void DetectCave()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit, 10, caveMask))
		{
			speed = 10.0f;
		}
	}
}
