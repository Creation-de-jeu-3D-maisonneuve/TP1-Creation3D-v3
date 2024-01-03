using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VieBonus : MonoBehaviour
{
    private ViesManager viesManager;

    // Start is called before the first frame update
    void Start()
    {
        viesManager = FindAnyObjectByType<ViesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider infoTrigger)
    {

        if (infoTrigger.GetComponent<Player>())
        {
            viesManager.JoueurSoigner();

            Destroy(gameObject);
        }
    }
}
