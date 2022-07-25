using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Menumenu : MonoBehaviour
{
    public GameObject MenuObject;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            MenuObject.SetActive(!MenuObject.active);
        
    }
}
