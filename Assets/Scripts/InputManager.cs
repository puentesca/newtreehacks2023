using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject testObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.0f && !testObj.activeInHierarchy)
        {
            testObj.SetActive(true);
        } else if (testObj.activeInHierarchy)
        {
            testObj.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }
}