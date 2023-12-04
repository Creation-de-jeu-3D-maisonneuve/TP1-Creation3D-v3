using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDeFin : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = NameManager.NomJoueur;
        //Essayer de faire charger la scène quand il perd et quand il gagne !!
        //Voir notes de cours pour une des méthodes que je peux utiliser pour le faire.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
