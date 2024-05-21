using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour{ 
    bool hasPackage = false;
    [SerializeField] float delay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other){
        Debug.Log("Ouch");
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Package"&&hasPackage==false){
            Debug.Log("Package Picked Up");
            hasPackage = true;
            Destroy(other.gameObject, delay);
            spriteRenderer.color=hasPackageColor;
        }
        else if(other.tag=="Customer"&&hasPackage){
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color=noPackageColor;
        }
    }
}
