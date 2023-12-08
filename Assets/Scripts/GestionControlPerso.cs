using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GestionControlPerso : MonoBehaviour
{
    public float laVitesse;
    float forceDeDeplacement;

    public float vitesseTourner;

    public float laHauteurDuSaut;

    float forceDuSaut;

    public bool auSol;

    public float ajoutDeGraviter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit infoCollision; //je ne sais pas ce que ça veut dire !

        auSol = Physics.SphereCast(transform.position + new Vector3(0f, 0.6f, 0f), 0.2f, -Vector3.up, out infoCollision, 0.8f); // Difficulter à comprendre.
        // new Vector3(0f, 0.5f, 0f) -> mise en place d'une petite distance entre perso et sol
        // 0.2f -> Je ne sais pas

        forceDeDeplacement = Input.GetAxis("Vertical") * laVitesse; // comprend à moitié
        
        float forceTourner = Input.GetAxis("Mouse X") * vitesseTourner; // comprend seulement le 3/4 de cette ligne.

        transform.Rotate(0f, forceTourner, 0f); // transform.Rotate( x, y, z);

        //GetComponent<Animator>().SetBool("sauter", !auSol); // faire jouer animation de saut quand perso n'est pas sur le sol.

        /*
        if (Input.GetKeyDown(KeyCode.Space) && auSol)
        {
            forceDuSaut = laHauteurDuSaut;
            GetComponent<Animator>().SetBool("sauter", true);
        }
        */
    }

    void FixedUpdate()
    {
        /*
        if (auSol)
        {
            GetComponent<Rigidbody>().AddRelativeForce(0f, forceDuSaut, forceDeDeplacement, ForceMode.VelocityChange);
        }
        else
        {
            GetComponent<Rigidbody>().AddRelativeForce(0f, ajoutDeGraviter, forceDeDeplacement, ForceMode.VelocityChange);
        }
        */

        GetComponent<Rigidbody>().AddRelativeForce(0f, 0f, forceDeDeplacement, ForceMode.VelocityChange);

        GetComponent<Animator>().SetFloat("laVitesse", forceDeDeplacement);

        /*
        forceDuSaut = 0f;
        GetComponent<Animator>().SetBool("saut", false);
        */
    }
}
