using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TP_CanvasManager : MonoBehaviour {

    public GameObject key;
    public GameObject hammer;
	
	void Update ()
    {
        key.SetActive(TP_ObjectBehaviour.hasKey);
        hammer.SetActive(TP_ObjectBehaviour.hasHammer);
    }
}
