using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : MonoBehaviour
{
     bool go_out=false;
     public GameObject tr1,tr2,ogmesh;
     Vector3 spikes_og_size;
    public float timercurr,timermax=1;bool tilt=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
    {if (tilt)
        {
            timercurr += Time.deltaTime;
            if (timercurr >= timermax)
            {
                this.tag="Ouch";
                 tr2.tag="Ouch";
                   
                 tr2.transform.localScale=   new Vector3(1,1,1);    tr1.transform.localScale=   new Vector3(0,0,0);  
                    
            }
            if(timercurr<timermax)
            {
                    tr1.transform.localScale=   new Vector3(1,1,1); tr2.transform.localScale=   new Vector3(0,0,0);        
   
            }
           
        }
        else
        {
            timercurr = 0;
        }
    }
    public void Die()
    {
        if (go_out)
        {
         
        }
        else
        {
           
        }
    }private void OnTriggerEnter2D(Collider2D other)
    {
 if (other.tag=="Player")
        {tilt=true; ogmesh.transform.localScale=   new Vector3(0,0,0); }       
    }
}