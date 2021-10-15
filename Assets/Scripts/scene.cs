using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{
    public int sceneind;
    // Start is called before the first frame update
    void Start()
    {
        switch (sceneind)
        {
            
            case 0:Invoke("changetogame",14);
            break;
            case 1:changetomenutim();
            break;
            case 2://Invoke();
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changetogame()
    {
        SceneManager.LoadScene("SampleScene");
    }
      public void changetomenutim()
    {
        Invoke("changetomenu",5);
    }
     public void changetointro()
    {
        SceneManager.LoadScene("intro");
    }
     public void changetomenu()
    {
        SceneManager.LoadScene("Menu");
    }
      public void changetocontrol()
    {
        SceneManager.LoadScene("control");
    }
      public void quit()
    {
            Application.Quit();

    }
    
    
}