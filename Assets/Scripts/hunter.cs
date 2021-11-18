using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hunter : MonoBehaviour
{
    public float tiempo;

    public GameObject jugador;
    public GameObject cazador;
    public GameObject proyectil;

    public float minZ, maxZ;
    public float minX, maxX;

    bool disparo = false;

    // Start is called before the first frame update
    void Start()
    {
        ReposicionarCazador();
        gameObject.SetActive(true);

    }//fin de start

    // Update is called once per frame
    void Update()
    {
        seguirJugador();
        if (disparo == false)
        {
            disparar();
        }
        if (Vector3.Distance(transform.position, jugador.transform.position) > 10)
        {
            Debug.Log("carga");
            disparo = false;
        }

    }//fin del update

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Jugador>();
            player.ModificarTiempo(tiempo);
        }
    }//fin del onTriggerEnter

    public void seguirJugador()
    {
        if (Vector3.Distance(transform.position, jugador.transform.position) < 20)
        {
            var pos = jugador.transform.position - transform.position;
            pos.y = 0;
            var rotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
            transform.Translate(Vector3.forward * 3 * Time.deltaTime);

        }
    }//fin del metodo seguir jugador

    public void disparar()
    {
        
        if (Vector3.Distance(transform.position, jugador.transform.position) <= 10)
        {
            
            while(disparo == false)
            {
                disparo = true;
                Debug.Log("dispara");
                GameObject b = (GameObject)Instantiate(proyectil);
                bala d = b.GetComponent<bala>();
                d.hunter = gameObject;
                d.player = jugador;

            }

        } 

    }//fin del metodo disparar

    public void ReposicionarCazador()
    {
        transform.position = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));

    }//fin del metodo reposicionar

}//fin de la clase
