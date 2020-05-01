using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Animator camShake;
    

    public void cameraShake()
    {
        camShake.SetTrigger("shake");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
           cameraShake();
           //shake the camera
        }
    }
}
