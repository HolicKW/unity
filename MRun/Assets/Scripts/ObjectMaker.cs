using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] floorObject;
    [SerializeField]
    private GameObject[] snailObject;
    void Start()
    {
        SpawnEnemyRoutine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void SpawnEnemyRoutine()
    {
        StartCoroutine("CreateFloorObject");
    }
    IEnumerator CreateFloorObject()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, floorObject.Length);
            Instantiate(floorObject[randomIndex], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f); // 1.5초 간격으로 생성
        }
        

    }   
}
