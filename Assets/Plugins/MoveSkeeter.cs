using UnityEngine;
using System.Collections;

public class MoveSkeeter : MonoBehaviour {
	
	private float randomDir = 0.0f;
	public Transform player;
	public float disToPlayer;
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player").transform;
		randomDir = Random.Range(0.0f, 3.14f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		disToPlayer = Mathf.Abs(Vector3.Distance(player.position, transform.position));
		Vector3 direction = new Vector3(Mathf.Sin(Time.time - randomDir), 0, 0);
		GetComponent<Rigidbody>().velocity = direction + Random.insideUnitSphere * 5;
		transform.rotation = Quaternion.Euler(0, Mathf.Sin(Time.time - randomDir)*180.0f, 0);
	}
}
