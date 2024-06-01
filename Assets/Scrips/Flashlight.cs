using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject flashlight; //Flashlight
    [SerializeField] AudioClip flashSound; //Flash acma kapama sesi
    private AudioSource audioSource;
    private bool flashOn = false;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = flashSound;
        FlashLightOff();
    }

    private void Update()
    {
        if (!flashOn && Input.GetKeyDown(KeyCode.F))
        {
            FlashLightOn();
        }
        else if (flashOn && Input.GetKeyDown(KeyCode.F))
        {
            FlashLightOff();
        }
    }

    #region Flashlight açma
        public void FlashLightOn()
        {
            flashlight.SetActive(true);
            audioSource.Play(); 
            flashOn = true;
        }
    #endregion

    #region Flashlight kapama
        public void FlashLightOff()
        {
            flashlight.SetActive(false);
            audioSource.Play();
            flashOn = false;
        }
    #endregion
}
