using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jawab : MonoBehaviour
{
    public GameObject benar, salah, selesai;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Skor", 0);
    }
    public void jawaban(bool jawab)
    {
        if (jawab)
        {
            benar.SetActive(false);
            benar.SetActive(true);
            int skor = PlayerPrefs.GetInt("skor") + 10;
            PlayerPrefs.SetInt("Skor", skor);
        }
        else
        {
            salah.SetActive(false);
            salah.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
