using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    int menuNum;
    int currStoreSlot;
    public GameObject[] menus;
    public GameObject storePanel;
    GameObject selectedStoreItem;
    Toggle storeItemToggle;
    public GameManager gMan;

    // Use this for initialization
    void Start()
    {
        menuNum = 0;
        gMan = GameManager.instance;

        if(storePanel != null)
        {
            int itemCount = storePanel.transform.childCount;

            GameObject[] storeItems = new GameObject[itemCount];

            for (int i = 0; i < itemCount; i++)
            {
                storeItems[i] = storePanel.transform.GetChild(i).gameObject;
            }

            //Re-Create the list of store items
            gMan.StoreItems = storeItems;

            //Check if a list of purchased items needs to be created
            if(gMan.PurchasedItems == null)
            {
                gMan.PurchasedItems = new bool[itemCount];
            }
            //Otherwise update the shop
            else
            {
                for(int i = 0; i < itemCount; i++)
                {
                    storeItems[i].GetComponent<Toggle>().interactable = !gMan.PurchasedItems[i];
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    /// <summary>
    /// Switches the current scene to the chosen one, by string
    /// </summary>
    /// <param name="sceneName"></param>
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Switches the currently active menu to the newly choesen menu
    /// </summary>
    /// <param name="menuPosition"></param>
    public void SwitchMenu(int menuPosition)
    {
        if(menuPosition >= 0 && menuPosition < menus.Length)
        {
            menus[menuNum].SetActive(false);
            menus[menuPosition].SetActive(true);
            menuNum = menuPosition;
        }
    }

    /// <summary>
    /// Changes the selected store item
    /// </summary>
    /// <param name="arrayPos"></param>
    public void SelectStoreItem(int arrayPos)
    {
        GameObject item = gMan.StoreItems[arrayPos];
        currStoreSlot = arrayPos;
        //First Item
        if (selectedStoreItem == null)
        {
            selectedStoreItem = item;
            storeItemToggle = item.GetComponent<Toggle>();
            selectedStoreItem.GetComponent<Image>().color = new Color(0, 0, 255);
        }
        //Same Item
        else if (selectedStoreItem == item)
        {
            if (storeItemToggle.isOn)
            {
                selectedStoreItem.GetComponent<Image>().color = new Color(0, 0, 255);
            }
            else
            {
                selectedStoreItem.GetComponent<Image>().color = new Color(255, 255, 255);
            }
        }
        //New Item
        else
        {
            if (storeItemToggle.isOn)
            {
                selectedStoreItem.GetComponent<Image>().color = new Color(255, 255, 255);
            }

            selectedStoreItem = item;
            storeItemToggle = item.GetComponent<Toggle>();
            selectedStoreItem.GetComponent<Image>().color = new Color(0, 0, 255);
        }
    }

    /// <summary>
    /// Purchases the item and disables the current item
    /// </summary>
    /// <param name="cost"></param>
    public void PurchaseItem(int cost)
    {
        if(storeItemToggle == null || storeItemToggle.isOn == false)
        {
            Debug.Log("No item selected");
            return;
        }
        if (gMan.Coins >= cost)
        {
            gMan.Coins -= cost;
            storeItemToggle.isOn = false;

            storeItemToggle.interactable = false;
            gMan.PurchasedItems[currStoreSlot] = true;
        }
        else
        {
            Debug.Log("Not enough coins to purchase");
        }

    }
}
