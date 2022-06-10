using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenciaCubitos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (ExisteRecord())
        {
            this.GetComponent<UIController>().SetRecordUI(GetRecord());
        }
        else{
            this.GetComponent<UIController>().BorrarRecordUI();
        }

    }

    public int GetRecord()
    {
        return PlayerPrefs.GetInt("RECORD");
    }
    public void SetRecord(int r)
    {
        PlayerPrefs.SetInt("RECORD",r);
    }
    public bool ExisteRecord()
    {
        return PlayerPrefs.HasKey("RECORD");
    }
     public void BorrarRecord()
   {
       PlayerPrefs.DeleteKey("RECORD");
   }
   public void BorrarTodo()
   {
       PlayerPrefs.DeleteAll();
   }


    // Update is called once per frame
    void Update()
    {
        
    }
}
