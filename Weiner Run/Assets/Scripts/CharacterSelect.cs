using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public Text price;
    public GameObject Select;
    public GameObject Selected;
    public GameObject itemPrice;

    public static GameObject[] characterList;
    private int index;

    private void Start()
    {
        index = PlayerPrefs.GetInt("Character", 0);

        characterList = new GameObject[transform.childCount];

        //fill array
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        //turn them all off
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }

        //turn on selected character and selected text
        if (characterList[index])
        {
            characterList[index].SetActive(true);
            Select.SetActive(false);
            Selected.SetActive(true);
            itemPrice.SetActive(false);
        }
    }

    public void ToggleLeft()
    {
        //toggle off model
        characterList[index].SetActive(false);

        if (index == 1)
        {
            Debug.Log("On first item " + index);
            itemPrice.SetActive(false);
        }

        index--;
        if (index < 0)
            index = characterList.Length - 1;

        //toggle on new model
        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        //toggle off model
        characterList[index].SetActive(false);


        if (index == characterList.Length - 1)
        {
            Debug.Log("On first item " + index);
            itemPrice.SetActive(false);
        }

        index++;
        if (index == characterList.Length)
            index = 0;

        //toggle on new model
        characterList[index].SetActive(true);
    }

    public void select()
    {
        ShopScript.Instance.BuyItem(ShopScript.DetermineWeiner());

        if (ShopScript.DetermineBought() == 1)
        {
            PlayerPrefs.SetInt("Character", index);
            Select.SetActive(false);
            Selected.SetActive(true);
            itemPrice.SetActive(false);
        }
    }
    
}
