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
    public Text coinText;
    public GameObject storePanel;
    GameObject[] storeItems;
    public GameObject sockPanel;
    GameObject[] sockSelectionItems;
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

            //Create the list of store items
            storeItems = new GameObject[itemCount];

            for (int i = 0; i < itemCount; i++)
            {
                storeItems[i] = storePanel.transform.GetChild(i).gameObject;
            }

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
        if(sockPanel != null)
        {
            int itemCount = sockPanel.transform.childCount;
            sockSelectionItems = new GameObject[itemCount];

            for (int i = 0; i < itemCount; i++)
            {
                sockSelectionItems[i] = sockPanel.transform.GetChild(i).gameObject;
                sockSelectionItems[i].GetComponent<Toggle>().interactable = gMan.PurchasedItems[i];
            }

            if(gMan.CurrentSock != -1)
            {
                sockSelectionItems[gMan.CurrentSock].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
        if (coinText != null)
        {
            coinText.text = "Coins: " + gMan.Coins;
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
        GameObject item = storeItems[arrayPos];
        currStoreSlot = arrayPos;
        //First Item
        if (selectedStoreItem == null)
        {
            selectedStoreItem = item;
            storeItemToggle = item.GetComponent<Toggle>();
            if (selectedStoreItem.transform.childCount > 1)
            {
                selectedStoreItem.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                selectedStoreItem.GetComponent<Image>().color = new Color(0, 0, 1);
            }
        }
        //Same Item
        else if (selectedStoreItem == item)
        {
            if (storeItemToggle.isOn)
            {
                if (selectedStoreItem.transform.childCount > 1)
                {
                    selectedStoreItem.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                else
                {
                    selectedStoreItem.GetComponent<Image>().color = new Color(0, 0, 1);
                }
            }
            else
            {
                if (selectedStoreItem.transform.childCount > 1)
                {
                    selectedStoreItem.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, .5f);
                }
                else
                {
                    selectedStoreItem.GetComponent<Image>().color = new Color(1, 1, 1);
                }
            }
        }
        //New Item
        else
        {
            if (storeItemToggle.isOn)
            {
                if (selectedStoreItem.transform.childCount > 1)
                {
                    selectedStoreItem.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, .5f);
                }
                else
                {
                    selectedStoreItem.GetComponent<Image>().color = new Color(1, 1, 1);
                }
            }

            selectedStoreItem = item;
            storeItemToggle = item.GetComponent<Toggle>();

            if (selectedStoreItem.transform.childCount > 1)
            {
                selectedStoreItem.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);

            }
            else
            {
                selectedStoreItem.GetComponent<Image>().color = new Color(0, 0, 1);
            }
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
            coinText.text = "Coins: " + gMan.Coins;
            storeItemToggle.isOn = false;

            storeItemToggle.interactable = false;
            sockSelectionItems[currStoreSlot].GetComponent<Toggle>().interactable = true;
            gMan.PurchasedItems[currStoreSlot] = true;
        }
        else
        {
            Debug.Log("Not enough coins to purchase");
        }

    }

    /// <summary>
    /// Selects an unlocked sock to use for the player
    /// </summary>
    /// <param name="pos"></param>
    public void ChooseSock(int pos)
    {
        if(gMan.PurchasedItems[pos] == true)
        {
            //If some sock is chosen
            if(gMan.CurrentSock != -1)
            {
                //If not current sock, swap
                if (gMan.CurrentSock != pos)
                {
                    if (sockSelectionItems[gMan.CurrentSock].transform.childCount != 0)
                    {
                        sockSelectionItems[gMan.CurrentSock].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, .5f);

                    }
                    else
                    {
                        sockSelectionItems[gMan.CurrentSock].GetComponent<Image>().color = new Color(1, 1, 1);
                    }
                }
                //Else, deselect
                else
                {
                    if (sockSelectionItems[pos].transform.childCount != 0)
                    {
                        sockSelectionItems[pos].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, .5f);

                    }
                    else
                    {
                        sockSelectionItems[pos].GetComponent<Image>().color = new Color(1, 1, 1);
                    }

                    gMan.CurrentSock = -1;

                    return;
                }
            }

            //Select current sock
            gMan.CurrentSock = pos;

            if (sockSelectionItems[pos].transform.childCount != 0)
            {
                sockSelectionItems[pos].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);

            }
            else
            {
                sockSelectionItems[pos].GetComponent<Image>().color = new Color(0, 0, 1);
            }
        }
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
