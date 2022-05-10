using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoalManager2 : MonoBehaviour
{
    [System.Serializable]
    public class Soal
    {
        [TextArea]
        [Header("Soal")]
        public string soal;

        [Header("Pilihan Untuk Jawaban")]
        public Sprite pilA;
        public Sprite pilB, pilC;
        [Header("Kunci Jawaban")]
        public bool A;
        public bool B, C;

    }
    // public string[] soal;
    // public string[] jawaban;

    // public Text text_soal, text_skor;
    public InputField input_jawaban;

    public GameObject feed_benar, feed_salah, selesai;

    int nomor_soal = -1, skor = 0;
    public float waktu;
    private int nilaiAcak;
    Text textSoal, textWaktu, textSkor;
    Image textA, textB, textC;
    public List<Soal> KumpulanSoal;
    void Start()
    {
        buka_soal();
        // textSoal = GameObject.Find("TextSoal").GetComponent<Text>();
        // textSkor = GameObject.Find("TextSkor").GetComponent<Text>();

        // textA = GameObject.Find("Button A").GetComponent<Image>();
        // textB = GameObject.Find("Button B").GetComponent<Image>();
        // textC = GameObject.Find("Button C").GetComponent<Image>();

        // textWaktu = GameObject.Find("TextWaktu").GetComponent<Text>();

        // nilaiAcak = Random.RandomRange(0, KumpulanSoal.Count);
    }
    void buka_soal()
    {
        nomor_soal++;
        textSoal.text = KumpulanSoal[nomor_soal].soal;
        textA.sprite = KumpulanSoal[nomor_soal].pilA;
        textB.sprite = KumpulanSoal[nomor_soal].pilB;
        textC.sprite = KumpulanSoal[nomor_soal].pilC;
    }
    // Update is called once per frame
    void Update()
    {
        textWaktu.text = "" + waktu;
        waktu -= Time.deltaTime;
        if (waktu <= 0)
        {
            KumpulanSoal.RemoveAt(nilaiAcak);
            waktu = 10;
            nilaiAcak = Random.RandomRange(0, KumpulanSoal.Count);
        }
        if (KumpulanSoal.Count > 0)
        {
            textSoal.text = KumpulanSoal[nilaiAcak].soal;
            textA.sprite = KumpulanSoal[nilaiAcak].pilA;
            textB.sprite = KumpulanSoal[nilaiAcak].pilB;
            textC.sprite = KumpulanSoal[nilaiAcak].pilC;
        }
        else
        {
            textSkor.text = "Skor : " + skor;
            GameObject.Find("TextWaktu").SetActive(false);
            GameObject.Find("TextSoal").SetActive(false);
            GameObject.Find("Button").SetActive(false);
        }


    }

    public void CekJawaban(string jawaban)
    {
        if (KumpulanSoal[nilaiAcak].A == true && jawaban == "a")
        {
            skor++;
        }
        if (KumpulanSoal[nilaiAcak].B == true && jawaban == "b")
        {
            skor++;
        }
        if (KumpulanSoal[nilaiAcak].C == true && jawaban == "c")
        {
            skor++;
        }
        KumpulanSoal.RemoveAt(nilaiAcak); // menghapus soal ketika sudah terjawab
        waktu = 10;
        nilaiAcak = Random.RandomRange(0, KumpulanSoal.Count); //menampilkan soal baru secara acak
    }
}
