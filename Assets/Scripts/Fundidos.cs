using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fundidos : MonoBehaviour
{
    public Image fundido;
    public string[] escenas;

    //cambia escena
    public void Fundir(int numEscena) {
        fundido.CrossFadeAlpha(0, 0.5f, false);
        StartCoroutine(CambiarEscena(escenas[numEscena]));
    }

    IEnumerator CambiarEscena(string escena) {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(escena);
    }

    private void Start() {
        fundido.CrossFadeAlpha(0, 0.5f, false);
    }
}
