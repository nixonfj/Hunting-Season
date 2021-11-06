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

    public float tiempoTrascurrido = 0f;
    public float tiempoLimite = 30;
    private float tiempoDeJuego;

    // Start is called before the first frame update
    void Start()
    { 
        rigidbody = this.GetComponent<Rigidbody>();
        posInicial = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
    }//fin del star

    // Update is called once per frame
    void Update()
    {
        //Contador de tiempo
        tiempoTrascurrido += Time.deltaTime;
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
        GameManager.instancia.CambiarEscena("Perdida");

    }///fin del metodo

    public void ganarJuego()
    {
        GameManager.instancia.CambiarEscena("Gane");
    }///fin del metodo

} //fin de la clase
