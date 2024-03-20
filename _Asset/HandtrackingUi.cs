using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandtrackingUi : MonoBehaviour
{
    // Start is called before the first frame update

        public OVRHand hand;
        public OVRInputModule inputModule;

    private void Start()
    {
        inputModule.rayTransform = hand.PointerPose;
    }
       


}
