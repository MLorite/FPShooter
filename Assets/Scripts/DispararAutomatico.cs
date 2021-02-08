using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararAutomatico : MonoBehaviour
{
    public GameObject balonOriginal;
    public GameObject cargadorBalas;
    public float potencia;
    public float inclinacion;
    public int tiempoDisparo;
    public int inicioDisparo;
    public GameObject player;
    Vector3 distancia;

    // Start is called before the first frame update
    void Start()
    {
        // Disparo Automatico
        InvokeRepeating("tirar", inicioDisparo, tiempoDisparo);
    }

    // Update is called once per frame
    void Update()
    {
        // Vector entre el player y el enemy
        distancia = player.transform.position - this.transform.position;
        
    }
    void tirar()
    {
        //Creo el clon del balon y lo guardo en la referencia nueva
        GameObject balonNuevo;
        balonNuevo = (GameObject)Instantiate(balonOriginal, cargadorBalas.transform.position, cargadorBalas.transform.rotation);

        //Obtengo el componente Rigidbody
        Rigidbody miRigid = balonNuevo.GetComponent<Rigidbody>();

        //Le doy una velocidad constante al balon
        miRigid.velocity = (distancia * potencia);
        //miRigid.velocity = transform.TransformDirection(new Vector3(0, 0, potencia));
    }
}
