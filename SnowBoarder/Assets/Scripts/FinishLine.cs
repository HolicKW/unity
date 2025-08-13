using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float delayBeforeReload = 0.5f;
    [SerializeField] private ParticleSystem finishEffect;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", delayBeforeReload);

        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
