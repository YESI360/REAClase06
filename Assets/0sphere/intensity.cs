using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intensity : MonoBehaviour
{
    public Light luz;
    public float maxLightIntensity;
    public float minLightIntensity;
    [Range(0, 10)] public float speed;
    public SoundManager1 sonidos;

    void Start()
    {
        luz.intensity = 0;
    }


    void Update()
    {
        if (Input.GetKeyDown("u"))
        {
            luzUp();
        }
        if (Input.GetKeyDown("d"))
        {
            luzDown();
        }

    }
    public void luzUp()
    {
        luz.intensity = Mathf.Lerp(luz.intensity, maxLightIntensity, speed * Time.deltaTime);
        sonidos.luzNota00();
    }

    public void luzDown()
    {
        luz.intensity = Mathf.Lerp(luz.intensity, minLightIntensity, speed * Time.deltaTime);
        sonidos.luzNota01();
    }
}
//getkeydown will happen once when you hit the key
//getkeyup happens once when you release key
