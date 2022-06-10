using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balon : MonoBehaviour
{
    public GameObject perder;
    public GameObject jugarDeNuevo;
    public GameObject volver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="LimiteInferior")
        {
            if (PlayerPrefs.HasKey("RECORDTOQUES"))
            {
                if (PlayerPrefs.GetInt("RECORDTOQUES") < GeneralMinijuego2.puntos)
                {
                    PlayerPrefs.SetInt("RECORDTOQUES", GeneralMinijuego2.puntos);
                }
            }
            else
            {
                PlayerPrefs.SetInt("RECORDTOQUES", GeneralMinijuego2.puntos);
            }
            

            perder.gameObject.SetActive(true);
            jugarDeNuevo.gameObject.SetActive(true);
            volver.gameObject.SetActive(true);

        }
    }
}
