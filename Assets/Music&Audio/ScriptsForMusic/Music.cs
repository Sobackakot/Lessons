using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource WOTMF;
    void Update()
    {
        if (!WOTMF.isPlaying)
            WOTMF.Play();
    }
}
