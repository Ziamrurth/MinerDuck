using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoaderScreen : MonoBehaviour {
    public GameObject spawnmanager;
    public GameObject player;

    public TextMeshProUGUI caveLevel;
    public TextMeshProUGUI copperScore;
    public TextMeshProUGUI ironScore;
    public TextMeshProUGUI goldScore;
    public TextMeshProUGUI diamondScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        caveLevel.text = spawnmanager.GetComponent<SpawnManager>().caveLevel.ToString();
    }

    public void ShowScore()
    {
        int copperCount = player.GetComponent<PlayerMining>().backpack.FindAll(item => item.name == "Copper").Count;
        if(copperCount != 0)
        {
            copperScore.text = (copperCount * player.GetComponent<PlayerMining>().backpack.Find(item => item.name == "Copper").value).ToString();
        }
        else
        {
            copperScore.text = "0";
        }

        int ironCount = player.GetComponent<PlayerMining>().backpack.FindAll(item => item.name == "Iron").Count;
        if (ironCount != 0)
        {
            ironScore.text = (ironCount * player.GetComponent<PlayerMining>().backpack.Find(item => item.name == "Iron").value).ToString();
        }
        else
        {
            ironScore.text = "0";
        }

        int goldCount = player.GetComponent<PlayerMining>().backpack.FindAll(item => item.name == "Gold").Count;
        if (goldCount != 0)
        {

            goldScore.text = (goldCount * player.GetComponent<PlayerMining>().backpack.Find(item => item.name == "Gold").value).ToString();
        }
        else
        {
            goldScore.text = "0";
        }

        int diamondCount = player.GetComponent<PlayerMining>().backpack.FindAll(item => item.name == "Diamond").Count;
        if (diamondCount != 0)
        {
            diamondScore.text = (diamondCount * player.GetComponent<PlayerMining>().backpack.Find(item => item.name == "Diamond").value).ToString();
        }
        else
        {
            diamondScore.text = "0";
        }
    }
}
