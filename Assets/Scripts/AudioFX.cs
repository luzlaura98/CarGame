using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{

    public AudioClip[] fxs;
    public AudioSource audioS;

    void Start(){
        audioS = this.GetComponent<AudioSource>();
    }

    //[0] choque
    public void SonidoFXChoque() {
        audioS.clip = fxs[0];
        audioS.Play();
    }

    //[1] music game
    public void SonidoFXMusica() {
        audioS.clip = fxs[1];
        audioS.Play();
    }

    void Update(){
        
    }
}
