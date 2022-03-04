using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characterssss : MonoBehaviour
{
    private bool state;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        state = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(state==true)
            {
                Target.SetActive(false);
                state = false;
            }
            else
            {
                Target.SetActive(true);
                state = true;
            }
        }

       
    }
}
