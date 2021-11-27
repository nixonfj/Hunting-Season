using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{

    public GameObject hunter;
    public GameObject player;

    public float tiempo;
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        GenerarBala();
        gameObject.SetActive(true);

        pos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        transform.LookAt(player.transform.position);

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

            transform.Translate(Vector3.forward * 20 * Time.deltaTime);
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
