using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private List<Card> allCards;
    private Card flipedCard;
    private bool isFlipping = false;

    [SerializeField]
    private Slider timeoutSlider;
    [SerializeField]
    private float timeLimit = 60f;
    private float currentTime;
    [SerializeField]
    private TextMeshProUGUI timeoutText;

    [SerializeField]
    private GameObject gameOverPanel;
    private int mathcesFound = 0;
    private int totalMatches = 10; // 총 매치해야 할 카드 쌍의 수
    [SerializeField]
    private TextMeshProUGUI gameOverText;
    private bool isGameOver = false;
    // Start is called before the first frame update

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Board board = FindObjectOfType<Board>();
        allCards = board.GetCardList();
        currentTime = timeLimit;
        SetCurrentTimeText();
        StartCoroutine("FlipAllCardsCoroutine");
    }

    void SetCurrentTimeText()
    {
        int timeSec = Mathf.CeilToInt(currentTime);
        timeoutText.SetText(timeSec.ToString());
    }

    IEnumerator FlipAllCardsCoroutine()
    {
        isFlipping = true;

        yield return new WaitForSeconds(1f);
        FlipAllCards();
        yield return new WaitForSeconds(3f);
        FlipAllCards();
        yield return new WaitForSeconds(0.5f);
        isFlipping = false;

        yield return StartCoroutine("CountDownTimerRoutine");
    }

    IEnumerator CountDownTimerRoutine()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timeoutSlider.value = currentTime / timeLimit;
            SetCurrentTimeText();
            yield return null; // 다음 프레임까지 대기

        }

        GameOver(false);
    }


    void FlipAllCards()
    {
        foreach (Card card in allCards)
        {
            card.FlipCard();
        }
    }

    public void CardClicked(Card card)
    {
        if (isFlipping || isGameOver)
        {
            return; // 이미 카드가 뒤집히는 중이면 클릭 무시
        }
        card.FlipCard();

        if (flipedCard == null)
        {
            flipedCard = card;
        }
        else
        {
            StartCoroutine(CheckMatchCoroutine(flipedCard, card));
        }
    }

    IEnumerator CheckMatchCoroutine(Card card1, Card card2)
    {
        isFlipping = true;
        if (card1.cardID == card2.cardID)
        {
            card1.setMatched();
            card2.setMatched();
            mathcesFound++;
            if (mathcesFound == totalMatches)
            {
                GameOver(true);
            }
        }
        else
        {
            Debug.Log("No Match!");
            yield return new WaitForSeconds(1f);
            card1.FlipCard();
            card2.FlipCard();
            yield return new WaitForSeconds(0.4f);
        }
        isFlipping = false;
        flipedCard = null;
    }
    void GameOver(bool success)
    {
        if (!isGameOver)
        {
            isGameOver = true;
            StopCoroutine("CountDownTimerRoutine");

            if (success)
            {
                gameOverText.SetText("You Win!");
            }
            else
            {
                gameOverText.SetText("Game Over!");
                // 게임 오버 처리 로직
            }

            Invoke("showGameOverPanel", 2f);
        }
    }
    void showGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
