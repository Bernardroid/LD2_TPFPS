using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_ArrowBehaviour : MonoBehaviour {

    public Transform goalPoint;
    float damp = 5f;

	
	void Update ()
    {
        Vector3 lookPos = goalPoint.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damp);
        //transform.LookAt(goalPoint.position);	
	}
}
