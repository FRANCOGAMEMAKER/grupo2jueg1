using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioClipPlayer : MonoBehaviour
{
    public AudioClip[] audio_clip =new AudioClip[1];

     AudioSource[] audio_players;
    public int current_or_last_audio_index=0;
       
    // Start is called before the first frame update
    void Start()
    {
      
        audio_players = new AudioSource[GetComponents<AudioSource>().Length];
        audio_players = GetComponents<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(int audio_index,float countdown,int source_index)//put 0 on countdown to disable countdown and put a negative number to enable looping
    {
       // audio_player.enabled = true;
       // audio_player.mute = false;
        if (audio_index >= 0) { current_or_last_audio_index = audio_index; }
        else { current_or_last_audio_index = 0; }

        audio_players[source_index].Stop();
        audio_players[source_index].clip = audio_clip[audio_index];
        audio_players[source_index].PlayDelayed(0.05f);


        if (countdown < 0) { audio_players[source_index].loop = true; countdown = 0; }
        else { audio_players[source_index].loop = false; }
        StartCoroutine(autostopintime(countdown));
    }

    IEnumerator autostopintime(float time)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(time);
        if (time > 0)
            {
                audio_players[0].Stop();
            audio_players[1].Stop();
            // audio_player.enabled = false;
            // audio_player.mute = true;
        }     
      
       
       
    }

    public void PlayAudioSimple()
    {
       audio_players[0].Stop();
       audio_players[0].clip = audio_clip[0];
     //  audio_player.enabled = true;
      // audio_player.mute = false;
        audio_players[0].PlayDelayed(0.05f);
        StartCoroutine(autostopintime(0.9f));
    }
    public void StopAudio(int audio_index,int source_index)
    {
        if (current_or_last_audio_index == audio_index)
        {
            audio_players[source_index].Stop();
            //audio_player.enabled = false;
            //audio_player.mute = true;
        }
    }
}
