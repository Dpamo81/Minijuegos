using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreadorAsteroides : MonoBehaviour
{
    public GameObject[] zonasSpawn;

    public GameObject[] enemigos;
    protected GameObject enemigosClon;

    protected float max=0.05f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Crear", 0.0f, 2.0f);
    }

    public void Crear()
    {
        enemigosClon = Instantiate(enemigos [Random.Range(0,enemigos.Length)], zonasSpawn[Random.Range(0,zonasSpawn.Length)].gameObject.transform.position, Quaternion.identity);
        enemigosClon.GetComponent<Rigidbody2D>().gravityScale= Random.Range(0.05f,max);
        //max= GeneralSalvarTierra.puntos * 0.1f + max;
        Destroy(enemigosClon, 10.0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("SalvarTierra");
    }
}
