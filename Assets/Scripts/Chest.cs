using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject CoffreOuvert;
    public GameObject CoffreFermer;
    private bool CoffreDejaOuvert = false;

    public bool BonCoffre = true;

    // Start is called before the first frame update
    void Start()
    {

        CoffreFermer.SetActive(true);
        CoffreOuvert.SetActive(false);

        gameManager = FindAnyObjectByType<GameManager>();

        //Un exemple :
        //gameManager.ChestsFound();

        /*Faire le Trigger pour ouvrir chest et l'enlever apr�s �tre activer. Emp�cher de rappeler le
          ChestsFound. �viter que le nombre de coffres trouv�s augmente de 1 � chaque fois que le personnage
          r�entre dans le trigger (box collider).
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider infoTrigger)
    {
        //if (infoTrigger.GetComponent<Player>()) <- m�me chose que.. -> if (infoTrigger.GetComponent<Player>() != null)
        if (infoTrigger.GetComponent<Player>() && !CoffreDejaOuvert)
        {
            CoffreFermer.SetActive(false);
            CoffreOuvert.SetActive(true);
            CoffreDejaOuvert = true;

            if (BonCoffre)
            {
                 gameManager.ChestsFound();
            }
        }
    }
}
