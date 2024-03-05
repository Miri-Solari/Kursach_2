using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject gameUi;

    private bool _isMenuOpen = false;
    private bool _isInventoryOpen = false;
    private bool _isGameUiOpen = true;

    private void Update()
    {

        if (Input.GetKey(ControlButton.MenuOpen) && menu != null)
        {
            MenuControl();
        }
        

        if (Input.GetKey(ControlButton.InventoryOpen) && inventory != null)
        {
            InventoryControl();
        }

        
    }




    private void MenuControl()
    {
        if (_isMenuOpen)
        {
            menu.SetActive(false);
            
            _isMenuOpen = false;
        }
        else
        {
            menu.SetActive(true);
            _isMenuOpen = true;
        }
        GameUIControl();
    }

    private void InventoryControl()
    {
        if (!_isInventoryOpen)
        {
            _isInventoryOpen = true;
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);

            _isInventoryOpen = false;
        }
        GameUIControl();
    }

    private void GameUIControl()
    {
        if (!_isGameUiOpen)
        {
            gameUi.SetActive(true);
            _isGameUiOpen = true;
        }
        else
        {
            gameUi.SetActive(false);
            _isGameUiOpen = false;
        }
    }
}
