using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class AddGravity : MonoBehaviour
{
    public GameObject gamemangaer;
    [SerializeField]
    private GameObject[] AllObjects;
    Machine_Behaviour machinebehaviour;
    public AudioSource throwonground;
    public SelectMachine selectMachine;

    public void addGravity()
    {
        AllObjects = GameObject.FindGameObjectsWithTag("Machines");

        for (int i = 0; i < AllObjects.Length; i++)
        {
            if (AllObjects[i].GetComponent<Machine_Behaviour>().GetMachineStates() == MachineStates.Floating)
            {
                machinebehaviour = AllObjects[i].GetComponent<Machine_Behaviour>();

                machinebehaviour.SetMachineState(MachineStates.Onground);
               // gamemangaer.GetComponent<Print>().settext("heyyyyyyyyyyy");

                // gamemangaer.GetComponent<Print>().settext(AllObjects[i].name);
                if (AllObjects[i].name == "Machine1")
                {
                 //   gamemangaer.GetComponent<Print>().settext("heyyyyyyyyyyy11111");
                    GameObject.Find("InfoiBox1").transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                }
                if (AllObjects[i].name == "Machine2")
                {
                  //  gamemangaer.GetComponent<Print>().settext("heyyyyyyyyyyy11111");
                    GameObject.Find("InfoiBox2").transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                }
                if (AllObjects[i].name == "Machine3")
                {
                   // gamemangaer.GetComponent<Print>().settext("heyyyyyyyyyyy11111");
                    GameObject.Find("InfoiBox3").transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                }
                Rigidbody CurrentRigidBody = AllObjects[i].GetComponent<Rigidbody>();
                AllObjects[i].transform.localScale = new Vector3(3.75f, 3.75f, 3.75f);
                CurrentRigidBody.isKinematic = false;
                CurrentRigidBody.mass = 5;
                CurrentRigidBody.useGravity = true;

                selectMachine.RemoveObjectFromInFloatMachines(AllObjects[i]);

                //gameObject.transform.SetPositionAndRotation(gameObject.transform.position, new Quaternion(0, 1, 0, 0));
                StartCoroutine(ExampleCoroutine(AllObjects[i].gameObject));
             //   gamemangaer.GetComponent<Print>().settext("heyyyyyyyyyyy11111"+ CurrentRigidBody.isKinematic + CurrentRigidBody.useGravity);

                // gamemangaer.GetComponent<Print>().settext(AllObjects[i].transform.position + "----"+AllObjects[i].GetComponent<Rigidbody>().mass+"--"+ AllObjects[i].GetComponent<Rigidbody>().useGravity + AllObjects[i].GetComponent<Rigidbody>().isKinematic);

            }
            //if (AllObjects[i].GetComponent<Machine_Behaviour>().state == MachineStates.Onground)
               // gamemangaer.GetComponent<Print>().settext(AllObjects[i].transform.position + "----" + AllObjects[i].name + "--" + AllObjects[i].active);
        }
    }

    public void addGravityMachine(GameObject machine)
    {
        Rigidbody CurrentRigidBody = machine.GetComponent<Rigidbody>();
        CurrentRigidBody.mass = 5;
        CurrentRigidBody.useGravity = true;
        CurrentRigidBody.isKinematic = false;
        //gamemangaer.GetComponent<Print>().settext("gravityyyyy aginnnnnnn");
    }

    public void removeGravityMachine(GameObject machine)
    {
        Rigidbody CurrentRigidBody = machine.GetComponent<Rigidbody>();
        CurrentRigidBody.mass = 5;
        CurrentRigidBody.useGravity = false;
        CurrentRigidBody.isKinematic = true;
    }

    IEnumerator ExampleCoroutine(GameObject gameObject)
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(0.25f);
        gameObject.transform.SetPositionAndRotation(gameObject.transform.position, new Quaternion(0, 1, 0, 0));
        //yield return new WaitForSeconds(0.5f);
        throwonground.Play();
    }

}
