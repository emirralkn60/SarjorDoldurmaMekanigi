using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SarjorDoldurma : MonoBehaviour
{


    int toplamMermiSayisi;
    public int sarjorKapasitesi;
    int kalanMermiSayisi;
    public string silahinAdi;
    public TextMeshProUGUI toplamMermiSayisi_text;
    public TextMeshProUGUI kalanMermiSayisi_text;
    int AtilmisOlanMermi;


    void sarjörDoldurmaTeknikFonksiyon(string tur)
    {
        switch (tur)
        {
            case "MermiVar":

                if (toplamMermiSayisi <= sarjorKapasitesi)
                {
                    int oluþanToplamDeger = kalanMermiSayisi + toplamMermiSayisi;
                    if (oluþanToplamDeger > sarjorKapasitesi)
                    {
                        kalanMermiSayisi = sarjorKapasitesi;
                        toplamMermiSayisi = oluþanToplamDeger - sarjorKapasitesi;
                        PlayerPrefs.SetInt(silahinAdi + "_Mermi", toplamMermiSayisi);
                    }
                    else
                    {
                        kalanMermiSayisi += toplamMermiSayisi;
                        toplamMermiSayisi = 0;
                        PlayerPrefs.SetInt(silahinAdi + "_Mermi", 0);

                    }
                }
                else
                {
                    AtilmisOlanMermi = sarjorKapasitesi - kalanMermiSayisi;
                    toplamMermiSayisi -= AtilmisOlanMermi;
                    kalanMermiSayisi = sarjorKapasitesi;
                    PlayerPrefs.SetInt(silahinAdi + "_Mermi", toplamMermiSayisi);
                }

                toplamMermiSayisi_text.text = toplamMermiSayisi.ToString();
                kalanMermiSayisi_text.text = kalanMermiSayisi.ToString();
                break;
            case "MermiYok":

                if (toplamMermiSayisi <= sarjorKapasitesi) // son reload kýsmý gibi düþün 
                {
                    kalanMermiSayisi = toplamMermiSayisi;
                    toplamMermiSayisi = 0;
                    PlayerPrefs.SetInt(silahinAdi + "_Mermi", 0);
                }
                else
                {
                    toplamMermiSayisi -= sarjorKapasitesi;
                    PlayerPrefs.SetInt(silahinAdi + "_Mermi", toplamMermiSayisi);
                    kalanMermiSayisi = sarjorKapasitesi;
                }
                toplamMermiSayisi_text.text = toplamMermiSayisi.ToString();
                kalanMermiSayisi_text.text = kalanMermiSayisi.ToString();
                break;
            case "NormalYaz":
                toplamMermiSayisi_text.text = toplamMermiSayisi.ToString();
                kalanMermiSayisi_text.text = kalanMermiSayisi.ToString();
                break;
        }

    }
}
