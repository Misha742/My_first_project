using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasForPlayer : MonoBehaviour
{
    public bool tPlayer = true;
    
    public GameObject ant;
    public Farm FarmText;
    public Text NameThisObjectText;
    public Text LevelText;
    //public Text NumberOfEatText;
    public Text StorageText; //, Level, NumberOfEat, Storage, Activity;
    // Start is called before the first frame update
    void Start()
    {
        //Level = GetComponent<Level>();     //--
        //NumberOfEat = GetComponent<NumberOfEat>();
        //Storage = GetComponent<Storage>();      //--
        //Activity = GetComponent<Activity>();    //--

        
    }

    // Update is called once per frame
    void Update()
    {  

       //NumberOfEatText.text = "NumberOfFood: " + FarmText.numOfFood;
       if (tPlayer) ftPlayer();
      
    }

    void ftPlayer()
    {
        NameThisObjectText.text = ant.name.ToString();
        LevelText.text = "Level: " + FarmText.level;
        
    }
}
