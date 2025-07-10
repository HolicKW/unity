using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    private float minY = -7;
    void Start()
    {
        Jump(); 
    }

    void Jump()
    {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        float randomJumpForce = Random.Range(4f,8f);
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;
        jumpVelocity.x = Random.Range(-2f, 2f);
        rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse); //어느 방향으로 힘을 가함
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
