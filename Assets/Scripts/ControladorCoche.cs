using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCoche : MonoBehaviour{

    float inputHorizontal = 0f; //[-1,1]

    public GameObject autoGO;

    public float anguloDeGiro;
    public float velocidad; //de desplazarse de izq a der o visceversa


    void Start(){
        autoGO = GameObject.FindObjectOfType<Auto>().gameObject;
    }

    void Update() {

        //PARA TÁCTIL
        if (Input.touchCount > 0 /*&& Input.GetTouch(0).phase == TouchPhase.Began*/) {
            inputHorizontal += (Input.GetTouch(0).position.x < (Screen.width / 2)) ? -0.04f : 0.04f;
            if (inputHorizontal < -1f) inputHorizontal = -1f; else if (inputHorizontal > 1f) inputHorizontal = 1f;
        } else
            inputHorizontal = 0f;

        //PARA ENTRADA TECLADO
        //inputHorizontal = Input.GetAxis("Horizontal"); // me trae si la entrada fue a la izquierda o a la derecha POS O NEG

        transform.Translate(Vector2.right * inputHorizontal * velocidad * Time.deltaTime);
        //no me importa el tercer eje Z

        float giroZ = inputHorizontal * -anguloDeGiro;//else = 0
        autoGO.transform.rotation = Quaternion.Euler(0, 0, giroZ);
    }
}
