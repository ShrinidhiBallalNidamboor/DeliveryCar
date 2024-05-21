using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steer = 0.1f;
    [SerializeField] float move = 0.01f;
    float steerSpeed = 250f;
    float moveSpeed = 15f;
    float steerSlowSpeed = 150f;
    float moveSlowSpeed = 5f;
    float steerFastSpeed = 350f;
    float moveFastSpeed = 25f;

    // Update is called once per frame
    void Update()
    {
        float steerAmount = - Input.GetAxis("Horizontal")*steerSpeed*Time.deltaTime;
        float moveAmount =  Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);    
    }
    void OnCollisionEnter2D(Collision2D other){
        steerSpeed = steerSlowSpeed;
        moveSpeed = moveSlowSpeed;
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="SpeedUp"){
            steerSpeed = steerFastSpeed;
            moveSpeed = moveFastSpeed;
        }
    }
}
