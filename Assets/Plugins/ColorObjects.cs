using UnityEngine;
using System.Collections;

public class ColorObjects : MonoBehaviour {
	
	public Material pulseMaterial;
	public Texture2D mainTexture;
	public Texture2D normalMap;
	public Transform player;
	public bool isTarget;
	public Renderer[] rends;
	
	// Use this for initialization
	void Start ()
	{
		if(gameObject.GetComponent<Renderer>())
		{
			transform.GetComponent<Renderer>().material = pulseMaterial;
			player = GameObject.FindGameObjectWithTag("Player").transform;
			if(transform.tag == "Grub")
			{
				transform.GetComponent<Renderer>().material.SetFloat("_RimOn", 1);
				transform.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
			}
			else if(transform.tag == "Cave")
			{
				transform.GetComponent<Renderer>().material.SetTexture("_MainTex", mainTexture);
				transform.GetComponent<Renderer>().material.SetFloat("_RimOn", 1);
				transform.GetComponent<Renderer>().material.SetFloat("_RimPower", 0.6f);
				transform.GetComponent<Renderer>().material.SetColor("_RimColor", Color.magenta);
				transform.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
				transform.GetComponent<Renderer>().material.SetTexture("_BumpMap", normalMap);
			}
			else if(transform.tag == "Water")
			{
				transform.GetComponent<Renderer>().material.SetFloat("_RimOn", 0);
				transform.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
			}
			else if(transform.tag == "Plant")
			{
				transform.GetComponent<Renderer>().material.SetFloat("_RimOn", 0);
				transform.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
				transform.GetComponent<Renderer>().material.SetTexture("_MainTex", mainTexture);
				transform.GetComponent<Renderer>().material.SetTexture("_BumpMap", normalMap);
			}			
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
//		if(PulseDistance.target == transform && transform.tag == "Cave")
//		{
//			rends = transform.parent.parent.GetComponentsInChildren<Renderer>();
//			foreach(Renderer rend in rends)
//			{
//				rend.material.SetFloat("_RimOn", 1);
//				if(rend.tag == "Cave")
//					rend.material.SetColor("_RimColor", new Color(0.4f, 0.2f, 0.2f));
//			}
//		}
//		
//		else
//		{
//			rends = gameObject.GetComponentsInChildren<Renderer>();
//			foreach(Renderer rend in rends)
//			{
//				rend.material.SetFloat("_RimOn", 0);	
//			}
//		}
		
		if(gameObject.GetComponent<Renderer>())
		{
			transform.GetComponent<Renderer>().material.SetVector("_Origin", PulseDistance.playerPos);
			transform.GetComponent<Renderer>().material.SetFloat("_PDistance", PulseDistance.distance);
			transform.GetComponent<Renderer>().material.SetFloat("_PFadeDistance", PulseDistance.fadeDistance);
			transform.GetComponent<Renderer>().material.SetFloat("_PEdgeSoftness", PulseDistance.edgeSoftness);			
		}

	}
	
	public void Glow(bool on)
	{
		if(on)
			transform.GetComponent<Renderer>().material.SetFloat("_RimOn", 1);
		else
			transform.GetComponent<Renderer>().material.SetFloat("_RimOn", 0);
	}
}
