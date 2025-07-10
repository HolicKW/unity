using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI Text;

    [SerializeField]
    private GameObject gameOverPanel;
    private int coin = 0;

    [HideInInspector] // public이여도 inspector에서 숨겨짐
    public bool isGameOver = false;
    void Awake() //START 메소드 전에 호출되는 메소드
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void IncreaseCoin()
    {
        coin += 1;
        Text.SetText(coin.ToString());

        if (coin % 10 == 0)
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.Upgrade();
            }
        }
    }
    public void SetGameOver()
    {
        isGameOver = true;
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();

        if (enemySpawner != null)
        {
            enemySpawner.StopEnemyRoutine();

        }

        Invoke("ShowGameOverPanel", 1f);

    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
