using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SceneManager sceneManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(nextStage());
    }

    IEnumerator nextStage()
    {
        yield return new WaitForSecondsRealtime(1f);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}
