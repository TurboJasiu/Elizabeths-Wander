using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    public AudioSource fx;
    public AudioClip hoverFX;
    public AudioClip clickFX;
    public void HoverSound()
    {
        fx.PlayOneShot(hoverFX);
    }
    public void ClickSound()
    {
        fx.PlayOneShot(clickFX);
    }
}

