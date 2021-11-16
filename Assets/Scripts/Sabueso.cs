using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sabueso : MonoBehaviour
{
    public GameObject Jugador;

    public Jugador jugador;
    public GameObject sabueso;

    public float minZ, maxZ;
    public float minX, maxX;

    public float tiempo;

    public int puntajeJugador = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }//fin del start

    // Update is called once per frame
    void Update()
    {
        /*puntajeJugador = jugador.puntaje;

        if (puntajeJugador >= 10 && puntajeJugador <= 11)
        {
            generarSabueso();

        } */

        seguirJugador();
        
    }//fin del update

    public void generarSabueso()
    {
        GameObject.Instantiate(sabueso);
        var Sabueso = sabueso.GetComponent<Sabueso>();
        Sabueso.ReposicionarSabueso();

    }//fin del metodo generar sabueso

    public void seguirJugador()
    {
        if (Vector3.Distance(transform.position, Jugador.transform.position) < 20)
        {
            var pos = Jugador.transform.position - transform.position;
            pos.y = 0;
            var rotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);

        }
    }//fin del metodo seguir jugador

    protected void ReposicionarSabueso()
    {
        transform.position = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));

    }//fin del metodo reposicionar

}//fin de la clase
