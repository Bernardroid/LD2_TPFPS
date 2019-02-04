using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_CheckpointBehaviour : MonoBehaviour {

    public Transform[] checkPointRespawns;


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            int randomIndex = Random.Range(0, checkPointRespawns.Length - 1);
            while(checkPointRespawns[randomIndex].position == transform.position)
            {
                randomIndex = Random.Range(0, checkPointRespawns.Length - 1);
            }

            transform.position = checkPointRespawns[randomIndex].position;

            FPS_Timer.timeLeft += 30;
        }
    }


}
