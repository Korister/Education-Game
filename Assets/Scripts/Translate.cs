using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Translate : MonoBehaviour
{
    [SerializeField]private Dropdown dropdown;
    private int x;

    #region Menu principal - Variables

    [Header("Menú principal")]
    [Tooltip("0. Play\n1. Options\n2. Credits")]
    public Text[] buttonsMain = new Text[3];
    [Tooltip("0. Spanish\n1. English")]
    public string[] play = new string[2];
    public string[] options = new string[2];
    public string[] credits = new string[2];

    #endregion

    #region Menu opciones - Variables

    [Header("Menú de opciones")]
    [Tooltip("0. Options\n1. Basic Header\n2. Volume Header\n3. Language Header\n4. Max no\n5. SFX\n6. Music\n7. Language")]
    public Text[] optionsTexts = new Text[8];
    [Tooltip("0. Spanish\n1. English")]
    public string[] basicOp = new string[2];
    public string[] vol = new string[2];
    public string[] lang = new string[2];
    public string[] max = new string[2];
    public string[] sfx = new string[2];
    public string[] music = new string[2];

    #endregion

    #region Menu seleccion - Variables

    [Header("Menú de selección")]
    [Tooltip("0. Select\n1. Basic operations")]
    public Text[] selectTexts = new Text[2];
    [Tooltip("0. Spanish\n1. English")]
    public string[] select = new string[2];

    #endregion

    #region Menu operacion - Variables

    [Header("Menú de selección")]
    [Tooltip("0. Operation\n1. Sum\n2. Difference\n3. Product\n4. Division")]
    public Text[] operationTexts = new Text[5];
    [Tooltip("0. Spanish\n1. English")]
    public string[] operation = new string[2];
    public string[] sum = new string[2];
    public string[] diff = new string[2];
    public string[] product = new string[2];
    public string[] division = new string[2];

    #endregion

    #region Cambiar textos

    private void Start()
    {
        x = PlayerPrefs.GetInt("Language", 0);
        dropdown.value = x;
        ChangeTexts();
    }

    public void ChangeTexts()
    {
        x = dropdown.value;
        #region Menu principal
        buttonsMain[0].text = play[x];
        buttonsMain[1].text = options[x];
        buttonsMain[2].text = credits[x];
        #endregion

        #region Opciones
        optionsTexts[0].text = options[x];
        optionsTexts[1].text = basicOp[x];
        optionsTexts[2].text = vol[x];
        optionsTexts[3].text = lang[x];
        optionsTexts[4].text = max[x];
        optionsTexts[5].text = sfx[x];
        optionsTexts[6].text = music[x];
        optionsTexts[7].text = lang[x];
        #endregion

        #region Seleccionar
        selectTexts[0].text = select[x];
        selectTexts[1].text = basicOp[x];
        #endregion

        #region Operaciones
        operationTexts[0].text = operation[x];
        operationTexts[1].text = sum[x];
        operationTexts[2].text = diff[x];
        operationTexts[3].text = product[x];
        operationTexts[4].text = division[x];
        #endregion
        PlayerPrefs.SetInt("Language", x);
    }

    #endregion
}
