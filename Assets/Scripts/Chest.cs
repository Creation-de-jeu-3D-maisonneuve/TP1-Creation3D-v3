using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        //Un exemple :
        gameManager.ChestsFound();

        /*Faire le Trigger pour ouvrir chest et l'enlever apr�s �tre activer. Emp�cher de rappeler le
          ChestsFound. �viter que le nombre de coffres trouv�s augmente de 1 � chaque fois que le personnage
          r�entre dans le trigger (box collider).
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
