using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiGhost : MonoBehaviour
{
    private Player LeChevalier;
    private GameManager gameManager;
    private NavMeshAgent navMeshAgent;
    private float TempsEcouler;

    private Vector3 NextPosition;

    // Start is called before the first frame update
    void Start()
    {
        LeChevalier = FindAnyObjectByType<Player>();

        gameManager = FindAnyObjectByType<GameManager>();

        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        //Temps écoulé - temps entre chaque mise à jour de destination
        TempsEcouler += Time.deltaTime;

        if (TempsEcouler > 0.5f)
        {
            navMeshAgent.SetDestination(LeChevalier.transform.position);
            TempsEcouler = 0;
        }
    }



    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Player>())
        {
            gameManager.JoueurToucher();

            //Instancier le jumpscare

            Destroy(gameObject);
        }
    }
}
