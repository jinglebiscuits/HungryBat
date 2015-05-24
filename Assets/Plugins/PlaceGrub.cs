using UnityEngine;
using System.Collections;

public class PlaceGrub : MonoBehaviour {
	
	public GameObject skeeter;
	private Vector3 pos;
	public Transform skeeterCentral;
	
	// Use this for initialization
	void Start () 
	{
		//pos = new Vector3(Random.Range(15.0f, 25.0f), Random.Range(1.0f, 2.0f), Random.Range(-18.0f, -13.0f));
		for(int i = 1; i < 7; i++)
		{
			Vector3 skeetPos =new Vector3(Random.Range(-125.0f, 125.0f), Random.Range(0.0f, 150f), Random.Range(-125.0f, 125.0f));
			GameObject clone;
			clone = Instantiate(skeeter, skeetPos, Quaternion.identity) as GameObject;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
	}
	
	public void SpawnSkeeters()
	{
		for(int i = 1; i < 30; i++)
		{
			Vector3 skeetPos =new Vector3(Random.Range(-125.0f, 125.0f), Random.Range(0.0f, 150f), Random.Range(-125.0f, 125.0f));
			GameObject clone;
			clone = Instantiate(skeeter, skeetPos, Quaternion.identity) as GameObject;
		}
	}
}
