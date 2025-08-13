using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float delayBeforeReload = 0.5f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool isCrashing = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !isCrashing)
        {
            isCrashing = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", delayBeforeReload); 
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
