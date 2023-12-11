using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDeFin : MonoBehaviour
{
    public GameObject TextGagne;
    public GameObject TextPerdu;



    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<TextMeshProUGUI>().text = NameManager.NomJoueur;

        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();

        //Pour chaque text dans le tableau "texts".
        foreach (TextMeshProUGUI text in texts)
        {
            text.text = text.text.Replace("NOM_DU_JOUEUR", NameManager.NomJoueur);
        }

        if (GameManager.Gagner)
        {
            Debug.Log("Gagner");

            TextGagne.SetActive(true);
            TextPerdu.SetActive(false);
        }
        else
        {
            Debug.Log("Perdu");

            TextGagne.SetActive(false);
            TextPerdu.SetActive(true);
        }
        
        //Essayer de faire charger la scène quand il perd et quand il gagne !!
        //Voir notes de cours pour une des méthodes que je peux utiliser pour le faire.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
