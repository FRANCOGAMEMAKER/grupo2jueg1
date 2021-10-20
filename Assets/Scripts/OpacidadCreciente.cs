using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore.LowLevel;

public class OpacidadCreciente : MonoBehaviour
{
    [SerializeField] bool Creciente, IsText, IsImage;
    Image Seleccion;
    Text Lore;
    public float Opacidad;

    void Start()
    {
        Seleccion = GetComponent<Image>();
        Lore = GetComponent<Text>();
    }
    void Update()
    {
        OpacidadCambio();
    }
    void OpacidadCambio()
    {
        if (Creciente && Opacidad < 1)
        {
            Opacidad += 0.001f;
            if(IsImage)
                Seleccion.color = new Color(Seleccion.color.r, Seleccion.color.g, Seleccion.color.b, Opacidad);

            if (IsText)
                Lore.color = new Color(Lore.color.r, Lore.color.g, Lore.color.b, Opacidad);
        }
        if (!Creciente && Opacidad > 0)
        {
            Opacidad -= 0.001f;
            if (IsImage)
                Seleccion.color = new Color(Seleccion.color.r, Seleccion.color.g, Seleccion.color.b, Opacidad);

            if (IsText)
                Lore.color = new Color(Lore.color.r, Lore.color.g, Lore.color.b, Opacidad);
        }
    }
}
