using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI textGoal; // 점수 텍스트 UI

    [SerializeField]

    private GameObject btnRetry; // 재시작 버튼 UI
    public int goal = 15; // 목표 점수

    public bool isGameOver = false; // 게임 오버 상태   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this; //싱글톤은 this를 할당한다.

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        textGoal.SetText(goal.ToString()); // 목표 점수를 UI에 표시
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DecreaseGoal()
    {
        goal--; // 목표 점수를 감소시킵니다.
        textGoal.SetText(goal.ToString()); // UI에 업데이트된 목표 점수를 표시합니다.

        if (goal <= 0)
        {
            SetGameOver(true);

        }
    }

    public void SetGameOver(bool success)
    {
        if (!isGameOver)
        {
            isGameOver = true; // 게임 오버 상태를 true로 설정

            Camera.main.backgroundColor = success ? Color.green : Color.red; // 게임 오버 시 배경색을 변경합니다.

            Invoke("ShowRetryButton", 1f); // 1초 후에 재시작 버튼을 표시합니다.

        }
    }

    void ShowRetryButton()
    {
        btnRetry.SetActive(true); // 재시작 버튼을 활성화합니다.
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene"); // 현재 씬을 다시 로드하여 게임을 재시작합니다.
    }
}
