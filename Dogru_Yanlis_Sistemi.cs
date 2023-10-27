using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dogru_Yanlis_Sistemi : MonoBehaviour
{
    public Button[] Butonlar;
    public bool[] isaretlendi;
    public bool[] dogrucevaplar;
    public Button Ýlerleme_Butonu;
    public int Yanlýþ_Gözükme_Süresi;
    public GameObject Yanlýþ_Yazýsý;

    void Start()
    {
        isaretlendi = new bool[Butonlar.Length];
        Ýlerleme_Butonu.gameObject.SetActive(false);
    }

    public void Ýsaretle(int index)
    {
        isaretlendi[index] = !isaretlendi[index];
        Butonlar[index].image.color = isaretlendi[index] ? new Color32(0, 255, 0, 255) : new Color32(255, 255, 255, 255);
    }

    public void KontrolEt()
    {
        bool hepsiDogru = true;

        for (int i = 0; i < Butonlar.Length; i++)
        {
            if (isaretlendi[i] != dogrucevaplar[i])
            {
                hepsiDogru = false;
                break;
            }
        }

        if (hepsiDogru)
        {
            Debug.Log("Tebrikler, tüm iþaretlemeler doðru!");
            Ýlerleme_Butonu.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Hala yanlýþlar var.");
            StartCoroutine(YanlisYazi());
        }
    }
    IEnumerator YanlisYazi()
    {
        Yanlýþ_Yazýsý.gameObject.SetActive(true);
        yield return new WaitForSeconds(Yanlýþ_Gözükme_Süresi);
        Yanlýþ_Yazýsý.gameObject.SetActive(false);
    }
}
