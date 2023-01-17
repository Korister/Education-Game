using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsControl : MonoBehaviour
{
    public int probability, contador = 0;
    [SerializeField]
    private GameObject scripter;

    public void IntersitialAd()
    {
        if(contador == 0)
            scripter.GetComponent<AdIntersitial>().ShowAd();
        else
        {
            int x = Random.Range(0, 101);
            if(x <= probability)
                scripter.GetComponent<AdIntersitial>().ShowAd();
        }
        contador++;
    }
}
