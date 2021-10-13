using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : MonoBehaviour
{
     public float curr_time,delay=1,time_in=1,time_out=1;
     bool go_out=false;
     public GameObject spikes,meltmesh1,meltmesh2;
     Vector3 spikes_og_size;
    float timercurr,timermax=1;bool tilt=false;
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
                Die();
                 meltmesh2.transform.localScale=   new Vector3(1,1,1);    meltmesh1.transform.localScale=   new Vector3(0,0,0);      
            }
            if(timercurr<timermax)
            {
                    meltmesh1.transform.localScale=   new Vector3(1,1,1); meltmesh2.transform.localScale=   new Vector3(0,0,0);        
   
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
        {tilt=true;}       
    }
}