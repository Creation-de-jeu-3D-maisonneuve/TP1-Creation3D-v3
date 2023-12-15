using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerAvion : MonoBehaviour
{
    public TextMeshProUGUI TextCompteur;

    //nombre d'anneau que l'avion à passé à travers !!
    private int NombreDeAnneauPasse = 0;

    //private int 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateText()
    {
        TextCompteur.text = $"Score : {NombreDeAnneauPasse}";
    }

    public void ScoreAnneau()
    {
        NombreDeAnneauPasse += 1;
    }
    /*
    private void OnTriggerEnter(Collider infoTrigger)
    {
        
    }
    */
}
