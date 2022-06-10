using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioSource asMusic;
    public AudioSource asSFX;

    public Text tMusic;
    // public Text tSFX;

    public static Music Instance { get; set; }

    private void Awake()
    {
        // asMusic = transform.position

        DontDestroyOnLoad(this);

        if(Instance == null)
        {
            Instance = this;
        }else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonInGame()
    {

        SceneManager.LoadScene(1);
    }
    public void ButtonMusicMute()
    {
        if(asMusic.mute == false)
        {
            asMusic.mute = true;
            tMusic.text = "off";

        }else
        {
            asMusic.mute = false;
            tMusic.text = "on";
        }
    }
}
