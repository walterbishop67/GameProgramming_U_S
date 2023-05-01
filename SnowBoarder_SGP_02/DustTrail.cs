using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DustTrail : MonoBehaviour
{
   [SerializeField] ParticleSystem crashEffect2;
   void OnCollisionEnter(Collision other) {
    if (other.gameObject.tag == "Graund"){
        crashEffect2.Play();
    }
    
   }
   void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Graund"){
            crashEffect2.Play();
        }
   }
}
