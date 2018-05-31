using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInformes : MonoBehaviour
{
    public GameObject CInformes, CPrincipal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Regresar()
    {
        CInformes.SetActive(false);
        CPrincipal.SetActive(true);
    }
}
