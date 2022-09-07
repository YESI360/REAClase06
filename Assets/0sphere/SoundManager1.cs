using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager1 : MonoBehaviour
{
    public AudioSource source;
    //public AudioClip clips;
    //public float volume = 0.5f;
    public AudioClip nota01;
    public AudioClip nota02;

    void Start()
    {
    }  

    void Update()
    {
        if (Input.GetKeyDown("0"))
        {
            luzNota00();
        }
        if (Input.GetKeyDown("9"))
        {
            luzNota01();
        }
    }

    public void luzNota00()
    {
        ReproducirSonido(nota01);
    }
    public void luzNota01()
    {
        ReproducirSonido(nota02);
    }

    void ReproducirSonido(AudioClip notas)
    {
        source.clip = notas;
        //source.loop = false;
        source.Play();
    }


}
