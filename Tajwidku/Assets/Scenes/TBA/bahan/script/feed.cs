using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feed : MonoBehaviour
{
    public GameObject bank_soal, skor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void feedback(){
        bank_soal.GetComponent<bank_soal>().control(1);
        if (gameObject.name == "benar"){
            skor.GetComponent<skor>().score += 20;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
