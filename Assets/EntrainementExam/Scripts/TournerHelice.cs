using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournerHelice : MonoBehaviour
{
    public float VitesseRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, VitesseRotation * Time.deltaTime, Space.Self);

    }
}
