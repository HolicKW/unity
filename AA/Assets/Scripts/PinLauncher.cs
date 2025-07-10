using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject pinObject;
    private Pin currPin;
    void Start()
    {
        PreparePin();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currPin != null && GameManager.instance.isGameOver == false) // 0은 왼쪽 마우스 버튼
        {
            currPin.Launch();
            currPin = null; // Pin이 발사된 후 currPin을 null로 설정하여 다음 Pin을 준비할 수 있도록 합니다. 
            Invoke("PreparePin", 0.1f); // Pin이 발사된 후 0.1초 후에 새로운 Pin을 준비합니다.        
        }
    }

    private void PreparePin()
    {
        if (GameManager.instance.isGameOver == false) // 게임이 오버되지 않은 경우에만 Pin을 준비합니다.
        {
            GameObject pin = Instantiate(pinObject, transform.position, Quaternion.identity);
            currPin = pin.GetComponent<Pin>();
        }
    }
}
