using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * 3f * Time.deltaTime; // 맵이 왼쪽으로 이동
        if(transform.position.x < -20f) // 맵이 화면 밖으로 나가면
        {
            transform.position = new Vector3(25f, transform.position.y, transform.position.z); // 맵을 오른쪽으로 재배치
        }
    }
}
