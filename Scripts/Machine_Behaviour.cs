using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using Unity.VisualScripting;
using UnityEngine;


public enum MachineStates
{
    Onshelf, Floating, Onground
}
public class Machine_Behaviour : MonoBehaviour
{
    public GameObject gamemangaer;
    public MachineStates state;
    public bool previousstate = true;
    public Material blueMaterial;
    public Material redMaterial;
    public Material yellowMaterial;
    public GameObject rotateObject;
    public GameObject moveObject;
    public GrowTree[] growTrees;
    public GameObject[] growTreesObjects;
    public bool alreadyCalled = false;
    public Grabbable grabbable;
    public PhysicsGrabbable physicsGrabbable;
    public GameObject InfoBox;
   

    public void Start()
    {
        state = MachineStates.Onshelf;
    }

    public void SetMachineState(MachineStates s)
    {
        state = s;
    }

    public MachineStates GetMachineStates()
    {
        return state;
    }

    public void Update()
    {
        switch (state)
        {
            case MachineStates.Onshelf:

                InfoBox.SetActive(false);

              
                //gamemangaer.GetComponent<Print>().settext("shelf   "+ moveObject.GetComponent<HandGrabInteractable>().isActiveAndEnabled+"   "+ rotateObject.GetComponent<HandGrabInteractable>().isActiveAndEnabled);
                //cubeRenderer[i].material = yellowMaterial;
                moveObject.GetComponent<HandGrabInteractable>().enabled = false;
                rotateObject.GetComponent<HandGrabInteractable>().enabled = false;
                alreadyCalled = false;

                //disable grabs
                grabbable.enabled = false;
                physicsGrabbable.enabled = false;

                break;

            case MachineStates.Floating:

                InfoBox.SetActive(true);

                
                //cubeRenderer[i].material = redMaterial;
                //gamemangaer.GetComponent<Print>().settext("float   " + moveObject.GetComponent<HandGrabInteractable>().isActiveAndEnabled + "   " + rotateObject.GetComponent<HandGrabInteractable>().isActiveAndEnabled);
                transform.Rotate(new Vector3(0, 1, 0));
                moveObject.GetComponent<HandGrabInteractable>().enabled = false;
                rotateObject.GetComponent<HandGrabInteractable>().enabled = true;
                alreadyCalled = false;

                //disable grabs
                grabbable.enabled = false;
                physicsGrabbable.enabled = false;
                break;

            case MachineStates.Onground:

                InfoBox.SetActive(true);

                //gamemangaer.GetComponent<Print>().settext("ground   "+ moveObject.GetComponent<HandGrabInteractable>().isActiveAndEnabled+"   "+ rotateObject.GetComponent<HandGrabInteractable>().isActiveAndEnabled);
                //cubeRenderer[i].material = yellowMaterial;
                moveObject.GetComponent<HandGrabInteractable>().enabled = true;
                rotateObject.GetComponent<HandGrabInteractable>().enabled = true;
                if (!alreadyCalled)
                {
                   // gamemangaer.GetComponent<AddGravity>().addGravityMachine(gameObject);
                    //StartCoroutine(ExampleCoroutine(gameObject));
                    for (int i = 0; i < growTrees.Length; i++)
                    {
                        growTreesObjects[i].gameObject.SetActive(true);
                        growTrees[i].gameObject.SetActive(true);
                        //gamemangaer.GetComponent<Print>().settext(growTreesObjects[i].gameObject.name+" grow this tree "+ growTreesObjects[i].gameObject.active);
                        growTrees[i].startGrowing();
                        
                    }
                    alreadyCalled = true;
                }

                //enable grabs
                grabbable.enabled = true;
                physicsGrabbable.enabled = true;
                break;
        }

        IEnumerator ExampleCoroutine(GameObject gameObject)
        {
            //yield on a new YieldInstruction that waits for 1 seconds.
            yield return new WaitForSeconds(1f);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;

        }

    }
}
