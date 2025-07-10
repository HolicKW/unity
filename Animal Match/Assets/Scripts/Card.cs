using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Sprite animalSprite;

    [SerializeField]
    private SpriteRenderer cardRenderer;    

    [SerializeField]
    private Sprite backSprite;

    private bool isFlipped = false;

    private bool isFlipping = false;
    private bool isMatched = false;
    public int cardID;
    public void SetCardID(int id)
    { 
        cardID = id;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAnimalSprite(Sprite sprite)
    {
        animalSprite = sprite;
    }
    public void FlipCard()
    {
        isFlipping = true;
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = new Vector3(0f, originalScale.y, originalScale.z);

        transform.DOScale(targetScale, 0.2f).OnComplete(() => //오브젝트의 크기를 변화시킨후 아래의 코드를 실행
        {
            isFlipped = !isFlipped;
            if (isFlipped)
            {
                cardRenderer.sprite = animalSprite;
            }
            else
            {
                cardRenderer.sprite = backSprite;
            }
            transform.DOScale(originalScale, 0.2f).OnComplete(() =>
            {
                isFlipping = false; // 플립이 끝나면 isFlipping을 false로 설정
            });
        });

    }

    public void setMatched()
    {
        isMatched = true;
    }
    void OnMouseDown()
    {
        if (!isFlipping && !isMatched && !isFlipped) // 카드가 뒤집히는 중이 아니고 매치되지 않은 경우에만 클릭 처리
        {
            GameManager.instance.CardClicked(this);
        }
    }
}
