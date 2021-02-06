using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public GameObject beginUI;
    public GameObject loaderScreen;
    public GameObject caveLevelScreen;
    public GameObject finishScreen;
    public GameObject inventoryUI;
    public GameObject gameUI;
    public GameObject player;
    public GameObject beginCamera;
    public GameObject mainCamera;
    public GameObject endButton;
    public GameObject spawnManager;

    public float loadScreenLength = 1.0f;

    private Quaternion playerStartRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNewLevel()
    {
        StartCoroutine(LevelLoader());
    }

    public void StartGame()
    {
        int currentMoney = PlayerPrefs.GetInt("PlayerMoney", 0);
        PlayerPrefs.SetInt("PlayerMoney", currentMoney - beginUI.GetComponent<BeginUI>().picks[beginUI.GetComponent<BeginUI>().pickIndex].price);
        StartCoroutine(Starter());
    }

    IEnumerator LevelLoader()
    {
        beginUI.SetActive(false);
        gameUI.SetActive(false);
        caveLevelScreen.SetActive(true);
        player.GetComponent<PlayerControllerTopDown>().enabled = false;
        player.GetComponent<PlayerMining>().enabled = false;
        inventoryUI.SetActive(false);
        spawnManager.GetComponent<SpawnManager>().NextLevel();

        yield return new WaitForSeconds(loadScreenLength);

        player.GetComponent<PlayerControllerTopDown>().enabled = true;
        player.GetComponent<PlayerMining>().enabled = true;
        inventoryUI.SetActive(true);
        caveLevelScreen.SetActive(false);
        gameUI.SetActive(true);
    }

    IEnumerator Starter()
    {
        beginUI.SetActive(false);
        caveLevelScreen.SetActive(true);
        player.transform.position = new Vector3(0, 1, 0);
        playerStartRotation = player.transform.rotation;
        player.transform.rotation = Quaternion.identity;
        mainCamera.SetActive(true);
        beginCamera.SetActive(false);

        yield return new WaitForSeconds(loadScreenLength);

        player.GetComponent<PlayerControllerTopDown>().enabled = true;
        player.GetComponent<PlayerMining>().enabled = true;
        inventoryUI.SetActive(true);
        caveLevelScreen.SetActive(false);
        gameUI.SetActive(true);
    }

    public void EndRun()
    {
        endButton.SetActive(false);
        spawnManager.GetComponent<SpawnManager>().ResetGame();
        beginUI.GetComponent<BeginUI>().SetPick();
        gameUI.SetActive(false);
        finishScreen.SetActive(true);
        loaderScreen.GetComponent<LoaderScreen>().ShowScore();
        player.GetComponent<PlayerControllerTopDown>().enabled = false;
        player.GetComponent<PlayerMining>().enabled = false;
        player.GetComponent<PlayerMining>().ResetBackpack();
        inventoryUI.SetActive(false);
    }

    public void ReturnToSelectScreen()
    {
        finishScreen.SetActive(false);
        beginUI.SetActive(true);
        player.transform.position = new Vector3(35.23f, 1, -55.22f);
        player.transform.rotation = playerStartRotation;
        beginCamera.SetActive(true);
        mainCamera.SetActive(false);
    }
}
