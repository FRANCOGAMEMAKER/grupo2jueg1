using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirada : MonoBehaviour
{
    [SerializeField]
    Transform target;


    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            target = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseMira = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseMira.z = 0;

        Vector3 Direccion = mouseMira - target.position;
        target.right = Direccion;
    }
}
