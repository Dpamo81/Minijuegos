using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubitoscreator : MonoBehaviour
{
    //public GameObject cubito;
    //private GameObject clonCubito;

   // public GameObject cucaracha;
    //private GameObject clonCucaracha;
    
    public GameObject[] cubiracha;
    private GameObject clonCubiracha;
    public GameObject camara;

    private float ancho;
    private float alto;
    private float margenVertical;
    private float margenHorizontal;
    private Vector3 posCubitoWorld;

    private int cubitoRandom;
    protected float max=0.5f;

    // Start is called before the first frame update
    void Start()
    {
        margenVertical = 200.0f;
        margenHorizontal = 3.0f;

        InvokeRepeating ("CrearCubitos", 3.0f, 0.6f);

        

    }

    public void CrearCubitos()
    {
        ancho = Random.Range(margenHorizontal,Screen.width-margenHorizontal);
        alto = Screen.height-margenVertical;

        posCubitoWorld= camara.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(ancho, alto, camara.transform.position.z));
        posCubitoWorld.z = 0.0f;
        //Destroy(clonCubito, 5.0f);
        //Destroy(clonCucaracha, 5.0f);
        Destroy(clonCubiracha, 5.0f);
        //cubitoRandom = Random.Range(0,2);
/*
        if (cubitoRandom==0)
        {
            clonCubito = (GameObject) Instantiate(cubito, posCubitoWorld, Quaternion.identity);
            clonCubito.GetComponent<Rigidbody2D>().gravityScale= Random.Range(0.05f,max);
            

        }
        else 
        {
            clonCucaracha = (GameObject) Instantiate(cucaracha, posCubitoWorld, Quaternion.identity);
            clonCucaracha.GetComponent<Rigidbody2D>().gravityScale= Random.Range(0.05f,max);
        }
*/

        clonCubiracha = Instantiate(cubiracha [Random.Range(0, cubiracha.Length)], posCubitoWorld, Quaternion.identity);

        if (GeneralCubitos.GetSegundos()<=0)
        {
            CancelInvoke("CrearCubitos");
            
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
