using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparo : MonoBehaviour
{
    public float agua;
    public float MaxAgua;

    public Image Barra;
    public GameObject Bullet;
    public Transform TR;
    public float speed;


    void Update()
    {
        Vector2 Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKey(KeyCode.Mouse0) && agua > 0)
        {
            GameObject bullet = Instantiate(Bullet, TR.position, TR.rotation);
            Destroy(bullet,0.5f);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(TR.right * speed, ForceMode2D.Impulse);
            agua -= 1;
        }

        BarraMostrar();
    }
   
     private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Recarga" && Input.GetKeyUp(KeyCode.Space))
        {
            agua += 125;
        }

        if(agua > MaxAgua)
        {
            agua = MaxAgua;
        }
    }

    void BarraMostrar()
    {
        Barra.fillAmount = agua / MaxAgua;
    }
}
