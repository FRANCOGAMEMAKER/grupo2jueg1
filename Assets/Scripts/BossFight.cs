using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFight : MonoBehaviour
{
    public GameObject START;
    public bool STARTER;
    bool WIN;
    bool LOSE;

    public Image Barra;
    Respiracion Rs;

    public float Carga;
    public float Victoria;

    private void Start()
    {
        Rs = GetComponent<Respiracion>();
    }

    void Update()
    {
        Barra.fillAmount = Carga / Victoria;
        if(STARTER == true)
        Carga -= 1;

        if (Input.GetKeyDown(KeyCode.Space) && STARTER == true )
        {
            if(WIN || LOSE)
            Carga += 60;
        }
        if (Carga < 0)
        {
            LOSE = true;
            STARTER = false;
            START.SetActive(false);
            Rs.ActivarRespiracion = true;
            Rs.Oxigeno = 0;
        }
        if (Carga > Victoria)
        {
            WIN = true;
            STARTER = false;
            START.SetActive(false);
            Rs.ActivarRespiracion = true;
            Rs.Oxigeno = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "StartBoss")
        {
            STARTER = true;
            START.SetActive(true);
            Rs.ActivarRespiracion = false;
            Rs.Oxigeno = 0;
        }
    }

}
