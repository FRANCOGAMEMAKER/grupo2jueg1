using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callmusictransition : MonoBehaviour
{
    //
    public int song_to_request_index = 0;
    int current_song_index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") { RequestSetPlayingAmbientSound(song_to_request_index); }
        
    }

    public void RequestSetPlayingAmbientSound(int song_index)
    {
        current_song_index = GameObject.FindGameObjectWithTag("GlobalAUDIO").GetComponent<AudioLayersHandler>().current_song_index;
       GameObject.FindGameObjectWithTag("GlobalAUDIO").GetComponent<AudioLayersHandler>().Layer0FadeOut(current_song_index, 3);
        GameObject.FindGameObjectWithTag("GlobalAUDIO").GetComponent<AudioLayersHandler>().Layer0FadeIn(song_index, 3);
    }
}

