using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class PlayerMove : MonoBehaviour
{
    public float speed,ddge_speed=1,ddge_dlay=1,ddge_curr_tim;
    public Rigidbody2D Rb2d;public bool ddge=false,up=false;
    Vector2 og_ddpos,target_ddpos;


bool is_step=false,is_water=false,is_standing=true;

    void Start()
    {
       // Rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&ddge==false)
        {
            ddge_curr_tim=0;
            ddge=true;
           og_ddpos=Rb2d.transform.position;
           if(up)
           {
 Rb2d.AddForce(new Vector2(0,ddge_speed));
           }
           else
           {
                Rb2d.AddForce(new Vector2(0,-1*ddge_speed));
           }
          
        }
        if (ddge&&ddge_curr_tim<1)
        {
            ddge_curr_tim+=Time.deltaTime/ddge_dlay;
        }
        else{ddge=false;}
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Rb2d.velocity = new Vector2(x * speed, y * speed);
        if (Mathf.Abs( x)+Mathf.Abs(y)>0.01f&&is_step==false)
        {is_step=true;is_standing=false;is_water=false;
            GetComponent<AudioClipPlayer>().StopAudio(1,0);   GetComponent<AudioClipPlayer>().StopAudio(2,0); 
            GetComponent<AudioClipPlayer>().PlayAudio(0,-1,0);
        }
        else
        {
            
            if (Input.GetKey(KeyCode.Mouse0) &&  GetComponent<Disparo>().agua > 0 &&is_water==false && Mathf.Abs( x)+Mathf.Abs(y)<=0.01f)
        {
            is_standing=false;is_step=false;is_water=true;
            GetComponent<AudioClipPlayer>().StopAudio(0,0);   GetComponent<AudioClipPlayer>().StopAudio(2,0);
                GetComponent<AudioClipPlayer>().PlayAudio(1,-1,0);  
        }
        else
        {
            if (is_standing==false&&Mathf.Abs( x)+Mathf.Abs(y)<=0.01f&&Input.GetKey(KeyCode.Mouse0)==false)
            {
                is_water=false;is_step=false;is_standing=true;
            
            GetComponent<AudioClipPlayer>().StopAudio(1,0);GetComponent<AudioClipPlayer>().StopAudio(0,0);
             GetComponent<AudioClipPlayer>().PlayAudio(2,-1,0);}  
             else
             {
                   // GetComponent<AudioClipPlayer>().StopAudio(1,0);GetComponent<AudioClipPlayer>().StopAudio(0,0);GetComponent<AudioClipPlayer>().StopAudio(2,0);
             }
        }

        }
    }
private void OnTriggerEnter2D(Collider2D other)
{
    if(other.tag=="Ouch")
    {
        SceneManager.LoadScene("end");
    }
    else
    {
        
    }
    if (other.tag=="up")
    {
        up=true;
    }
    else
    {
        if (other.tag=="dwn")
        {
            up=false;
        }
    }
}
}
