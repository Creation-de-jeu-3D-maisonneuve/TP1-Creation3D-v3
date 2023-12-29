using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareChest : MonoBehaviour
{
    //Groupe qui permet de rendre le UI transparent.
    public CanvasGroup canvasGroup;

    //Le temps de fondu (fade-out) en secondes -> de opaque à transparent.
    public float DurerDeFondu = 2f;

    //Compteur de temps -> celui qui va compter le nombres de secondes qui s'est écoulé depuis le début du fondu.
    private float TempsEcouler = 0f;

    //public AudioClip sonJumpscare;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            //Temps réel qui s'est écoulé au fur et à mesure (dans le jeu).
            TempsEcouler += Time.deltaTime;

            //Pas sûr d'avoir complétement compris le ligne de code ci-dessous !!
            canvasGroup.alpha = Mathf.Lerp(1, 0, TempsEcouler / DurerDeFondu);
        }
    }
}
