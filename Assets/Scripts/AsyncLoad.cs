using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsyncLoad : MonoBehaviour {

    public Text TextoBoton;
    public Button Boton;

    public Transform CuboRota;
    public CanvasGroup mycanvasgroup;

    public CanvasGroup SkipNext;

    public AsyncOperation async;

    void Awake()
    {
        SkipNext.interactable = false;
        SkipNext.alpha = 0f;
    }

    // cuando pulso
    public void Cargar() {
        TextoBoton.text = "Cargando";
        Boton.interactable = false;
        mycanvasgroup.interactable = false;

        //el cubo y carga async
        StartCoroutine("CargaAsync");

    }

    IEnumerator CargaAsync()
    {
        async = SceneManager.LoadSceneAsync(1); //la 2ª escena
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            
            //si el progreso es mayor de 85%, preparo el canvas para cambiar escena
            if (async.progress > 0.85f)
            {
               SkipNext.interactable = true;
               SkipNext.alpha = 1f;
               TextoBoton.text = "CARGADO!";
               mycanvasgroup.interactable = true;

               CuboRota.Rotate(Vector3.up * -2f);
               

            }
            else
            {
                CuboRota.Rotate(Vector3.up);
            }

            //Debug.Log("loading " + async.progress.ToString("n2"));
            //StartCoroutine(Wait(3.3f));
            yield return null;
        }
        

    }

    public void Skip() {
        async.allowSceneActivation = true;
    }

}
