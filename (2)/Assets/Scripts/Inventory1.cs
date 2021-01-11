using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory1 : MonoBehaviour
{
    public List<string> id = new List<string>(); // name of objects
    public List<int> numOfObj = new List<int>(); // number of objects


    public int numOfItems = 1; // number of items
    private int maxOfWeight = 5000;
    public int weight = 0; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PutOut()
    {
        
    }
    
    public void PutIn(string name, int value)
    {
        if ((weight + value) > maxOfWeight) //check for max weight
        {

        }
        else // if enough of weight than check for name in item
        {
            int number = 0;
            number = checkId(name);
            if (number >= 0) // if we have than change only value 
            {
                numOfObj[number] += value;
                weight += value;
            }
            else // if we haven't in inventory than add
            {
                id.Add(name);
                numOfObj.Add(value);
                weight += value;
            }
        }
    }

    private int checkId(string name) // if we have item in inventory then send true
    {
        for (int i = 0; i < numOfObj.Count; i++)
        {
            if (id[i] == name)
            {
                return i;
            }
        }
        return -2;
    }
}
