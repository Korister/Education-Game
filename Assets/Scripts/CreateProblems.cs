using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateProblems : MonoBehaviour
{
    #region Basic Operations - Variables

    [Header("Variables - Operaciones basicas")]
    public int res;     public int x;   public int y;   public int maxRange;

    [Header("Panel juego - Operaciones basicas")]
    public int intText;
    [SerializeField] private Text problemText;
    [SerializeField] private InputField inputText;
    [Tooltip("0. Good\n1. Bad\n2. Restart\n3. Minus")]
    [SerializeField] private GameObject[] images = new GameObject[4];
    [Tooltip("0. Good\n1. Bad")]
    [SerializeField] private AudioSource[] audios = new AudioSource[2];
    private int op;

    #endregion

    #region Basic Operations - Codigo

    public void BasicOperations(int operacion)
    {
        op = operacion;
        maxRange = PlayerPrefs.GetInt("MaxRange");
        inputText.text = ""; images[3].SetActive(false);
        switch (operacion)
        {
            case 0: //Suma
                Suma();
                break;
            case 1: //Resta
                Resta();
                break;
            case 2: //Multiplicacion
                Multiplicacion();
                break;
            case 3: //Division
                Division();
                break;
        }
    }

    void Suma()
    {
        x = Random.Range(1, (maxRange + 1)); y = Random.Range(1, (maxRange + 1)); res = x + y;
        problemText.text = x + " + " + y + " = ?";
    }

    void Resta()
    {
        x = Random.Range(1, (maxRange + 1)); y = Random.Range(1, (maxRange + 1)); res = x - y;
        if (res < 0)
        {
            res *= -1; images[3].SetActive(true);
        }
        problemText.text = x + " - " + y + " = ?";
    }

    void Multiplicacion()
    {
        x = Random.Range(1, maxRange); y = Random.Range(1, maxRange); res = x * y;
        problemText.text = x + " * " + y + " = ?";
    }

    void Division()
    {
        x = Random.Range(1, maxRange); y = Random.Range(1, maxRange); int res1 = x * y; res = res1 / x;
        problemText.text = res1 + " / " + x + " = ?";
    }

    

    public void VerificarBasicOperations()
    {
        intText = int.Parse(inputText.text);
        if (res == intText)
        {
            //Play audio
            audios[0].Play(0);
            //Show images
            images[0].SetActive(true);
            images[1].SetActive(false);
        }
        else
        {
            //Play audio
            audios[1].Play(0);
            //Show images
            images[0].SetActive(false);
            images[1].SetActive(true);
        }
        images[2].SetActive(true);
    }

    public void ReiniciarBasicOperations()
    {
        BasicOperations(op);
    }

    #endregion
}