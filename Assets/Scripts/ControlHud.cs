using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlHud : MonoBehaviour
{
    // Tres variables: vidas, tiempo y puntuación
    public TextMeshProUGUI vidasTxt;
    public TextMeshProUGUI tiempoTxt;
    public TextMeshProUGUI puntuacionesTxt;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVidasTxt(int vidas)
    {
        vidasTxt.text = "Vidas: " + vidas;
    }

    public void setPuntuacionesTxt(int puntuacion)
    {
        puntuacionesTxt.text = "Puntos: " + puntuacion;
    }

    // El del tiempo es diferente; baja a cada momento
    public void setTiempoText(int tiempo)
    {
        // Quiero pasarlo a tiempo para que lo muestre como dos dígitos de minutos, dos puntos y dos dígitos de segundos
        int minutos = tiempo / 60;
        int segundos = tiempo % 60;
        tiempoTxt.text = minutos.ToString("00") + ":" + segundos.ToString("00");
        // los dos cerillos es para darle formato de dos dígitos
    }
}
