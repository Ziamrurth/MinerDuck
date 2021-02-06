﻿using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    
    public Image icon;
    public Button removeButton;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMining>().RemoveItem(item);
    }
}
