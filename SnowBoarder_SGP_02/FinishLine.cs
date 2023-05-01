using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] float delay = 1f; 
    
    void OnTriggerEnter2D(Collider2D other) 
    {
      finishEffect.Play();
      GetComponent<AudioSource>().Play(); 
      Invoke("reloadScene", delay);
    }
    void reloadScene (){
      SceneManager.LoadScene(0);
    }
}
