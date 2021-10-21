using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioLayersHandler : MonoBehaviour
{
    public bool is_mainmenu = false;

    public AudioClip[] layer0clip = new AudioClip[4];

    public AudioSource[] layer0players;

    public int current_song_index = 0;

    GameObject layer_0_player;

    public AudioMixerGroup mixerlayer0;
    public AudioMixerGroup mixerlayer1;
    public AudioMixerGroup mixerlayer2;
    public AudioMixerGroup mixerlayer3;

        public AudioMixerGroup edit_mixerlayer0;
    public AudioMixerGroup edit_mixerlayer1;
    public AudioMixerGroup edit_mixerlayer2;
    public AudioMixerGroup edit_mixerlayer3;

    




    // Start is called before the first frame update
    void Start()
    {
        layer_0_player = GameObject.FindGameObjectWithTag("audio layer0 player");
        layer0players = new AudioSource[layer_0_player.GetComponents<AudioSource>().Length];
        layer0players = layer_0_player.GetComponents<AudioSource>();

        for (int i = 0; i < layer0players.Length; i++)
        {
            layer_0_player.GetComponents<AudioSource>()[i].clip = layer0clip[i];
        }


        StartCoroutine(Layer_0_FadeIn(current_song_index, 3));  //

        if (is_mainmenu == true)
        {
            mixerlayer0.audioMixer.SetFloat("layer0volume", 1);//bg audio i guess
            mixerlayer1.audioMixer.SetFloat("layer1volume", 0);
            mixerlayer2.audioMixer.SetFloat("layer2volume", 0);//ui buttons i think
            mixerlayer3.audioMixer.SetFloat("layer3volume", 0);

            GameObject.FindGameObjectWithTag("audio layer0 player").GetComponent<AudioSource>().loop = true;
            GameObject.FindGameObjectWithTag("audio layer0 player").GetComponent<AudioSource>().Stop();
            GameObject.FindGameObjectWithTag("audio layer0 player").GetComponent<AudioSource>().Play();
        }
        else
        {
            mixerlayer0.audioMixer.SetFloat("layer0volume", 0);//bg audio i guess
            mixerlayer1.audioMixer.SetFloat("layer1volume", 0);
            mixerlayer2.audioMixer.SetFloat("layer2volume", 0);//ui buttons i think
            mixerlayer3.audioMixer.SetFloat("layer3volume", 0);
        }

       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
public void SetAllVolume(float a)
{
     edit_mixerlayer0.audioMixer.SetFloat("layer_0_slider_volume",a);
}

    public void MuteLayer1()
    {
        mixerlayer1.audioMixer.SetFloat("layer1volume", -80);
    }


    public void Layer0FadeOut(int audioindex, float FadeTime)
    {
        StartCoroutine(Layer_0_FadeOut(audioindex, FadeTime));
    }

    public void Layer0FadeIn(int audioindex, float FadeTime)
    {
        StartCoroutine(Layer_0_FadeIn(audioindex, FadeTime));
    }

    public IEnumerator Layer_0_FadeOut(int audioindex, float FadeTime)
    {
        current_song_index = audioindex;
        float startVolume = layer_0_player.GetComponents<AudioSource>()[audioindex].volume;
        while (layer_0_player.GetComponents<AudioSource>()[audioindex].volume > 0)
        {
            layer_0_player.GetComponents<AudioSource>()[audioindex].volume -= startVolume * Time.unscaledDeltaTime / FadeTime;
            yield return null;
        }
        // layer_0_player.GetComponents<AudioSource>()[audioindex].Stop();

    }

    public IEnumerator Layer_0_FadeIn(int audioindex, float FadeTime)
    {
        current_song_index = audioindex;
        layer_0_player.GetComponents<AudioSource>()[audioindex].Play();
        layer_0_player.GetComponents<AudioSource>()[audioindex].volume = 0f;
        while (layer_0_player.GetComponents<AudioSource>()[audioindex].volume < 1 && current_song_index == audioindex)
        {
            layer_0_player.GetComponents<AudioSource>()[audioindex].volume += Time.unscaledDeltaTime / FadeTime;
            yield return null;
        }
    }



}
//audio