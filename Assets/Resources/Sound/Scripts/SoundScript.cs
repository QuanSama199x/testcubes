using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioManager audioManager;
    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void SetClip(int number)
    {

        audioSource.clip = audioManager.listSounds[number].AudioSound;
        audioSource.Play();
        StartCoroutine(removelist());
    }

    IEnumerator removelist()
    {
        SoundController.Instance.Sound.ListObjects.Remove(this);
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        SoundController.Instance.Sound.ListObjects.Add(this);
    }
}
