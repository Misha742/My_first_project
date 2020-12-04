using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public GameObject CopyObject;
    // Start is called before the first frame update
    void Start()
    {
        CreateChunk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateChunk()
    {
        for (int j = -8;  j < 8; j++)
        {
            for (int i = -8; i < 8; i++)
            {
                GameObject a = Instantiate(CopyObject, transform) as GameObject;
                a.transform.position = new Vector2(i, j);
        
            }
        }
    }
}
