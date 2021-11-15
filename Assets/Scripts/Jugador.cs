using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    private Vector3 posInicial;
    private Rigidbody rigidBody;
    private float velX, velY;
    public float sensibilidadDelRaton;

    private int puntaje;
    public float velocidad = 1.5f;

    public float tiempoTranscurrido = 0f;
    public float tiempoLimite = 30;
    private float tiempoDeJuego;

    public Text txt_TiempoTranscurrido;
    public Text txt_PuntajeActual;
    public Text txt_LimiteActual;

    // Start is called before the first frame update
    void Start()
    { 
        rigidBody = this.GetComponent<Rigidbody>();
        posInicial = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }//fin del star

    // Update is called once per frame
    void Update()
    {
        // Actualizar interfaces gráficas
        txt_TiempoTranscurrido.text = this.tiempoTranscurrido.ToString();
        txt_PuntajeActual.text = this.puntaje.ToString();
        txt_LimiteActual.text = (tiempoLimite - tiempoDeJuego).ToString();

        //Contador de tiempo
        tiempoTranscurrido += Time.deltaTime;
        tiempoDeJuego += Time.deltaTime;

        //condicion  de perdida
        if (tiempoDeJuego > tiempoLimite)
        {
            perderJuego();
        }

        //condiion de gane
        if (puntaje >= 10)
        {
            ganarJuego();
        }

        //velX = Input.GetAxis("Horizontal");
        //velY = Input.GetAxis("Vertical");

        //Adelante
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, velocidad * Time.deltaTime);
        }

        //Izquierda
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-velocidad * Time.deltaTime, 0, 0);
        }

        //Atrás
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -velocidad * Time.deltaTime);
        }

        //Derecha
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(velocidad * Time.deltaTime, 0, 0);
        }

        //movimiento
        if (velX != 0 || velY != 0)
        {
            rigidBody.velocity = (new Vector3(velX, 0, velY)) * velocidad;
        }

        //Mouse
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("ENTER HA SIDO PRESIONADO");

            transform.position = new Vector3(posInicial.x, posInicial.y, posInicial.z);

            rigidBody.velocity = Vector3.zero;
        }

        transform.Rotate(0, Input.GetAxis("Mouse X") * sensibilidadDelRaton * Time.deltaTime, 0);
    }//fin del update

    public void IncrementarPuntaje(int valor)
    {
        puntaje += valor;
        Debug.Log("Puntuacion:" + puntaje.ToString());

    }//fin del metodo

    public void ModificarTiempo(float valor)
    {
        tiempoDeJuego -= valor;
        Debug.Log("Tiempo restablecido");

    }//fin del modificar tiempo

    public void perderJuego()
    {
        GameManager.instancia.CambiarEscena("Perdida");

    }///fin del metodo

    public void ganarJuego()
    {
        GameManager.instancia.CambiarEscena("Gane");
    }///fin del metodo

} //fin de la clase
