using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    int menuNum;
    public GameObject[] menus;
    public GameManager gMan;

	// Use this for initialization
	void Start ()
    {
        menuNum = 0;
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

    public void PurchaseItem(int cost)
    {
        
    }
}
