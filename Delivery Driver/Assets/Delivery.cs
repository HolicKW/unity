using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    public Color32 hasPackageColor = new Color32(1,1,1,1);
    public Color32 noPackageColor = new Color32(1,1,1,1);

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package Picked Up: " + other.name);
            hasPackage = true;
            spriteRenderer.color = hasPackageColor; // Change color to indicate package is picked up
            Destroy(other.gameObject,1f); // Destroy the package after picking it up
        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered to: " + other.name);
            hasPackage = false;
            spriteRenderer.color = noPackageColor; // Change color to indicate package is delivered
            // Here you could add logic to remove the package or update the score
        }
    }
}
