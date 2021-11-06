using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bush_behaviour : MonoBehaviour
{
      public float fire_health=5,og_fire_health;bool ded=false;
    bool bein_watered=false;    // Start is called before the first frame update
    void Start()
    {
        og_fire_health=fire_health;
        
    }

    // Update is called once per frame
    void Update()
    {
       
     
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
      if (other.gameObject.tag=="water")
      {
           bein_watered=true;
            fire_health-=0.1f;
            
            if(fire_health<0&&ded==false)
            {ded=true;
            fcount.count+=1;
            if (fcount.count>fcount.max)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Respiracion>().ded=true;
            }
            else{}
            Destroy(this.gameObject,0.2f);
                GetComponent<AudioClipPlayer>().PlayAudioSimple();
                }
      }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag=="water")
      {
           bein_watered=false;
           
      }  
    }
}
