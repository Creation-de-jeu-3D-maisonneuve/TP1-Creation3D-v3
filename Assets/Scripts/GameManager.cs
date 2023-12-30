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

    //Temps qu'� dur� la partie.
    public static float TempsJeu;

    //Temps de d�part. Nombres de secondes depuis que le jeu � commenc�.
    private float TempsDepart;

    //Nom qui commence avec une majuscule quand c'est "public" ou pour une "classe" ou une "m�thode".
    private List<Transform> chestSpawnPoints = new();


    // Start is called before the first frame update
    void Start()
    {
        UpdateText();

        //TempsDepart = nombres de secondes depuis que le jeu � commenc�.
        TempsDepart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (chestSpawnPoints.Count > 0)
        {
            // � revoir avec tuteur !!
            for (int i = 0; i < CoffresATrouvrer; ++i)
            {
                Transform ChestSpawnPoint = chestSpawnPoints[Random.Range(0, chestSpawnPoints.Count)];

                //Il faut Instantier le "bon coffre".
                //Instantiate(Object original, Transform parent);
                Instantiate(bonCoffre, ChestSpawnPoint);

                chestSpawnPoints.Remove(ChestSpawnPoint);
            }
            // foreach -> D�clare un "transform"
            // � revoir avec tuteur !!
            foreach (Transform ChestSpawnPoint in chestSpawnPoints)
            {
                //Il faut Instantier le "mauvais coffre".
                Instantiate(MauvaisCoffre, ChestSpawnPoint);
            }
            // Supprime tous les �l�ments de la liste.
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

        if (CoffresTrouver >= CoffresATrouvrer)
        {
            JeuGagner();
        }
    }

    private void JeuGagner()
    {
        //Enlever le temps pass� dans la sc�ne d'introduction jusqu'� ce que je commence la jeu dans la sc�ne principal.
        TempsJeu = Time.time - TempsDepart;

        string keyname = "pointage";
        //vrai ou faux si la cl� existe ou pas.
        //PlayerPrefs.HasKey(keyname) -> on regarde s'il y a d�j� un score enregistr�.
        // !PlayerPrefs.HasKey(keyname) -> on regarde s'il n'y a pas de score enregistr�.
        //PlayerPrefs.GetFloat(keyname) > TempsJeu -> on regarde si le score d�j� enregistr� est sup�rieur au nouveau.
        if (!PlayerPrefs.HasKey(keyname) || PlayerPrefs.GetFloat(keyname) > TempsJeu)
        {
            PlayerPrefs.SetFloat(keyname, TempsJeu);
        } 

        Gagner = true;
        SceneManager.LoadScene(2);
    }



    public void JeuPerdu()
    {
        Gagner = false;
        SceneManager.LoadScene(2);
    }

    public void DeclareSpawnPoint(Transform ChestSpawnPoint)
    {
        chestSpawnPoints.Add(ChestSpawnPoint);
    }
}
