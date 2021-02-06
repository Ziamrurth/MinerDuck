using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineVein : MonoBehaviour
{
    public GameObject orePrefab;

    public int oreVeinIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mined()
    {
        Instantiate(orePrefab, transform.position + new Vector3(0,1,0), orePrefab.transform.rotation);

        Object.Destroy(gameObject);
    }
}
