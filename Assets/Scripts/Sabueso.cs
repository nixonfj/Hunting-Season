using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sabueso : MonoBehaviour
{
    public GameObject jugador;

    public float tiempo;

    public int puntajeJugador = 0;

    public float minZ, maxZ;
    public float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        ReposicionarSabueso();
        gameObject.SetActive(true);

    }//fin del start

    // Update is called once per frame
    void Update()
    {
        seguirJugador();

    }//fin del update

    public void seguirJugador()
    {
        if (Vector3.Distance(transform.position, jugador.transform.position) < 30)
        {
            var pos = jugador.transform.position - transform.position;
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
