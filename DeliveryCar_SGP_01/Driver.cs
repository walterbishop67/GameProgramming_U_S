
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]float steerSpeed = 0.2f;
    [SerializeField]float moveSpeed = 0.01f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 25f;
    float speed2;
    void Start()
    {
        //transform.Rotate(0,0,45);
        speed2 = moveSpeed;
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed *  Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
       
    }
     void OnTriggerEnter2D(Collider2D other1) {
            if(other1.tag == "boost"){
                moveSpeed = boostSpeed;
                Debug.Log("you re boosting ");
            }else if(other1.tag == "tumsek"){
                moveSpeed = slowSpeed;
                Debug.Log("you re slowing");
            }
        }
        void OnCollisionEnter2D(Collision2D other) {
            moveSpeed = slowSpeed;
        
        }
}