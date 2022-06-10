using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMinijuego2 : MonoBehaviour
{

    protected int numToques=0;
    public GameObject puntuacion;
    public GameObject record;
    protected float velocidad = 5.0f;
    protected float h = 0.0f;

    protected bool bloquearDerecha = false;
    protected bool bloquearIzquierda = false;

    // Start is called before the first frame update
    void Start()
    {
        GeneralMinijuego2.puntos = 0;

        if (PlayerPrefs.HasKey("RECORDTOQUES"))
        {
            record.GetComponent<Text>().text = PlayerPrefs.GetInt("RECORDTOQUES").ToString();
        }
        else
        {
            record.GetComponent<Text>().text = "";
        }
    }

    // Update is called once per frame
     void Update()
    {
      h=Input.GetAxis("Horizontal")  * Time.deltaTime * velocidad;

      if (h>0)
      {
          if(!bloquearDerecha)
          {
            this.gameObject.transform.Translate(h,0.0f,0.0f);
          }
        
      }
      else if (h<0)
      {
          if(!bloquearIzquierda)
          {
              this.gameObject.transform.Translate(h,0.0f,0.0f);
          }
        
      }

      
        
    }

    //para detectar los toques y contarlos.

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Balon")
        {
            GeneralMinijuego2.puntos = GeneralMinijuego2.puntos + 1 ;
            //numToques = numToques + 1;
            //puntuacion.GetComponent<Text>().text = "Toques: " + numToques.ToString();
            puntuacion.GetComponent<Text>().text = GeneralMinijuego2.puntos.ToString();
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-2.0f,2.0f), 0.2f), ForceMode2D.Impulse);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag=="LimiteDerecho")
        {
            bloquearDerecha = true;
        }
        if(other.gameObject.tag=="LimiteIzquierdo")
        {
            bloquearIzquierda = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if(other.gameObject.tag=="LimiteDerecho")
        {
            bloquearDerecha = false;
        }
        if(other.gameObject.tag=="LimiteIzquierdo")
        {
            bloquearIzquierda = false;
        }

    }

        
    }
