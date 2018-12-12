using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CamChange : MonoBehaviour {

    public Transform camInside;
    public Transform camOutside;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            Camera.main.transform.rotation = camInside.rotation;
            Camera.main.transform.position = camInside.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            Camera.main.transform.position = camOutside.position;
            Camera.main.transform.rotation = camOutside.rotation;
        }
    }

}
