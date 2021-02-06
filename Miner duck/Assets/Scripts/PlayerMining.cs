using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMining : MonoBehaviour {
    public float startTimeBtwHit;
    public float hitRadius;
    public int pickaxeDurability = 10;

    public GameObject pickMountPoint;
    public GameObject currentPick;

    public delegate void OnBackpackChanged();
    public OnBackpackChanged onBackpackChangedCallback;

    public GameObject endButton;
    public GameObject gameStartManager;

    public Transform hitPos;
    public LayerMask whatIsMineVein;
    public SpawnManager spawnManager;

    private float timeBtwHit;
    private int backpackSize = 6;
    public List<Item> backpack = new List<Item>();

    // Update is called once per frame
    void Update()
    {
        // Go down to next cave level
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (pickaxeDurability > 0)
            {
                pickaxeDurability--;
                if(pickaxeDurability == 0)
                {
                    endButton.SetActive(true);
                }
                //spawnManager.NextLevel();
                gameStartManager.GetComponent<GameStartManager>().LoadNewLevel();
            }
        }

        // Mine ore when player hit space
        if (timeBtwHit <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Collider[] mineVeinsToMine = Physics.OverlapSphere(hitPos.position, hitRadius, whatIsMineVein);
                if (mineVeinsToMine.Length != 0)
                {
                    if (pickaxeDurability > 0)
                    {
                        mineVeinsToMine[0].GetComponent<MineVein>().Mined();
                        pickaxeDurability--;
                        if (pickaxeDurability == 0)
                        {
                            endButton.SetActive(true);
                        }
                    }
                }
            }

            timeBtwHit = startTimeBtwHit;
        }
        else
        {
            timeBtwHit -= Time.deltaTime;
        }
    }

    // Check collision with ore and add it to backpack if it not full
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ore")
        {
            if (!IsBackpackFull())
            {
                backpack.Add(collider.gameObject.GetComponent<Ore>().item);

                if (onBackpackChangedCallback != null)
                    onBackpackChangedCallback.Invoke();

                if (IsBackpackFull())
                {
                    endButton.SetActive(true);
                }

                GameObject.Destroy(collider.gameObject);
            }
        }
    }

    // Remove item from backpack
    public void RemoveItem(Item item)
    {
        backpack.Remove(item);

        if (onBackpackChangedCallback != null)
            onBackpackChangedCallback.Invoke();

        endButton.SetActive(false);
    }

    public void ResetBackpack()
    {
        backpack.Clear();

        if (onBackpackChangedCallback != null)
            onBackpackChangedCallback.Invoke();
    }

    // Check is backback full
    private bool IsBackpackFull()
    {
        if (backpack.Count >= backpackSize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Change player's pick
    public void ChangePick(Pickaxe pick)
    {
        if (currentPick != null)
        {
            GameObject.Destroy(currentPick);
        }

        currentPick = Instantiate(pick.pickPrefab, pickMountPoint.transform);
        pickaxeDurability = pick.durability;
    }

    // End of the run
    public void EndRun()
    {
        int moneyEarned = 0;
        int currentMoney = PlayerPrefs.GetInt("PlayerMoney", 0);

        foreach (var item in backpack)
        {
            moneyEarned += item.value;
        }
        
        PlayerPrefs.SetInt("PlayerMoney", currentMoney + moneyEarned);

        gameStartManager.GetComponent<GameStartManager>().EndRun();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitPos.position, hitRadius);
    }
}
