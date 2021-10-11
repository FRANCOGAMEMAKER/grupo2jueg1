using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bush_behaviour : MonoBehaviour
{
    public GameObject on_fire,mild_fire,calm;
    public float fire_health=5,og_fire_health;
    bool bein_watered=false;    // Start is called before the first frame update
    void Start()
    {
        og_fire_health=fire_health;
        
    }

    // Update is called once per frame
    void Update()
    {
       if (bein_watered==true)
       {
          // fire_health-=Time.deltaTime;
       }     
       else{}
       if (fire_health>=og_fire_health*(3/3))
       {
           //rage
           on_fire.gameObject.transform.localScale=new Vector3(1,1,1);
           mild_fire.gameObject.transform.localScale=new Vector3(0,0,0);
           calm.gameObject.transform.localScale=new Vector3(0,0,0);
       }  
       else
       {
            if (fire_health>0)
       {
           //mild
            on_fire.gameObject.transform.localScale=new Vector3(0,0,0);
           mild_fire.gameObject.transform.localScale=new Vector3(1,1,1);
           calm.gameObject.transform.localScale=new Vector3(0,0,0);
           //on_fire.gameObject.Transform.
           
       }
       else
       {
           //calm
            on_fire.gameObject.transform.localScale=new Vector3(0,0,0);
           mild_fire.gameObject.transform.localScale=new Vector3(0,0,0);
           calm.gameObject.transform.localScale=new Vector3(1,1,1);
       }
       }
     
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.tag=="water")
      {
           bein_watered=true;
            fire_health-=0.1f;
      }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag=="water")
      {
           bein_watered=false;
           
      }  
    }
}
