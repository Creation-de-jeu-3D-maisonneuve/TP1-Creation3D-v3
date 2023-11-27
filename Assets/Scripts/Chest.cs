using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        //Un exemple 
        gameManager.ChestsFound();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
