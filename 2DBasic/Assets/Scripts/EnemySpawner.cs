using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int enemyIndex = 0;
    int spawnCount = 0;
    float moveSpeed = 5f;

    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f };
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine"); //corountine 
    }

    public void StopEnemyRoutine()
    {
        StopCoroutine("EnemyRoutine");
    }
    [SerializeField]
    private float spawnInterval = 1.5f;

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f); //3초 대기


        while (true)
        {
            foreach (float posX in arrPosX)
            {
                spawnEnemy(posX, enemyIndex, moveSpeed);
            }
            spawnCount++;

            if (spawnCount % 10 == 0)
            {
                enemyIndex = enemyIndex + 1;
                moveSpeed += 1;
            }

            if (enemyIndex >= enemies.Length)
            {
                SpawnBoss();
                enemyIndex = 0;
                moveSpeed = 5f;
            }

            yield return new WaitForSeconds(spawnInterval);
        }

    }

    // Update is called once per frame
    void spawnEnemy(float posX, int index, float moveSpeed)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, 0);
        if (UnityEngine.Random.Range(0, 5) == 0)
        {
            index += 1;
        }
        if (index >= enemies.Length)
        {
            index = enemies.Length - 1;
        }
        GameObject enemyObject = Instantiate(enemies[index], spawnPos, quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);


    }

    void SpawnBoss()
    {
        Instantiate(boss, transform.position, quaternion.identity);
    }

   
}
