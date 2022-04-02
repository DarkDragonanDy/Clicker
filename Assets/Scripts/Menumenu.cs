using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Menumenu : MonoBehaviour
{
    public GameObject MenuObject;

    private int dd;
    // Start is called before the first frame update
    void Start()
    {
        
        dd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            
        {
            if (dd == 0)
            {
                MenuObject.SetActive(true);
                dd = 1;
            }
            else
            {
                MenuObject.SetActive(false);
                dd = 0;
            }
        }
    }
}
