using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLuces : MonoBehaviour
{
	public GameObject CPrincipal, CLuces;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Regresar()
	{
		CPrincipal.SetActive(true);
		CLuces.SetActive(false);
	}
}
