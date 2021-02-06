using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] oreVeinPrefabs;
    public LayerMask mineVeinlayer;

    public int caveLevel = 1;

    private float spawnRange = 12.0f;
    private int veinsQuantity = 10;

    private float colisionCheckRadius = 0.9f;
    private int collisionCheckIterations = 500;
    private int chanceToUpgradeVein = 30;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetGame()
    {
        caveLevel = 1;
        veinsQuantity = 10;
        ClearLevel();
        SpawnNewLevel();
    }

    // Next level cave
    public void NextLevel()
    {
        ClearLevel();

        caveLevel++;
        veinsQuantity += (int)(caveLevel * Random.Range(0.1f, 0.5f));

        SpawnNewLevel();
    }

    // Place random oreVein in random position
    private void SpawnNewLevel()
    {
        for (int i = 0; i < veinsQuantity; i++)
        {
            // Pick copper as default and roll next veins
            int oreVeinIndex = 0;
            for (int _oreVeinIndex = 0; _oreVeinIndex < oreVeinPrefabs.Length; _oreVeinIndex++)
            {
                int rnd = Random.Range(0, 100);
                if (rnd < chanceToUpgradeVein)
                {
                    oreVeinIndex = _oreVeinIndex;
                }
                else break;
            }

            float positionX = Random.Range(-spawnRange, spawnRange);
            float positionZ = Random.Range(-spawnRange, spawnRange);

            // Check for collision before instantiate
            for (int j = 0; j < collisionCheckIterations; j++)
            {
                Collider[] anyObject = Physics.OverlapSphere(new Vector3(positionX, 1, positionZ), colisionCheckRadius);

                if (anyObject.Length == 0)
                {
                    Instantiate(oreVeinPrefabs[oreVeinIndex], new Vector3(positionX, 0, positionZ), Quaternion.Euler(0, Random.Range(0.0f, 360.0f), 0));
                    break;
                }
            }

            //Instantiate(oreVeinPrefabs[oreVeinIndex], new Vector3(positionX, 1, positionZ), oreVeinPrefabs[oreVeinIndex].transform.rotation);
        }
    }

    // Delet all mine veins from level
    private void ClearLevel()
    {
        // Delete mine veins
        var mineVeins = GameObject.FindGameObjectsWithTag("MineVein");
        foreach (var mineVein in mineVeins)
        {
            Object.Destroy(mineVein);
        }

        // Delete ore
        var oreList = GameObject.FindGameObjectsWithTag("Ore");
        foreach (var ore in oreList)
        {
            Object.Destroy(ore);

        }
    }

}
