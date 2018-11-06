using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCustomization : MonoBehaviour {

    public GameObject astro1;
    public GameObject astro2;
    public GameObject astro3;
    public GameObject astro4;
    public GameObject astro5;
    public GameObject astro6;
    public GameObject astro7;
    public GameObject astro8;
    public GameObject astro9;
    public GameObject astro10;
    public GameObject astro11;
    public GameObject astro12;

    private GameObject[] cust;

    void Start()
    {
        int index = PlayerPrefs.GetInt("Character", 0);

        cust = new GameObject[transform.childCount];

        //fill array
        for (int i = 0; i < transform.childCount; i++)
        {
            cust[i] = transform.GetChild(i).gameObject;
        }

        //turn them all off
        foreach (GameObject go in cust)
        {
            go.SetActive(false);
        }

        //turn on active
        if (cust[index])
        {
            cust[index].SetActive(true);

            if (index == 1)
            {
                ShowAstro();
            }
        }
    }

    public void ShowAstro()
    {
        astro1.SetActive(true);
        astro2.SetActive(true);
        astro3.SetActive(true);
        astro4.SetActive(true);
        astro5.SetActive(true);
        astro6.SetActive(true);
        astro7.SetActive(true);
        astro8.SetActive(true);
        astro9.SetActive(true);
        astro10.SetActive(true);
        astro11.SetActive(true);
        astro12.SetActive(true);
    }
}
