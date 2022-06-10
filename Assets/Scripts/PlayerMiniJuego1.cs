using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMiniJuego1 : MonoBehaviour
{

    protected int numCubitos = 0; 
    public GameObject puntuacion;
    protected float velocidad = 5.0f;
    protected float h = 0.0f;
    protected bool bloquearDerecha= false;
    protected bool bloquearIzquierda = false;
    protected int segundos = 4;
    public GameObject crono;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;

        if (h > 0)
        {
            if (!bloquearDerecha)
            {
                this.gameObject.transform.Translate(h,0.0f,0.0f);
            }
            
        }
        else if (h < 0)
        {
            if (!bloquearIzquierda)
            {
                this.gameObject.transform.Translate(h,0.0f,0.0f);
            }
        }
        
        
    }

//Para detectar la colision del Vaso con el cubito

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag=="Cubito")
        {
           // General.SetNumCubitosAtrapados(General.GetNumCubitosAtrapados()+1);
            
            //this.GetComponent<UIController>().SetNumCubitos();

           
            numCubitos = numCubitos + 1;
           
            
        } 
        
        if (other.gameObject.tag=="Cucaracha")
        {
            numCubitos = numCubitos -3;
        }
        Destroy(other.gameObject);
        puntuacion.GetComponent<Text>().text = numCubitos.ToString();
        GeneralCubitos.SetNumCubitosAtrapados(numCubitos);
        
    }

//Para que no se salga de los limites

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LimiteDerecho")
        {
            bloquearDerecha= true;
        }
        if (other.gameObject.tag == "LimiteIzquierdo")
        {
            bloquearIzquierda= true;
        }
        
        
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "LimiteDerecho")
        {
            bloquearDerecha= false;
        }
        if (other.gameObject.tag == "LimiteIzquierdo")
        {
            bloquearIzquierda= false;
        }
        
    }

   

}
