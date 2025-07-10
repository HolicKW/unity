using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;

    [SerializeField]
    private Sprite[] cardSprites;

    private List<int> cardIDList = new List<int>();

    private List<Card> cardList = new List<Card>();
    // Start is called before the first frame update
    void Start()
    {
        GenerateCardID();
        ShuffleCardID();
        initBoard();
    }


    void GenerateCardID()
    {
        for (int i = 0; i < cardSprites.Length; i++)
        {
            cardIDList.Add(i);
            cardIDList.Add(i);
        }
    }

    void ShuffleCardID()
    {
        int cardCount = cardIDList.Count;
        for (int i = 0; i < cardCount; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, cardCount);
            int temp = cardIDList[i];
            cardIDList[i] = cardIDList[randomIndex];
            cardIDList[randomIndex] = temp;
        }
    }
    void initBoard()
    {
        float spaceX = 1.3f;
        float spaceY = 1.8f;

        int rowCount = 5;
        int colCount = 4;
        int cardIndex = 0;

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                float posX = (col - (int)(colCount / 2)) * spaceX + (spaceX / 2);
                float posY = (row - (int)(rowCount / 2)) * spaceY;
                Vector3 pos = new Vector3(posX, posY, 0f);
                GameObject cardObject = Instantiate(cardPrefab, pos, quaternion.identity);
                Card card = cardObject.GetComponent<Card>();
                int cardID = cardIDList[cardIndex++];
                card.SetCardID(cardID);
                card.SetAnimalSprite(cardSprites[cardID]);
                cardList.Add(card);
            }
        }
    }
    
    public List<Card> GetCardList()
    {
        return cardList;
    }
}
