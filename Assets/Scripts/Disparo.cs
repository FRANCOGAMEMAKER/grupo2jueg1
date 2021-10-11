using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public int agua;
    public int MaxAgua;

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
    }

    //void Disparar()
   // {
   //     Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
   //     if (Input.GetKey(KeyCode.Mouse0) && agua > 0)
   //     {
   //         Instantiate(Bullet, TR.position, TR.rotation);
   //         Bullet.GetComponent<Bullet>().Direction = Direction;
   //         agua -= 1;
   //     }
    //}
   
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
}
