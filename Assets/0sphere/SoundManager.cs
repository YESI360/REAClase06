using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    [SerializeField] AudioClip[] clipsArray;
     
    public AudioClip clip;
    public float volume = 0.5f;

    void Start()
    {
        source.PlayOneShot(RandomClip());
    }

    AudioClip RandomClip()
    {
        return clipsArray[Random.Range(0, clipsArray.Length)];
    }
    

    void Update()
    {
        if (Input.GetKey("0"))
        {
            RandomClip();
        }

        //if (Input.GetKey("2"))
        //{
        //    source.PlayOneShot(clip, volume);
        //}

        //if (Input.GetKey("3"))
        //{
        //    source.clip = clipsArray[1];
        //    source.PlayOneShot(source.clip, volume);
        //    source.Play();
        //}
    }
}
