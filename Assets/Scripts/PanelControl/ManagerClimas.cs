using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerClimas : MonoBehaviour
{
	public GameObject CPrincipal, CClimas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Regresar()
	{
		CPrincipal.SetActive(true);
		CClimas.SetActive(false);
	}
}
