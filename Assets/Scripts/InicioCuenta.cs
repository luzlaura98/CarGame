using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioCuenta : MonoBehaviour{

    public Sprite[] numeros;

    public GameObject contadorNumerosGO;
    public SpriteRenderer contadorNumerosComp;

    //public GameObject motorCarretaGO;
    public MotorCarretera motorCarretera;
    
    public GameObject autoGO;
    public GameObject controladorCocheGO;

    void inicioComponentes() {
        contadorNumerosGO = GameObject.Find("ContadorNumeros");
        contadorNumerosComp = contadorNumerosGO.GetComponent<SpriteRenderer>();
        motorCarretera = GameObject.Find("MotorCarreteras").GetComponent<MotorCarretera>();
        autoGO = GameObject.Find("Auto");
        controladorCocheGO = GameObject.Find("ControladorCoche");
        IniciarCuentaAtras();
    }

    IEnumerator contar() {

        this.gameObject.GetComponent<AudioSource>().Play();
        controladorCocheGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosComp.sprite = numeros[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosComp.sprite = numeros[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosComp.sprite = numeros[3];
        motorCarretera.inicioJuego = true;
        contadorNumerosGO.GetComponent<AudioSource>().Play();
        autoGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosGO.SetActive(false);
    }

    void IniciarCuentaAtras() {
        StartCoroutine(contar());
    }

    void Start(){
        inicioComponentes();
    }


    void Update(){
        
    }
}
