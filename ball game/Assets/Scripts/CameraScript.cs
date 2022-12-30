using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
     public GameObject player;
    private Vector3 cameraLocation;

    void Start(){
        cameraLocation=this.transform.position;
    }

    //used to make view 3person
    void LateUpdate(){
        this.transform.position = player.transform.position + cameraLocation;

    }
}
