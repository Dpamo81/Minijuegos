using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2DSalvarTierra : MonoBehaviour
{
    public GameObject canvas;
    public GameObject explosion;
    protected GameObject explosionClon;
    public GameObject laser;
    protected GameObject laserClon;
    public GameObject record;

    public GameObject puntuacion;

    public VariableJoystick vj;

    protected float fuerza;

    protected float h;
    protected float velocidadDesplazamiento;

    public void Disparar()
    {
            laserClon = Instantiate(laser, this.gameObject.transform.position, Quaternion.identity);
            Destroy(laserClon, 5.0f);
            laserClon.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, fuerza);
    }

    // Start is called before the first frame update
    void Start()
    {

        GeneralSalvarTierra.puntos = 0;

        if (PlayerPrefs.HasKey("RECORDASTEROIDES"))
        {
             record.GetComponent<Text>().text = PlayerPrefs.GetInt("RECORDASTEROIDES").ToString();
        }
        else{
            record.GetComponent<Text>().text = "";
        }
        Time.timeScale = 1.0f;
        velocidadDesplazamiento = 3.0f;
        fuerza = 10.0f;



       // InvokeRepeating("Disparar", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        puntuacion.gameObject.GetComponent<Text>().text = GeneralSalvarTierra.puntos.ToString();
        
        h = velocidadDesplazamiento * vj.Horizontal * Time.deltaTime;
        this.gameObject.transform.Translate(h,0.0f,0.0f);
        
        if(Input.GetMouseButtonDown(1))
        {
          // Disparar();
        }
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Asteroide")
        {
            if (PlayerPrefs.HasKey("RECORDASTEROIDES"))
            {
                if (PlayerPrefs.GetInt("RECORDASTEROIDES")< GeneralSalvarTierra.puntos)
                {
                    PlayerPrefs.SetInt("RECORDASTEROIDES", GeneralSalvarTierra.puntos);
                }
            }
            else
            {
                 PlayerPrefs.SetInt("RECORDASTEROIDES", GeneralSalvarTierra.puntos);
            }

           
            Time.timeScale = 0.0f;

            explosionClon = Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            canvas.SetActive(true);
        }
    }

    // todo 58:52
}
