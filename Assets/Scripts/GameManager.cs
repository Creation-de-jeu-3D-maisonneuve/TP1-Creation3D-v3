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

        //TO DO !! � ENLEVER AVANT
        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            JeuGagner();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JeuPerdu();
        }
        */
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

        string scoreNamesKey = "scoreNames";
        string scoreTimesKey = "scoreTimes";

        //on r�cup�re les scores Names et Times .

        string[] scoreNames = PlayerPrefsX.GetStringArray(scoreNamesKey);

        float[] scoreTimes = PlayerPrefsX.GetFloatArray(scoreTimesKey);

        ///temp -> temporaire .
        string[] tempScoreNames = new string[scoreNames.Length + 1];

        float[] tempScoreTimes = new float[scoreTimes.Length + 1];

        //Copie le contenu de scoreNames dans tempScoreNames.
        scoreNames.CopyTo(tempScoreNames, 0);

        scoreTimes.CopyTo(tempScoreTimes, 0);

        tempScoreNames[scoreNames.Length] = NameManager.NomJoueur;

        tempScoreTimes[scoreTimes.Length] = TempsJeu;

        //trier deux tableaux  selon l'ordre croissant des scores et faire suivre les noms correspondants dans le tableau des noms.
        System.Array.Sort(tempScoreTimes, tempScoreNames);

        /////

        scoreNames = new string[Mathf.Min(3, tempScoreNames.Length)];

        //On veut utiliser la longueur de tempScoreTimes et si celle-ci est plus grande que 3, on utilise 3 � la place.
        scoreTimes = new float[Mathf.Min(3, tempScoreTimes.Length)];

        //scoreNames.Length -> la longueur qu'on veut copier.
        //System.Array.Copy -> aller chercher la documentation pour mieux comprendre et il y a des exemples.
        System.Array.Copy(tempScoreNames, scoreNames, scoreNames.Length);

        System.Array.Copy(tempScoreTimes, scoreTimes, scoreTimes.Length);
        
        //Sauvegarder le tableau scoreNames � la cl� scoreNamesKey .
        PlayerPrefsX.SetStringArray(scoreNamesKey, scoreNames);

        //Sauvegarder le tableau scoreTimes � la cl� scoreTimesKey .
        PlayerPrefsX.SetFloatArray(scoreTimesKey, scoreTimes);

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
