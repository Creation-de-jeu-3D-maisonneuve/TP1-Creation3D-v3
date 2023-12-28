using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneGhostSpawn : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject ghostPrefrab;
    private GameObject ghost;

    private void OnTriggerEnter(Collider collider)
    {
        Player player = collider.GetComponent<Player>();

        //player != null -> voir si "player" existe et n'est pas �gale � rien.
        if (player != null) 
        {

            //transform.position -> le centre de la zone.
            //
            Vector3 origin = transform.position + (transform.position - player.transform.position);

            origin.y = transform.position.y + 100;

            //Mathf.Infinity -> infiniment vers le bas. Il s'arr�te au moment qu'il rencontre un collider, soit le terrain.
            //LayerMask -> on veut que le Raycast ignore tout sauf le terrain.
            //hitinfo -> le r�sultat du Raycast.
            if (Physics.Raycast(origin, Vector3.down, out RaycastHit hitInfo, Mathf.Infinity, layerMask))
            {
                //Quaternion.identity -> La rotation par d�faut, soit x = 0 , y = 0 , z = 0 .
                //
                ghost = Instantiate(ghostPrefrab, hitInfo.point, Quaternion.identity);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        Destroy(ghost);
    }
}
