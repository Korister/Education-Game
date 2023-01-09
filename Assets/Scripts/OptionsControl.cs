using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsControl : MonoBehaviour
{
    [SerializeField] private Text versionText;
    [SerializeField] private Text companyNameText;
    [SerializeField] private Text gameTitleText;

    #region Operaciones basicas - Varibles

    [Header("Operaciones basicas")]
    public int maxRange;
    public Slider rangeSlider;
    public Text maxRangeText;

    #endregion

    #region Volumen - variables

    [Header("Volumen")]
    public float[] volumeValue = new float[2]; //1      SFX     2 Music
    public Slider[] soundSlider = new Slider[2]; //1      SFX     2 Music
    public Text[] volumeText = new Text[2]; //1      SFX     2 Music
    public AudioSource[] sfxSounds = new AudioSource[5];
    public AudioSource[] musicSounds = new AudioSource[1];
    float x1, y1; 
    int x2, y2;

    #endregion

    private void Start()
    {
        //Textos
        versionText.text = Application.version;
        companyNameText.text = Application.companyName;
        gameTitleText.text = Application.productName;

        //MaxRange Options
        maxRange = PlayerPrefs.GetInt("MaxRange", 10);
        maxRangeText.text = maxRange.ToString();
        rangeSlider.value = maxRange;

        //SFXVolume Options
        volumeValue[0] = PlayerPrefs.GetFloat("SFXVol", 1);
        soundSlider[0].value = volumeValue[0]; 
        x1 = volumeValue[0] * 100; x2 = (int)x1;
        volumeText[0].text = x2 + "%";

        for (int i = 0; i < sfxSounds.Length; i++)
            sfxSounds[i].volume = volumeValue[0];

        //MusicVolume Options
        volumeValue[1] = PlayerPrefs.GetFloat("MusicVol", 1);
        soundSlider[1].value = volumeValue[1];
        y1 = volumeValue[1] * 100; y2 = (int)y1;
        volumeText[1].text = y2 + "%";

        for (int i = 0; i < musicSounds.Length; i++)
            musicSounds[i].volume = volumeValue[1];
    }

    #region Operaciones basicas - Funciones

    public void MaxRange_OnValueChange()
    {
        maxRange = (int)rangeSlider.value;
        maxRangeText.text = maxRange.ToString();
       
        PlayerPrefs.SetInt("MaxRange", maxRange);
        PlayerPrefs.Save();
    }

    #endregion

    #region Volumen - Funciones

    public void SFXSound_OnValueChange()
    {
        volumeValue[0] = soundSlider[0].value;
        x1 = volumeValue[0] * 100; x2 = (int)x1;
        volumeText[0].text = x2 + "%";

        for (int i = 0; i < sfxSounds.Length; i++)
            sfxSounds[i].volume = volumeValue[0];

        PlayerPrefs.SetFloat("SFXVol", volumeValue[0]);
        PlayerPrefs.Save();
    }

    public void MusicSound_OnValueChange()
    {
        volumeValue[1] = soundSlider[1].value;
        y1 = volumeValue[1] * 100; y2 = (int)y1;
        volumeText[1].text = y2 + "%";

        for (int i = 0; i < musicSounds.Length; i++)
            musicSounds[i].volume = volumeValue[1];

        PlayerPrefs.SetFloat("MusicVol", volumeValue[1]);
        PlayerPrefs.Save();
    }

    #endregion

    public void Quit()
    {
        Application.Quit();
    }
}
