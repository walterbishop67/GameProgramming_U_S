using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    [SerializeField] float destroyT = 0.5f;



    SpriteRenderer renderer;

    void Start() {
        renderer = GetComponent<SpriteRenderer>();
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("uupppsss!!!");
   }

    void OnTriggerEnter2D(Collider2D other) { 
        if(other.tag == "Package"){
            if (hasPackage == false){
                
                Debug.Log("Package picked up");
                renderer.color = hasPackageColor;
                hasPackage = true;
                Destroy(other.gameObject ,destroyT);
            }  
        } else if (other.tag == "Customer"){
            if (hasPackage == true){
                Debug.Log("Delivered package");
                renderer.color = noPackageColor;
            hasPackage = false;
            } else{
                Debug.Log("you have already delivered");
            }
        }
    }
}

