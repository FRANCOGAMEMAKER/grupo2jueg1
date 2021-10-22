using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autodestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float t=GetComponentInParent<log>().timermax;
        if(t>0)
        {
        Invoke("ded",t);}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void ded()
     {transform.localScale=new Vector3(0,0,0);
         Destroy(this.gameObject); }
}
