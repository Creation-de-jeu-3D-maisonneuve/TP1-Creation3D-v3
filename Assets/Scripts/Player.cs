using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CheckPoint defaultCheckPoint;

    //Le dernier checkpoint activ�
    private CheckPoint lastCheckPoint;

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        //Quand on va rentrer...
        ActiveCheckPoint(defaultCheckPoint);
        
    }

    //M�thode qu'on va appeler depuis le checkpoint pour activer le checkpoint.
    //
    public void ActiveCheckPoint(CheckPoint newCheckPoint)
    {
        //lastCheckPoint != null -> pour voir s'il existe.
        if (lastCheckPoint != null)
        {
            lastCheckPoint.Desactiver();
        }
        lastCheckPoint = newCheckPoint;
        newCheckPoint.Activer();
    }

    //Faire r�apparaitre le joueur.
    public void Respawn()
    {
        // SpawnPoint est dans le script "CheckPoint"
        rigidbody.MovePosition(lastCheckPoint.SpawnPoint.position);
    }
}
