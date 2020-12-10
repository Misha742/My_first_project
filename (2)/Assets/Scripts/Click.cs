using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Click : MonoBehaviour
{
    public GameObject selectedObject;
    public GameObject ClickActive;
    private Vector3 small = new Vector3(1,1,0);
    public GameObject Player;
    public PlayerMovement referensePM;


    //bottom

    public Button GrossB;
    public Button WalkB;
    // Start is called before the first frame update
    void Start()
    {
        //Button btn = GrossB.GetComponent<Button>();
		GrossB.onClick.AddListener(ClickGrossing);
        WalkB.onClick.AddListener(ClickGrossing);
        referensePM = Player.GetComponent<PlayerMovement>();
        ClickActive.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            ClickActive.SetActive(false);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0);
            {
                if (hitData && Input.GetMouseButtonDown(1))
                {
                    selectedObject = hitData.transform.gameObject;
                    Debug.Log(worldPosition + "     " + selectedObject);
                    CheckObj();
                }

            }
        }
    }

    void CheckObj()
    {
        if (selectedObject.tag == "Farm" )
        {
            ClickActive.SetActive(true);
            ClickActive.transform.position = Input.mousePosition;
            ClickActive.transform.position += small;
        }
    }
    void ClickGrossing(){
		referensePM.targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);;
        referensePM.walk = true;
        ClickActive.SetActive(false);
	}
}
