using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public GameObject pos1, pos2, pos3, pos4, Camara;
    public int cam;
	// Use this for initialization
	void Start ()
    {
        this.cam = 0;
        OtraCamara();
	}

    public void OtraCamara()
    {
        this.cam++;
        switch (this.cam)
        {
            case 1:
                Camara.transform.position = pos1.transform.position;
                Camara.transform.rotation = Quaternion.Euler(new Vector3(45, -45, 0));
                break;
            case 2:
                Camara.transform.position = pos2.transform.position;
                Camara.transform.rotation = Quaternion.Euler(new Vector3(45, -135, 0));
                break;
            case 3:
                Camara.transform.position = pos3.transform.position;
                Camara.transform.rotation = Quaternion.Euler(new Vector3(45, -225, 0));
                break;
            case 4:
                Camara.transform.position = pos4.transform.position;
                Camara.transform.rotation = Quaternion.Euler(new Vector3(45, -315, 0));
                this.cam = 0;
                break;
            default:
                break;
        }
    }
}
