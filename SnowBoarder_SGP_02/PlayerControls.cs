
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    public float normalSpeed = 20f; //its same as SerializeField
    Rigidbody2D rb2d;
    bool canMove = true;
    SurfaceEffector2D surfaceEffector2D;
    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType <SurfaceEffector2D>(); 
    }
    
    void Update(){
        if (canMove){
            boostPlayer();
            rotatePlayer();
        }
        
    }
    public void disableControl(){
        canMove = false;
    }


    void boostPlayer(){
        if(Input.GetKey(KeyCode.UpArrow)){
             surfaceEffector2D.speed = boostSpeed;
        }else
             surfaceEffector2D.speed = normalSpeed;
    }

    
    void rotatePlayer(){
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb2d.AddTorque(torqueAmount);
        }else if(Input.GetKey(KeyCode.RightArrow)){
            rb2d.AddTorque(-torqueAmount);
        }
    }
}