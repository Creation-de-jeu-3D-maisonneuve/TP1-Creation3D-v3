using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiGhost : MonoBehaviour
{
    private Player LeChevalier;
    private GhostManager ghostManager;
    private NavMeshAgent navMeshAgent;
    private ZoneGhostSpawn zoneGhostSpawn;
    private float TempsEcouler;

    private Vector3 NextPosition;

    // Start is called before the first frame update
    void Start()
    {
        LeChevalier = FindAnyObjectByType<Player>();

        ghostManager = FindAnyObjectByType<GhostManager>();

        navMeshAgent = GetComponent<NavMeshAgent>();

        zoneGhostSpawn = FindAnyObjectByType<ZoneGhostSpawn>();

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
            ghostManager.JoueurToucher();

            //Instancier le jumpscare
            

            Destroy(gameObject);
        }
    }
}
