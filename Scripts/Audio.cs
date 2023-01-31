using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    private AudioSource audioSource;
    private GameObject[] music;

    [SerializeField] AudioMixer mixer;

    private void Awake()
    {
        if (music != null)
            Destroy(this.gameObject);

        music = GameObject.FindGameObjectsWithTag("Music");
        audioSource= GetComponent<AudioSource>();

    }


    public void AudioMix(float val)
    {
        mixer.SetFloat("BackGroundMusic", Mathf.Log10(val) * 20);

    }

    public void MixToggle()
    {
        audioSource.Play();
    }

}
