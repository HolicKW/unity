using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 10f;

    private float minY = -7;
    [SerializeField]
    private float hp = 1f;

    [SerializeField]
    private GameObject Coin;
    // Start is called before the first frame update
    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) //isTrigger 활성화시 처리하는 메소드
    {
        if (other.gameObject.tag == "Weapon")
        { // 물체와 충돌한 오브젝트를 확인하기
            Weapon weapon = other.GetComponent<Weapon>();
            hp -= weapon.damage;
            if (hp <= 0)
            {
                if (gameObject.tag == "Boss")
                {
                    GameManager.instance.SetGameOver();
                }
                Destroy(gameObject);
                Instantiate(Coin, transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject);
        }
    }
    
    
}
