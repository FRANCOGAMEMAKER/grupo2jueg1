using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PlayerMove : MonoBehaviour
{
    public float speed,ddge_speed=1,ddge_dist=1,ddge_curr_dist;
    public Rigidbody2D Rb2d;bool ddge=false;
    Vector2 og_ddpos,target_ddpos;



    void Start()
    {
       // Rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ddge_curr_dist=0;
            ddge=true;
           og_ddpos=Rb2d.transform.position;
           target_ddpos=og_ddpos+new Vector2(ddge_dist,ddge_dist);
        }
        if (ddge&&ddge_curr_dist<1)
        {
            ddge_curr_dist+=Time.deltaTime*ddge_speed;
            Rb2d.transform.position= new Vector2(Mathf.Lerp(og_ddpos.x,target_ddpos.x,ddge_curr_dist),Mathf.Lerp(og_ddpos.y,target_ddpos.y,ddge_curr_dist)) ;
        }
        else{ddge=false;}
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Rb2d.velocity = new Vector2(x * speed, y * speed);
    }
}
