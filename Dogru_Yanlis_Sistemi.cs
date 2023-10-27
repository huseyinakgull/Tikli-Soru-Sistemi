using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dogru_Yanlis_Sistemi : MonoBehaviour
{
    public Button[] Butonlar;
    public bool[] isaretlendi;
    public bool[] dogrucevaplar;
    public Button �lerleme_Butonu;
    public int Yanl��_G�z�kme_S�resi;
    public GameObject Yanl��_Yaz�s�;

    void Start()
    {
        isaretlendi = new bool[Butonlar.Length];
        �lerleme_Butonu.gameObject.SetActive(false);
    }

    public void �saretle(int index)
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
            Debug.Log("Tebrikler, t�m i�aretlemeler do�ru!");
            �lerleme_Butonu.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Hala yanl��lar var.");
            StartCoroutine(YanlisYazi());
        }
    }
    IEnumerator YanlisYazi()
    {
        Yanl��_Yaz�s�.gameObject.SetActive(true);
        yield return new WaitForSeconds(Yanl��_G�z�kme_S�resi);
        Yanl��_Yaz�s�.gameObject.SetActive(false);
    }
}
