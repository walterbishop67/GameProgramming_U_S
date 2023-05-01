using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetected : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrash = false;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Graund" && !hasCrash){
            hasCrash = true;
            crashEffect.Play();
            FindObjectOfType<PlayerControls>().disableControl();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("reloadScene", delay);
         }  
    }   
    void reloadScene(){
         SceneManager.LoadScene(0);
    }
}
