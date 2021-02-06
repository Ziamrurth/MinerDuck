using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnmanager;

    public Text pickaxeDurability;
    public Text caveLevel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pickaxeDurability.text = player.GetComponent<PlayerMining>().pickaxeDurability.ToString();
        caveLevel.text = spawnmanager.GetComponent<SpawnManager>().caveLevel.ToString();
    }
}
