using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareChest : MonoBehaviour
{
    public GameObject jumpscareChest;
    public AudioClip sonJumpscare;

    // Start is called before the first frame update
    void Start()
    {
        jumpscareChest.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider infoTrigger)
    {
        jumpscareChest.SetActive(true);
        //GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().PlayOneShot(sonJumpscare);
    }
}
