using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{
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
        Invoke("changetomenu", 5);
    }
    public void changetointro()
    {
        SceneManager.LoadScene("intro");
    }public void changetointrotim()
    {
       Invoke("changetointro", 0.1f);
    }
    public void changetomenu()
    {
        SceneManager.LoadScene("Menu");
    }public void changetomenubtn()
    {
          Invoke("changetomenu", 0.1f);
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