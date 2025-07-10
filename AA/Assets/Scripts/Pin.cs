using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float moveSpeed = 10f;

    private bool isPinned = false;
    private bool isLaunched = false;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate() // 
    {
        Debug.Log("delta time: " + Time.deltaTime);
        if (!isPinned && isLaunched)
        {
            // Move the pin upwards at a constant speed
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isPinned = true;
        if (other.gameObject.tag == "Target")
        {
            GameObject childObject = transform.GetChild(0).gameObject; //GetChild는 Pin 오브젝트의 첫 번째 자식 오브젝트를 가져옵니다.
            SpriteRenderer childSprite = childObject.GetComponent<SpriteRenderer>();
            childSprite.enabled = true; // Enable the child sprite renderer
            transform.SetParent(other.gameObject.transform);

            GameManager.instance.DecreaseGoal(); // 목표 점수를 감소시킵니다.
        }
        else if(other.gameObject.tag == "Pin")
        {
            GameManager.instance.SetGameOver(false); 
        }
        
    }
    
    public void Launch()
    {
        isLaunched = true;        
    }
}
