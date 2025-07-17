using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.Mathematics;
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
    public BoxCollider2D PlyaerboxCollider; //플레이어 충돌 처리
    private float desFaultTimer = 5; // 디폴트 스킬 타이머

    [SerializeField]
    private TextMeshProUGUI desFaultText;

    [SerializeField]
    private GameObject desFaultSkill;

    [SerializeField]
    private Collider2D playerCollider;

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
        DesFaultTimerUpdate();
        DesFaultSkill();
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

    private void DesFaultSkill()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (desFaultTimer == 0)
            {
                Debug.Log("디폴트 스킬 사용 : " + desFaultTimer + "초");
                GameObject obj = Instantiate(desFaultSkill, transform.position, Quaternion.identity);
                playerCollider.isTrigger = false;
                Destroy(obj, 2f);
                Invoke("istriggered", 2f); // 2초 후에 플레이어 충돌 활성화
                desFaultTimer = 6f; // 디폴트 스킬 타이머 초기화
                desFaultText.text = desFaultTimer.ToString();

            }

        }
    }
    private void DesFaultTimerUpdate()
    {
        if (desFaultTimer > 0)
        {
            desFaultTimer -= Time.deltaTime; // 타이머 감소
            if (desFaultTimer < 1f)
            {
                desFaultTimer = 0;
            }
            desFaultText.text = Mathf.FloorToInt(desFaultTimer).ToString();


        }
    }

    private void istriggered()
    {
        if (PlyaerboxCollider.isTrigger == true)
        {
            PlyaerboxCollider.isTrigger = false; // 플레이어 충돌 활성화
        }
        else
        {
            PlyaerboxCollider.isTrigger = true; // 플레이어 충돌 비활성화
        }
    }
}
