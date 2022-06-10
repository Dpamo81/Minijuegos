using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashUIController : MonoBehaviour
{
    private GameObject logo;

    private void Awake()
    {
        logo = (GameObject)GameObject.FindGameObjectWithTag("Logo");

        if(logo!=null)
        {
            Invoke("IrMenuPrincipal",2.0f);
        }
    }

    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void IrCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void IrMenuJuegos()
    {
        SceneManager.LoadScene("MenuJuegos");
    }
    public void IrMiniJuego1()
    {
        SceneManager.LoadScene("CojerCubito");
    }
     public void IrMiniJuego2()
    {
        SceneManager.LoadScene("MiniJuego2");
    }
     public void IrMiniJuego3()
    {
        SceneManager.LoadScene("SalvarTierra");
    }
    public void SalirApp()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
