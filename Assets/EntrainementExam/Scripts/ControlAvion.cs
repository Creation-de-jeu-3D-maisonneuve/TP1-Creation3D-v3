using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAvion : MonoBehaviour
{

    Rigidbody avion;

    //Vector 3 = 3 floats -> x, y et z
    Vector3 PositionAvion;

    // Start is called before the first frame update
    void Start()
    {
        avion = GetComponent<Rigidbody>();

        //Vector3.zero -> x, y et z à 0
        //Vector3.one - > x, y et z à 1
        PositionAvion = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //PositionAvion.x -= 360-> 360 mètres vers la gauche.
            //PositionAvion.x -= 360 * Time.deltaTime -> mètres par seconde multiplier par le temps qui donne une distance qui c'est passé dans
            //ce laps de temps
            //Ex.: 100m/h;

            PositionAvion.x -= 360 * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            PositionAvion.x += 360 * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        avion.MovePosition(PositionAvion);
    }
}
