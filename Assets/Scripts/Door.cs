using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpened;
    public bool isClosed;
    public bool staticObjects;
    public  Vector3 upPosition,downPos;
    public Color closedColor,opendColor;
    Renderer myrend;

  
    // Start is called before the first frame update
    void Start()
    {
       
        myrend = GetComponent<Renderer>();
        closedColor = Color.red;
        opendColor = Color.green;

   
        //defining the move position for the swich between up and down
       upPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 1, transform.localPosition.z);
       downPos = new Vector3(0, transform.localPosition.y, transform.localPosition.z);

        // adding them to the list;
        if (isOpened && !staticObjects) 
        {
            OpenAndCloseList.instance.openDoors.Add(this.gameObject);
        }
        else
        {
            if (!staticObjects)
            {
              isClosed = true;
              OpenAndCloseList.instance.closedDoors.Add(this.gameObject);

            }
        }
    }

 
    void Update()
    {
        if (isOpened && !staticObjects) 
        {
           //opened door
            transform.localPosition = Vector3.Lerp(transform.localPosition, upPosition,0.2f);
            myrend.material.color = opendColor;
           
        }
        else
        {
            //closed door 
            if (!staticObjects)
            {
              transform.localPosition = Vector3.Lerp(transform.localPosition, downPos, 0.2f);
              myrend.material.color = closedColor;
            }
               // StopCoroutine(waitingtime);
        }
       
 
    }
   
}
