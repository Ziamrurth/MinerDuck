using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginUI : MonoBehaviour
{
    public TextMeshProUGUI pickDurability;
    public TextMeshProUGUI pickPrice;
    public TextMeshProUGUI playerMoney;
    public Button btnStart;

    public GameObject player;
    
    public Pickaxe[] picks;

    public int pickIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        int currentMoney = PlayerPrefs.GetInt("PlayerMoney", 0);
        if(currentMoney == 0)
        {
            PlayerPrefs.SetInt("PlayerMoney", 150);
        }
        playerMoney.text = PlayerPrefs.GetInt("PlayerMoney", 0).ToString();
        SetPick();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        if(pickIndex < picks.Length-1)
        {
            pickIndex++;
            SetPick();
        }
    }

    public void Prev()
    {
        if (pickIndex > 0)
        {
            pickIndex--;
            SetPick();
        }
    }

    public void SetPick()
    {
        pickPrice.text = picks[pickIndex].price.ToString();
        pickDurability.text = picks[pickIndex].durability.ToString();

        if(picks[pickIndex].price > PlayerPrefs.GetInt("PlayerMoney", 0))
        {
            btnStart.interactable = false;
        }
        else
        {
            btnStart.interactable = true;
        }

        player.GetComponent<PlayerMining>().ChangePick(picks[pickIndex]);
        playerMoney.text = PlayerPrefs.GetInt("PlayerMoney", 0).ToString();
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
