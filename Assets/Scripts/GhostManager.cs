using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GhostManager : MonoBehaviour
{
    //int -> nombres entiers
    public TextMeshProUGUI TextUI;

    private GameManager gameManagerCoffre;

    private int nbrDeVies = 5;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePointsDeVies();

        gameManagerCoffre = FindAnyObjectByType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdatePointsDeVies()
    {
        TextUI.text = $"{nbrDeVies}";
    }

    public void JoueurToucher()
    {
        nbrDeVies -= 1;
        UpdatePointsDeVies();

        if (nbrDeVies <= 0)
        {
            gameManagerCoffre.JeuPerdu();
        }
    }
}
