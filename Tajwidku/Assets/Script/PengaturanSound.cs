using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PengaturanSound : MonoBehaviour
{
    public AudioSource lagu1, lagu2, touch;
    // Start is called before the first frame update
    public Slider volume_music, volume_effect;
    void Start()
    {
        
    }
    void OnMouseDown() {
        touch.Play ();
        if(gameObject.name == "tombol lagu 1"){
            lagu1.Play();
            lagu2.Stop();
        }else
        {
            lagu1.Stop();
            lagu2.Play();
            lagu2.volume = volume_music.value;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
