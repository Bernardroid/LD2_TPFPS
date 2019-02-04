using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_ObjectBehaviour : MonoBehaviour {

    RaycastHit hitInfo;

    public GameObject objKey;
    public GameObject door;
    public GameObject hammer;

    public static bool hasKey = false;
    public static bool hasHammer = false;

    public LayerMask objectMask;

    void Start () {
        hitInfo = new RaycastHit();
	}
	
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, objectMask) && hitInfo.transform.tag == "Clickable")
            {
                Debug.Log("CLICKABLE! : " + hitInfo.transform.name);
                if (hitInfo.transform.name == "Llave")
                {
                    hasKey = true;
                    objKey.SetActive(false);
                }
                if (hitInfo.transform.name == "Hammer")
                {
                    hasHammer = true;
                    hammer.SetActive(false);
                }
                if (hitInfo.transform.name == "Espejo" && hasHammer)
                {
                    objKey.SetActive(true);
                }
                if (hitInfo.transform.name == "Puertas" && hasKey)
                {
                    Debug.Log("CONDITIONS MET");
                    hasKey = false;
                    Destroy(door);
                }
            }
        }
	}
}
