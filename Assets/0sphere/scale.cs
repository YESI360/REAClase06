using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale : MonoBehaviour
{
    public int multi;

    private void Start()
    {
    }
    void Update()
    {
        if (Input.GetKey("z"))
        {
            transform.localScale += new Vector3(0.01f*multi, 0.01f*multi, 0.01f*multi);
        }
 
        if (Input.GetKey("x"))
        {
            transform.localScale -= new Vector3(0.01f / multi, 0.01f / multi, 0.01f / multi);
        }
    }
}
//getkey will continue to happen while you are holding the key