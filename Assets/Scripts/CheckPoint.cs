using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject CheckPointActif;
    public GameObject CheckPointInactif;

    public Transform SpawnPoint;

    //Awake -> Appeller avant le "Start".
    void Awake()
    {
        Desactiver();
    }

    public void Activer()
    {
        CheckPointActif.SetActive(true);
        CheckPointInactif.SetActive(false);
    }
    public void Desactiver()
    {
        CheckPointActif.SetActive(false);
        CheckPointInactif.SetActive(true);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player != null)
        {
            //this -> il s'envoie lui-même. this = lui-même
            player.ActiveCheckPoint(this); 
        }
    }

}
