using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class playOneShot : MonoBehaviour
{
    public AudioClip impact;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = impact;
    }

    void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(impact, 0.7F);
    }
}