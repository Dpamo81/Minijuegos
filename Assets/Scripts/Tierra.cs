using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tierra : MonoBehaviour
{

    public GameObject canvas;
    protected float velocidadGiro;
    public GameObject explosion;
    protected GameObject explosionClon;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        velocidadGiro = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(0.0f,0.0f,velocidadGiro * Time.deltaTime);
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

            canvas.SetActive(true);

            Time.timeScale = 0.0f;

            explosionClon = Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            
        }
    }
}
