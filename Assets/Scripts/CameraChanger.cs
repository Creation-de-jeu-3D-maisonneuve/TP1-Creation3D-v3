using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    private CamControlOpt camControlOpt;

    // Start is called before the first frame update
    void Start()
    {
        camControlOpt = FindAnyObjectByType<CamControlOpt>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Player>())
        {
            camControlOpt.ActivationCamera(2);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Player>())
        {
            camControlOpt.ActivationCamera(0);
        }
    }
}
