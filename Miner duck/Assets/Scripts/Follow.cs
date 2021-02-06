using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // Public variables
    public GameObject player;

    // Private variables
    private Vector3 offcet = new Vector3(0, 9, -3);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Camera offcet
        transform.position = player.transform.position + offcet;
    }
}
