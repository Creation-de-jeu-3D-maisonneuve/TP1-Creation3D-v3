using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangementDebut : MonoBehaviour
{
    public TMP_InputField NomDuJoueur;

    // Start is called before the first frame update
    void Start()
    {
        /*
        string a = null;
        string b = "";
        string c = "Toto";
        Debug.Log($"a == null = {a == null}");
        Debug.Log($"a == \"\" = {a == ""}");
        Debug.Log($"b == null = {b == null}");
        Debug.Log($"b == \"\" = {b == ""}");
        Debug.Log($"c == null = {c == null}");
        Debug.Log($"c == \"\" = {c == ""}");
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        if (NomDuJoueur.text != null && NomDuJoueur.text != "")
        {
            NameManager.NomJoueur = NomDuJoueur.text;
            SceneManager.LoadScene(1);
        }
    }
}
