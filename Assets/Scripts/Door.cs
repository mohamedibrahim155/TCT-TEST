using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   public bool isOpened,isClosed;
  public  Vector3 upPosition,downPos;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
           upPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 1, transform.localPosition.z);
            downPos = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
        if (isOpened)
        {
            OpenAndCloseList.instance.openDoors.Add(this.gameObject);
        }
        else
        {
            isClosed = true;
            OpenAndCloseList.instance.closedDoors.Add(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpened)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, upPosition,0.2f);
        }
        else
        {
             transform.localPosition = Vector3.Lerp(transform.localPosition, downPos, 0.2f);

        }
      
        
        
        
    }
}
