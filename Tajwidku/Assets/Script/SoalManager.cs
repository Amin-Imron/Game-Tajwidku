using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoalManager : MonoBehaviour
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
    public GameObject benar, salah, selesai, TextSoal, Waktu, Button;
    private bool Benar;
    public int skor;
    public float waktu;
    private int nilaiAcak;
    private Animator anim;
    int nomorSoal = -1;
    Text textSoal, textWaktu, textSkor, papanSkor;
    Image textA, textB, textC;
    public List<Soal> KumpulanSoal;
    void Start()
    {
        textSoal = GameObject.Find("TextSoal").GetComponent<Text>();
        textSkor = GameObject.Find("TextSkor").GetComponent<Text>();

        textA = GameObject.Find("Button A").GetComponent<Image>();
        textB = GameObject.Find("Button B").GetComponent<Image>();
        textC = GameObject.Find("Button C").GetComponent<Image>();

        textWaktu = GameObject.Find("TextWaktu").GetComponent<Text>();
        nilaiAcak = Random.RandomRange(0, KumpulanSoal.Count);
        nomorSoal++;
        anim = GetComponent<Animator>();

        // textSoal.text = KumpulanSoal[nomorSoal].soal;
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
            textSkor.text = skor.ToString();
            textSoal.text = KumpulanSoal[nilaiAcak].soal;
            textA.sprite = KumpulanSoal[nilaiAcak].pilA;
            textB.sprite = KumpulanSoal[nilaiAcak].pilB;
            textC.sprite = KumpulanSoal[nilaiAcak].pilC;
        }
        else
        {
            Selesai();
        }
    }
    void Selesai()
    {
        waktu += Time.deltaTime;
        selesai.SetActive(true);
        Waktu.SetActive(false);
        Button.SetActive(false);
        TextSoal.SetActive(false);
        textSkor.text = "" + skor;
        // GameObject.Find("TextWaktu").SetActive(false);
        // GameObject.Find("TextSoal").SetActive(false);
        // GameObject.Find("Button").SetActive(false);
    }
    public void CekJawaban(string jawaban)
    {
        //Cek Jawaban Benar
        if (KumpulanSoal[nilaiAcak].A == true && jawaban == "a")
        {
            feed_benar();
        }
        if (KumpulanSoal[nilaiAcak].B == true && jawaban == "b")
        {
            feed_benar();
        }
        if (KumpulanSoal[nilaiAcak].C == true && jawaban == "c")
        {
            feed_benar();
        }
        // Cek Jawaban Salah
        if (KumpulanSoal[nilaiAcak].A == false && jawaban == "a")
        {
            feed_salah();
        }
        if (KumpulanSoal[nilaiAcak].B == false && jawaban == "b")
        {
            feed_salah();
        }
        if (KumpulanSoal[nilaiAcak].C == false && jawaban == "c")
        {
            feed_salah();
        }
        KumpulanSoal.RemoveAt(nilaiAcak); // menghapus soal ketika sudah terjawab
        waktu = 10;
        nilaiAcak = Random.RandomRange(0, KumpulanSoal.Count); //menampilkan soal baru secara acak
    }
    void feed_benar()
    {
        skor += 20;
        benar.SetActive(false);
        benar.SetActive(true);
        salah.SetActive(false);
    }
    // void feed_benar()
    // {
    //     Benar = true;
    //     skor += 10;
    // }
    void feed_salah()
    {
        salah.SetActive(false);
        salah.SetActive(true);
    }
    void RunAnimations()
    {
        // anim.SetFloat("Movement", Mathf.Abs(move));

    }
}
