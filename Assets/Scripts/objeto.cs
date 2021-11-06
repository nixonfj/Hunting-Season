using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objeto : MonoBehaviour
{
    public float minZ, maxZ;
    public float minX, maxX;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Reposicionar();
        }
    }//fin del onTriggerEnter

    protected void Reposicionar()
    {
        transform.position = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));

    }//fin del metodo reposicionar

}//fin de la clase
