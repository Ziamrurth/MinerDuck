using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    public GameObject player;

    InventorySlot[] slots;

    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerMining>().onBackpackChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen)
            {
                GetComponent<Canvas>().enabled = false;
                isOpen = false;
            }
            else
            {
                GetComponent<Canvas>().enabled = true;
                isOpen = true;
            }
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < player.GetComponent<PlayerMining>().backpack.Count)
            {
                slots[i].AddItem(player.GetComponent<PlayerMining>().backpack[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
