using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsyncLoad : MonoBehaviour {

    public Text TextoBoton;
    public Transform CuboRota;
    public CanvasGroup mycanvasgroup;
    public Transform progress;

    // cuando pulso
    public void Cargar() {
        TextoBoton.text = "Cargando";
        mycanvasgroup.interactable = false;

        //el cubo y carga async
    }
}
