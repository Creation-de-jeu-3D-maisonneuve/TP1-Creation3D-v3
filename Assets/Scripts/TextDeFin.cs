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
        //Essayer de faire charger la sc�ne quand il perd et quand il gagne !!
        //Voir notes de cours pour une des m�thodes que je peux utiliser pour le faire.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
