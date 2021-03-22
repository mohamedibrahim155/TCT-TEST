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
        
        if (isOpened)
        {
            OpenAndCloseList.instance.openDoors.Add(this.gameObject);
           upPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 1, transform.localPosition.z);
        }
        else
        {
            isClosed = true;
            OpenAndCloseList.instance.closedDoors.Add(this.gameObject);
            downPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpened)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, upPosition,0.2f);
        }
      
        if (isClosed)
        {
            Debug.Log(transform.localPosition);

             transform.localPosition = Vector3.Lerp(transform.localPosition, downPos, 0.2f);
        }
        
        
        
    }
}
