using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoMovement : MonoBehaviour
{
    public Transform MachineRef;
    public Transform info;



    // Update is called once per frame
    void Update()
    {
        info.SetPositionAndRotation(MachineRef.position, Quaternion.identity);
    }
}
