using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestRandom : MonoBehaviour
{

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        gameManager.DeclareSpawnPoint(transform);
    }

    
}
