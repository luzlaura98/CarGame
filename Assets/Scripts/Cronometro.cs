using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added

public class Cronometro : MonoBehaviour{

    public GameObject motorCarreterasGO;
    public MotorCarretera motorCarreteraScript;

    public float tiempo;
    public float distancia;
    public Text txtTiempo;  //se inicializan en Unity, no bind
    public Text txtDistancia;
    public Text txtDistanciaFinal;

    public static int TIEMPO_JUEGO = 100; //seg

    void calcularTiempoDistancia() {
        distancia += Time.deltaTime * motorCarreteraScript.velocidad;
        txtDistancia.text = ((int)distancia).ToString();

        tiempo -= Time.deltaTime;
        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo % 60;
        txtTiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2,'0'); //siempre tiene que tener 2 casilleros
    }

    void Start(){
        motorCarreterasGO = GameObject.Find("MotorCarreteras");
        motorCarreteraScript = motorCarreterasGO.GetComponent<MotorCarretera>();
        tiempo = TIEMPO_JUEGO;
    }


    void Update(){
        if(motorCarreteraScript.inicioJuego && !motorCarreteraScript.juegoTerminado)
            calcularTiempoDistancia();
        if (tiempo <= 0 && !motorCarreteraScript.juegoTerminado) {
            motorCarreteraScript.juegoTerminado = true;
            motorCarreteraScript.FinalizarJuego();
            txtDistanciaFinal.text = ((int)distancia).ToString() + "M";
	    txtTiempo.text = "0:00";
        }
    }
}
