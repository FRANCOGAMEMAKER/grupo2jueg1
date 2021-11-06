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
    public bool ded=false;
    void Update()
    {
        if(ded)
        {
             Oxigeno += 0.08f*Time.deltaTime;
        }
        if(ActivarRespiracion)
        Oxigeno += 0.08f*Time.deltaTime;

        OSCURECER.color = new Color(0f, 0f, 0f, Oxigeno);

        if(Input.GetKeyUp(KeyCode.Mouse1)&&ded==false)
            Oxigeno -= 5*Time.deltaTime;

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
