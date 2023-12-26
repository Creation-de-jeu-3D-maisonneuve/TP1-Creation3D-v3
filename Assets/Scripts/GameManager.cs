using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //int -> nombres entiers
    public TextMeshProUGUI TextUI;

    private int CoffresATrouvrer = 4;
    private int CoffresTrouver = 0;

    public GameObject bonCoffre;
    public GameObject MauvaisCoffre;

    public static bool Gagner;

    private int nbrDeVies = 5;

    //Nom qui commence avec une majuscule quand c'est "public" ou pour une "classe" ou une "méthode".
    private List<Transform> chestSpawnPoints = new();

    // Start is called before the first frame update
    void Start()
    {

        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (chestSpawnPoints.Count > 0)
        {
            // À revoir avec tuteur !!
            for (int i = 0; i < CoffresATrouvrer; ++i)
            {
                Transform ChestSpawnPoint = chestSpawnPoints[Random.Range(0, chestSpawnPoints.Count)];

                //Il faut Instantier le "bon coffre".
                //Instantiate(Object original, Transform parent);
                Instantiate(bonCoffre, ChestSpawnPoint);

                chestSpawnPoints.Remove(ChestSpawnPoint);
            }
            // foreach -> Déclare un "transform"
            // À revoir avec tuteur !!
            foreach (Transform ChestSpawnPoint in chestSpawnPoints)
            {
                //Il faut Instantier le "mauvais coffre".
                Instantiate(MauvaisCoffre, ChestSpawnPoint);
            }
            // Supprime tous les éléments de la liste.
            chestSpawnPoints.Clear();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            JeuGagner();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JeuPerdu();
        }
    }

    void UpdateText()
    {
        TextUI.text = $"Coffres : {CoffresTrouver}/{CoffresATrouvrer}";


    }

    public void ChestsFound()
    {
        CoffresTrouver += 1;
        UpdateText();

        if (CoffresTrouver == CoffresATrouvrer)
        {
            JeuGagner();
        }
    }

    private void JeuGagner()
    {
        Gagner = true;
        SceneManager.LoadScene(2);
    }

    private void JeuPerdu()
    {
        Gagner = false;
        SceneManager.LoadScene(2);
    }

    public void DeclareSpawnPoint(Transform ChestSpawnPoint)
    {
        chestSpawnPoints.Add(ChestSpawnPoint);
    }

    public void JoueurToucher()
    {
        nbrDeVies -= 1;

        if (nbrDeVies <= 0)
        {
            JeuPerdu();
        }
    }
}
