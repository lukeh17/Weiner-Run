using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public static ShopScript Instance { get; private set; }

    private JSONObject itemsData;

    public static int SelectedItemIndex { get; private set; }

    public class ShopItem
    {
        public bool Bought;
        public int Price;

        public ShopItem(bool bought, int price)
        {
            Bought = bought; Price = price;
        }
    }

    public static List<ShopItem> Items;
    public static int Pickles { get; private set; }

    //Objects
    public GameObject Select;
    public GameObject Selected;
    public GameObject ItemPrice;
    public static bool bought;
    public Text Price;
    
    public void Awake()
    {
        //for testing***
        //PlayerPrefs.DeleteAll();
      
        Instance = this;

        if (!PlayerPrefs.HasKey("Items"))
        {
            PlayerPrefs.SetString("Items", "{\"Items\":[{\"bought\":true,\"price\":0},{\"bought\":false,\"price\":100},{\"bought\":false,\"price\":125},{\"bought\":false,\"price\":150},{\"bought\":false,\"price\":175}]}");

            //currency ***Set back to 0***
            PlayerPrefs.SetInt("Pickles", 0);
            PlayerPrefs.SetInt("weiner1", 1); //regular weiner always 1
            PlayerPrefs.SetInt("weiner2", 0); 
            PlayerPrefs.SetInt("weiner3", 0);
            PlayerPrefs.SetInt("weiner4", 0);
            PlayerPrefs.SetInt("weiner5", 0);
            PlayerPrefs.SetInt("Character", 0);
        }

        Pickles = PlayerPrefs.GetInt("Pickles");
        itemsData = JSONObject.Parse(PlayerPrefs.GetString("Items"));
        Items = new List<ShopItem>();

        for (int i = 0; i < itemsData.GetArray("Items").Length; i++)
        {
            Items.Add(new ShopItem(itemsData.GetArray("Items")[i].Obj.GetBoolean("bought"),
                                    (int)itemsData.GetArray("Items")[i].Obj.GetNumber("price")));

        }

        
    }

    public void BuyItem(int index)
    {
        if (DetermineBought() == 1)
            return;
        else
        {
            if (SubtractPickles(Items[DetermineWeiner()].Price))
            {

                //determining which has been bought and setting playerprefs to say its now bought
                switch (DetermineWeiner())
                {
                    case 1:
                        PlayerPrefs.SetInt("weiner2", 1);
                        break;
                    case 2:
                        PlayerPrefs.SetInt("weiner3", 1);
                        break;
                    case 3:
                        PlayerPrefs.SetInt("weiner4", 1);
                        break;
                    case 4:
                        PlayerPrefs.SetInt("weiner5", 1);
                        break;

                }

                //setting buttons
                Select.SetActive(false);
                Selected.SetActive(true);
                ItemPrice.SetActive(false);
                
            }
            else
                bought = false;
        }
    }

    private bool SubtractPickles(int value)
    {
        if (Pickles - value < 0)
        {
            Debug.Log("Not enough pickles");
            return false;
        }
        Pickles -= value;
        PlayerPrefs.SetInt("Pickles", Pickles);
        UpdatePickles();
        return true;
    }

    public void AddPickles()
    {
        int p = PlayerPrefs.GetInt("Pickles");
        p = p + 5;
        PlayerPrefs.SetInt("Pickles", p);
    }

    public void UpdatePickles()
    {
        pickles.text = PlayerPrefs.GetInt("Pickles", 0).ToString();
    }

    public static List<GameObject> weiner =  new List<GameObject>();

    public static int DetermineWeiner()
    {

        int x = 0;
            for (int i = 0; i < CharacterSelect.characterList.Length; i++)
            {
                
                if (CharacterSelect.characterList[i].activeInHierarchy)
                {

                x = i;
                }
            }
        return x;


        
    }

    public static int DetermineBought()
    {
        for (int i = 0; i < CharacterSelect.characterList.Length; i++)
        {
            switch (DetermineWeiner())
            {
                case 0:
                    return PlayerPrefs.GetInt("weiner1");
                case 1:
                    return PlayerPrefs.GetInt("weiner2");
                case 2:
                    return PlayerPrefs.GetInt("weiner3");
                case 3:
                    return PlayerPrefs.GetInt("weiner4");
                case 4:
                    return PlayerPrefs.GetInt("weiner5");
            }
        }
        return 0;
    }

    public Text pickles;

    void Start()
    {
        pickles.text = PlayerPrefs.GetInt("Pickles", 0).ToString();
    }
    

    public void Change()
    {

        if (DetermineBought() == 1)
        {
            //UpdatePrice(DetermineWeiner());
            if (DetermineWeiner() == PlayerPrefs.GetInt("Character"))
            {
                //Debug.Log("Determine weiner == playerprefs character");
                Select.SetActive(false);
                Selected.SetActive(true);
                ItemPrice.SetActive(false);
            }
            else
            {
                //Debug.Log("Determine weiner != playerprefs character");
                Select.SetActive(true);
                Selected.SetActive(false);
                ItemPrice.SetActive(false);
            }
        }
        else
        {
            //Debug.Log("Item has not been bought Number: " + DetermineWeiner() + " Bool: " + Items[DetermineWeiner()].Bought);
            UpdatePrice(DetermineWeiner());
            ItemPrice.SetActive(true);
            Select.SetActive(false);
            Selected.SetActive(false);
        }
    }

    public void UpdatePrice(int x)
    {
        int y = Items[x].Price;
        //Debug.Log("Price: " + y + "Item: " + DetermineWeiner());
        Price.text = null;
        Price.text += y;
    }
}