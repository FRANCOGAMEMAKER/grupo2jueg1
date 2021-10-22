using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : MonoBehaviour
{
     bool go_out=false;
     public GameObject tr1,tr2,ogmesh,anim_mesh;
     Vector3 spikes_og_size;
    public float timercurr,timermax=1;bool tilt=false,spawn_fall_anim=false;
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
                if(this.tag=="Player" && tr2.tag=="Player")
                {
                }
                else
                {
                    
                this.tag="Ouch";
                 tr2.tag="Ouch";
                   Invoke("yay",0.1f);
                }
                 tr2.transform.localScale=   new Vector3(1,1,1);    tr1.transform.localScale=   new Vector3(0,0,0);  
                    
            }
            if(timercurr<timermax)
            {
                    tr1.transform.localScale=   new Vector3(1,1,1); tr2.transform.localScale=   new Vector3(0,0,0);        
   
            }
           if (spawn_fall_anim==false)
           {
               spawn_fall_anim=true;
               Instantiate(anim_mesh,tr1.transform);
           }
           else
           {
               
           }
        }
        else
        {
            timercurr = 0;
        }
    }
    public void yay()
    {
         this.tag="Player";
                 tr2.tag="Player";
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
 if (other.tag=="Player")
        {tilt=true; ogmesh.transform.localScale=   new Vector3(0,0,0); }       
    }
}