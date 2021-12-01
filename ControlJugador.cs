using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlJugador : MonoBehaviour
{
    private Rigidbody rb;
    public int rapidez;
    public Text textoCantidadRecolectados;
    public Text textoGanaste;
    private int cont;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cont = 0;
        textoGanaste.text = "";
        setearTextos();
    }

    private void setearTextos()
    {
        textoCantidadRecolectados.text = "Cantidad recolectados: " + cont.ToString();
        if (cont >= 5)
        {
            textoGanaste.text = "Ganaste!";
        }
    }

    private void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");
        Vector3 vectorMovimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);

        rb.AddForce(vectorMovimiento * rapidez);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coleccionable") == true)
        {
            cont = cont + 1;
            setearTextos();
            other.gameObject.SetActive(false);
        }
    }
}
