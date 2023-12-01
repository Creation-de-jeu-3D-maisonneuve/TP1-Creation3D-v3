using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControlOpt : MonoBehaviour
{
    public GameObject[] lesCameras;

    // Start is called before the first frame update
    void Start()
    {
        ActivationCamera(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivationCamera(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivationCamera(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivationCamera(2);
        }
    }

    public void ActivationCamera(int indexCamActivation)
    {
        foreach(GameObject laCamera in lesCameras)
        {
            laCamera.SetActive(false);
        }
        lesCameras[indexCamActivation].SetActive(true);
    }
}
