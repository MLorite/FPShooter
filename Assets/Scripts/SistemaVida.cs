using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaVida : MonoBehaviour
{
    public Image barra;
    public Image finPartida;
    public int maxVida = 5;
    public int vidaTotal = 5;

    public GameObject balaOriginal;
    public GameObject cargadorBalas;
    public float potencia;
    public float inclinacion;

    public int municionTotal = 100;
    public Text municion;
    int municionCargador;

    public GameObject enemigo1;
    public GameObject enemigo2;
    public Text victoria;

    public Image dolor;
    public Image mirilla;

    

    private void Start()
    {
        municionCargador = municionTotal;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            tirar();
            municion.text = "" + municionCargador;
            QuitarDolor();
        }

        if ((enemigo1 == null) && (enemigo2 == null))
        {
            victoria.gameObject.SetActive(true);
            mirilla.gameObject.SetActive(false);
        }

        //InvokeRepeating("QuitarDolor", 1, 1);
        //dolor.gameObject.SetActive(false);

    }

    void OnCollisionEnter(Collision other)
    {
        if (vidaTotal > 1) { 

            if((other.gameObject.tag == "Enemy") || (other.gameObject.tag == "BalaEnemy"))
            {
                vidaTotal = vidaTotal - 1;
                PonerDolor();
            }
            if ((other.gameObject.tag == "Botiquin") && (vidaTotal < maxVida))
            {
                vidaTotal = vidaTotal + 1;
                Destroy(other.gameObject);
            }
            if ((other.gameObject.tag == "Avituallamiento") && (municionCargador < municionTotal ))
            {
                municionCargador = municionCargador + 25;
                if (municionCargador > municionTotal)
                {
                    municionCargador = municionTotal;
                }
                municion.text = "" + municionCargador;
                Destroy(other.gameObject);
            }
            ActualizarBarra();

        } else
        {
            finPartida.gameObject.SetActive(true);
            mirilla.gameObject.SetActive(false);
        }
        

    }

    void ActualizarBarra()
    {
        float vidaParaImagen = (float)vidaTotal / maxVida;
       
        barra.fillAmount = vidaParaImagen;
    }

    void tirar()
    {
       
        if (municionCargador > 0)
        {
            //Creo el clon del balon y lo guardo en la referencia nueva
            GameObject balaNueva;
            balaNueva = (GameObject)Instantiate(balaOriginal, cargadorBalas.transform.position, cargadorBalas.transform.rotation);
            municionCargador = municionCargador - 1;

            //Obtengo el componente Rigidbody
            Rigidbody miRigid = balaNueva.GetComponent<Rigidbody>();

            //Le doy una velocidad constante al balon
            miRigid.velocity = (this.transform.forward * potencia) + (this.transform.up * inclinacion);
            //miRigid.velocity = transform.TransformDirection(new Vector3(0, 0, potencia));
        }
        else
        {
            Debug.Log("Sin Municion");
        }
    }

    void PonerDolor()
    {
        dolor.gameObject.SetActive(true);
    }

    void QuitarDolor()
    {
        dolor.gameObject.SetActive(false);
    }
}
