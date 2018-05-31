using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Principal : MonoBehaviour
{
	public GameObject CPrincipal,
						CLuces, CClimas, CAccesos,
						CAspersores;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GUILuces()
	{
		CPrincipal.SetActive(false);
		CLuces.SetActive(true);
		CClimas.SetActive(false);
		CAccesos.SetActive(false);
		CAspersores.SetActive(false);
	}

	public void GUIClimas()
	{
		CPrincipal.SetActive(false);
		CLuces.SetActive(false);
		CClimas.SetActive(true);
		CAccesos.SetActive(false);
		CAspersores.SetActive(false);
	}

	public void GUIAccesos()
	{
		CPrincipal.SetActive(false);
		CLuces.SetActive(false);
		CClimas.SetActive(false);
		CAccesos.SetActive(true);
		CAspersores.SetActive(false);
	}

	public void GUIAspersores()
	{
		CPrincipal.SetActive(false);
		CLuces.SetActive(false);
		CClimas.SetActive(false);
		CAccesos.SetActive(false);
		CAspersores.SetActive(true);
	}
}
