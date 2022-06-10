using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSoal : MonoBehaviour
{
    [System.Serializable]
    public class Soal{
        [System.Serializable]
        public class ElementSoal{
            [TextArea]
            public string soal;
            public string[] jawaban;
            public int jawabanbenar; // angka array dari jwaban yang bernilai benar
        }
        public ElementSoal elementSoal;   
    }

    public List<Soal> soals;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
