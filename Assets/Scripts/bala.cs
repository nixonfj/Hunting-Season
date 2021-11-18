using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{

    public GameObject hunter;
    public GameObject player;

    public float tiempo;

    // Start is called before the first frame update
    void Start()
    {
        GenerarBala();
        gameObject.SetActive(true);

    }//fin del start

    // Update is called once per frame
    void Update()
    {
        detonar();

    }//fin del update

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Jugador>();
            player.ModificarTiempo(tiempo);
            Destroy(gameObject);
        }
    }//fin del onTriggerEnter

    public void detonar()
    {
        if (Vector3.Distance(hunter.transform.position, player.transform.position) < 10)
        {

                var pos = player.transform.position - transform.position;
                var rotation = Quaternion.LookRotation(pos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                transform.Translate(Vector3.forward * 15 * Time.deltaTime);

        }
        else
        {
            Destroy(gameObject);
        }

    }//fin del metodo

    protected void GenerarBala()
    {
        transform.position = hunter.transform.position;

    }//fin del metodo reposicionar

}//fin de la clase
