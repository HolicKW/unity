using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText; // 인스펙터에서 할당
    private float score = 0f;
    public float scoreIncreaseRate = 1f; // 1초에 1점 증가
    public UnityEngine.UI.Image[] Health;
    [SerializeField]
    private Sprite[] Health_Change;

    public int Hp = 3; // 플레이어의 초기 체력
    public int Hp_index = 0; // 현재 체력 이미지 인덱스



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        ChangeHp();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUpdate();
    }

    private void ScoreUpdate()
    {
        score += scoreIncreaseRate * Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    private void ChangeHp()
    {
        Health[Hp_index].sprite = Health_Change[1];
    }
}
