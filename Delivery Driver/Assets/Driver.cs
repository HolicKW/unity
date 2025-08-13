using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float carSpeed = 300f;
    [SerializeField]
    private float moveSpeed = 20f;
    [SerializeField]
    private float slowSpeed = 15f;
    [SerializeField]
    private float fastSpeed = 30f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed; // Slow down the car on collision
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            Debug.Log("Boost Activated!");
            moveSpeed = fastSpeed; // Increase speed when boost is activated
        }

    }

}
