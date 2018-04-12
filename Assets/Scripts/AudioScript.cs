using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

    public AudioSource audioSource;
	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
	}

    public void PlayClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
