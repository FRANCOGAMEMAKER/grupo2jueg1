using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Respiracion : MonoBehaviour
{
    public Image OSCURECER;

    public bool ActivarRespiracion = true;
    public float Oxigeno;
    float MaxOxigeno = 1;
    void Update()
    {
        if(ActivarRespiracion)
        Oxigeno += 0.001f;

        OSCURECER.color = new Color(0f, 0f, 0f, Oxigeno);

        if(Input.GetKeyUp(KeyCode.Mouse1))
            Oxigeno -= 0.25f;

        if (Oxigeno > MaxOxigeno)
            changedead();

        if (Oxigeno < 0)
            Oxigeno = 0;
    }

    public void changedead()
    {
        SceneManager.LoadScene("end");
    }
}
