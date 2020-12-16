using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoObstaculo : MonoBehaviour
{
    Cronometro cronometro;
    AudioFX miAudioFX;

    private void OnTriggerEnter2D(Collider2D other) { //override
        if (other.GetComponent<Auto>() != null) {
            miAudioFX.SonidoFXChoque();
            cronometro.tiempo -= 20; //resto segundos
            Destroy(this.gameObject);
        }
            
    }

    // Start is called before the first frame update
    void Start()
    {
        cronometro = GameObject.FindObjectOfType<Cronometro>().gameObject.GetComponent<Cronometro>();
        miAudioFX = GameObject.FindObjectOfType<AudioFX>().gameObject.GetComponent<AudioFX>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
