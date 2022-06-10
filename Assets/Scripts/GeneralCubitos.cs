using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralCubitos : MonoBehaviour
{
    private static int segundos = 5;
    //Esto lo dejo en 5 para que compruebe si funciona o no, este numero va ha 60.
    private static int numCubitosAtrapados = 0;


  public static int GetSegundos()
  {
      return segundos;
  }
  public static void SetSegundos(int s)
  {
      segundos = s;
  }

  public static int GetNumCubitosAtrapados()
  {
      return numCubitosAtrapados;
  }
  public static void SetNumCubitosAtrapados(int p)
  {
      numCubitosAtrapados = p;
  }
}
