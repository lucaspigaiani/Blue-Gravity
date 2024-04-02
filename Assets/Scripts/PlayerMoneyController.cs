using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMoneyController : MonoBehaviour
{
    public int playerMoney = 100; // Initial amount of player money
    public TextMeshProUGUI moneyText; // UI Text element to display player money

    private void UpdateMoneyDisplay()
    {
        moneyText.text = playerMoney.ToString(); // Update the displayed money amount
    }

    public void BuyItem(Skin skin)
    {
        playerMoney -= skin.value; // Subtract the item price from player money
        UpdateMoneyDisplay(); // Update the displayed money amount
    }

    public void SellItem(Skin skin)
    {
        playerMoney += skin.value; // Add the item price to player money
        UpdateMoneyDisplay(); // Update the displayed money amount
    }

    public bool CheckMoney(Skin item)
    {
        if (playerMoney >= item.value)
        {
            return true;
        }
        else
        {
            Debug.Log("Insufficient funds!"); // Output a message if the player doesn't have enough money
            return false;
        }
    }
}
