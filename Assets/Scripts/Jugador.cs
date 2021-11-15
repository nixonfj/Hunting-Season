using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    private Vector3 posInicial;
    private Rigidbody rigidbody;
    private float velX, velY;

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
        rigidbody = this.GetComponent<Rigidbody>();
        posInicial = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
    }//fin del start

    // Update is called once per frame
    void Update()
    {
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

        velX = Input.GetAxis("Horizontal");
        velY = Input.GetAxis("Vertical");
        
        //movimiento
        if (velX != 0 || velY != 0)
        {
            rigidbody.velocity = (new Vector3(velX, 0, velY)) * velocidad;
        }
    }//fin del upDate

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
        Debug.Log("Juego Finalizado");
        //GameManager.instancia.SumarPuntaje(Convert.ToInt32(puntaje * tiempoTranscurrido * 100));
        GameManager.instancia.CambiarEscena("Perdida");
    }///fin del metodo

    public void ganarJuego()
    {
        GameManager.instancia.CambiarEscena("Gane");
    }///fin del metodo

} //fin de la clase
