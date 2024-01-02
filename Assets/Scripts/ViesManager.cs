using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ViesManager : MonoBehaviour
{
    //int -> nombres entiers.
    public TextMeshProUGUI TextUI;

    private GameManager gameManager;

    private int nbrDeVies = 5;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePointsDeVies();

        gameManager = FindAnyObjectByType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePointsDeVies()
    {
        TextUI.text = $"{nbrDeVies}";
    }

    public void JoueurToucher()
    {
        nbrDeVies -= 1;
        UpdatePointsDeVies();

        if (nbrDeVies <= 0)
        {
            gameManager.JeuPerdu();
        }
    }

    public void JoueurSoigner()
    {
        nbrDeVies += 1;
        UpdatePointsDeVies();
    }
}
