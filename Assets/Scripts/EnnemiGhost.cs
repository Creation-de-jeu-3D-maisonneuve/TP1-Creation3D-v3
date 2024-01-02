using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiGhost : MonoBehaviour
{

    public GameObject jumpscareGhost;
    private Player LeChevalier;
    private ViesManager viesManager;
    private NavMeshAgent navMeshAgent;
    private ZoneGhostSpawn zoneGhostSpawn;
    private float TempsEcouler;

    private Vector3 NextPosition;

    // Start is called before the first frame update
    void Start()
    {
        LeChevalier = FindAnyObjectByType<Player>();

        viesManager = FindAnyObjectByType<ViesManager>();

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
        Player player = collider.GetComponent<Player>();

        //player != null -> S'il existe.
        if (player != null)
        {
            viesManager.JoueurToucher();

            //Respawn est dans le script "Player". le "." permet d'aller le chercher.
            player.Respawn();

            //Instancier le jumpscare
            Instantiate(jumpscareGhost);

            Destroy(gameObject);
        }
    }
}
