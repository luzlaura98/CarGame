using UnityEngine;

public class MotorCarretera : MonoBehaviour{

    public static float VELOCIDAD_RAPIDO = 22f;
    public static float VELOCIDAD_NORMAL = 15f;
    public static float VELOCIDAD_LENTO = 10f;

    public GameObject contenedorCallesGO;
    public GameObject[] contenedorCallesArray;

    public float velocidad;
    public bool inicioJuego;
    public bool juegoTerminado;

    int contadorCalles = 0;
    int numeroSelectorCalles;

    GameObject calleAnterior;
    GameObject calleNueva;

    public float tamanioCalle;

    public Vector3 medidaLimitePantalla;
    public bool salioDePantalla;
    public Camera camara;

    public GameObject autoGO;
    public AudioFX audioFx;
    public GameObject bgFinalGO;

    public void FinalizarJuego() {
        autoGO.GetComponent<AudioSource>().Stop();
        audioFx.SonidoFXMusica();
        bgFinalGO.SetActive(true);
    }

    void Start() {
        iniciarJuego();
    }

    void iniciarJuego(){
        contenedorCallesGO = GameObject.Find("ContenedorCalles");//nombre
        camara = GameObject.Find("MainCamera").GetComponent<Camera>();

        autoGO = GameObject.Find("Auto");
        audioFx = GameObject.FindObjectOfType<AudioFX>().gameObject.GetComponent<AudioFX>();
        bgFinalGO = GameObject.Find("PanelGameOver");
        bgFinalGO.SetActive(false);

        initVelocidadCarretera();
        medirPantalla();
        buscarCalles();
    }

    void initVelocidadCarretera() {
        velocidad = 10f;
    }

    void buscarCalles() { //busco por tag y almaceno en el array
        contenedorCallesArray = GameObject.FindGameObjectsWithTag("CalleTag");
        for(int i =0; i < contenedorCallesArray.Length; i++) {
            contenedorCallesArray[i].gameObject.transform.parent = contenedorCallesGO.transform; //lo convierte en hijo
            contenedorCallesArray[i].gameObject.SetActive(false);
            contenedorCallesArray[i].gameObject.name = "CalleOFF_" + i;
        }
        crearCalles();
    }

    void crearCalles() {
        contadorCalles++;
        numeroSelectorCalles = Random.Range(0, contenedorCallesArray.Length); // [0, array.length) ta bien
        GameObject calleAux = Instantiate(contenedorCallesArray[numeroSelectorCalles]); // crea una copia
        calleAux.SetActive(true);
        calleAux.name = "Calle" + contadorCalles;
        calleAux.transform.parent = gameObject.transform; //la carretera
        posicionarCalles();
    }

    /** Justo arriba de la pista que se está temrinando.*/
    void posicionarCalles() {
        calleAnterior = GameObject.Find("Calle" + (contadorCalles - 1)); //del actual, el anterior
        calleNueva = GameObject.Find("Calle" + contadorCalles);
        medirCalle();
        Debug.Log("posicionar calle, v=" + (calleNueva.transform.position).ToString());
        calleNueva.transform.position = new Vector3(
            calleAnterior.transform.position.x, 
            calleAnterior.transform.position.y + tamanioCalle,
            0); //eje Z no interesa
        salioDePantalla = false;
    }

    void medirCalle() {
        for (int i = 0; i < calleAnterior.transform.childCount; i++) {
            if(calleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null) {
                float tamPieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                tamanioCalle = tamanioCalle + tamPieza;
            }
            
        }
    }

    void medirPantalla() { //se adapta a la pantalla android, pc...
        medidaLimitePantalla = new Vector3(
            0,
            camara.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f, //solo me importa Y, convierto la medida en pixeles en vector
            //le agrego 0.5f media unidad más para que no sea apenas esté al final
            0);//necesito acceder a la camara
        Debug.Log("MedidaLimitePantalla:" + medidaLimitePantalla);
    }

    // Update is called once per frame
    void Update(){
        if(inicioJuego == true && juegoTerminado == false) {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
            if(calleAnterior.transform.position.y + tamanioCalle < medidaLimitePantalla.y && !salioDePantalla) {
                //salió de la calle
                salioDePantalla = true; //solo en el primer frame
                destruirCalles();
            }
        }
    }
    void destruirCalles() {
        Destroy(calleAnterior);
        tamanioCalle = 0f;
        calleAnterior = null;
        crearCalles();
    }

}
