using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndCloseList : MonoBehaviour
{

    public static OpenAndCloseList instance;
    public List<GameObject> openDoors = new List<GameObject>();
    public List<GameObject> closedDoors = new List<GameObject>();
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
   
}
