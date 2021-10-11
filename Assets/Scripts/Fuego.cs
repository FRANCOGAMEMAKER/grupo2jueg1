using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    int apagar = 400;
    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        if(apagar <= 0)
        {
            Destroy(this.gameObject);
        }
        if(apagar > 0 && apagar < 400)
        {
            apagar += 1;
            tr.localScale += new Vector3(0.001f, 0.001f, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "water")
        {
            apagar -= 2;
            tr.localScale -= new Vector3(0.002f, 0.002f, 0);
        }
    }
}
