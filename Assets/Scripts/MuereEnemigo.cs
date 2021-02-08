using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuereEnemigo : MonoBehaviour
{
    public GameObject efectoOriginal;
       
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bala")
        {
            Destroy(this.gameObject);
            Instantiate(efectoOriginal, other.transform.position, this.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
