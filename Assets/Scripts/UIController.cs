using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
  public Text numCubitos;
  public Text crono;
  public Text record;

  public GameObject panelFinal;

  public GameObject panelInicio;

  private int segundosInicio;


public void SetNumCubitos()
{
    numCubitos.text = "Cubitos: " + GeneralCubitos.GetNumCubitosAtrapados().ToString(); 
}

public void SetCrono()
{
    crono.text = GeneralCubitos.GetSegundos().ToString();
}
public void BorrarRecordUI()
{
    record.text ="";
}
public void SetRecordUI(int r)
{
    record.text ="Record: " + r.ToString();
}

void Start()
{
    segundosInicio=3;
    Time.timeScale = 1.0f;
    GeneralCubitos.SetSegundos(8);
    

    if (panelInicio!=null)
    {
            panelInicio.transform.GetChild(2).GetComponent<Text>().text = segundosInicio.ToString();

    }
    if (panelFinal!=null)
    {
        panelFinal.SetActive(false);
    }
    if (panelInicio!=null)
    {

        InvokeRepeating("CronoInicio", 0.0f, 1.0f);
        InvokeRepeating("Crono", 3.0f, 1.0f);
        
    }
    
}
private void CronoInicio()
{
    segundosInicio--;
    panelInicio.SetActive(true);
    
    if (panelInicio!=null)
    {
        panelInicio.transform.GetChild(2).GetComponent<Text>().text = segundosInicio.ToString();
    }

    if (segundosInicio<=0)
    {
        
        CancelInvoke("CronoInicio");
        panelInicio.SetActive(false); 
    }
}
private void Crono()
{
    
    GeneralCubitos.SetSegundos(GeneralCubitos.GetSegundos() - 1);
    this.GetComponent<UIController>().SetCrono();

    

    if (GeneralCubitos.GetSegundos()<=0)
    {
        Time.timeScale = 0.0f;
        panelFinal.SetActive(true);
        panelFinal.transform.GetChild(2).GetComponent<Text>().enabled = false;

        if (this.GetComponent<PersistenciaCubitos>().ExisteRecord())
        {
            if(GeneralCubitos.GetNumCubitosAtrapados() > this.GetComponent<PersistenciaCubitos>().GetRecord())
            {
                this.GetComponent<PersistenciaCubitos>().SetRecord(GeneralCubitos.GetNumCubitosAtrapados());
                panelFinal.transform.GetChild(2).GetComponent<Text>().enabled = true;
                
            }
        }
        else
        {
            this.GetComponent<PersistenciaCubitos>().SetRecord(GeneralCubitos.GetNumCubitosAtrapados());
           panelFinal.transform.GetChild(1).GetComponent<Text>().enabled = true;
           
        }

       panelFinal.transform.GetChild(1).GetComponent<Text>().text ="Cubitos: " + GeneralCubitos.GetNumCubitosAtrapados();
        
        CancelInvoke("Crono");


    }
   
   
}

}
// todo 17.05 IFP_013.-Videojuego2D_tactil__43_07