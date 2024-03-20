using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectMachine : MonoBehaviour
{
    public GameObject[] Machines;
    public GameObject gameManager;

    public List<GameObject> InFloatMachines = new List<GameObject>();
    public List<GameObject> OnGroundMachines = new List<GameObject>();
    public Dictionary<GameObject, Vector3> dict = new Dictionary<GameObject, Vector3>();
    public GameObject[] growingtrees;
    private Vector3 machine1pos = new Vector3(1f,1.5f,5f);
    private Vector3 machine2pos = new Vector3(0f, 1.5f, 5f);
    private Vector3 machine3pos = new Vector3(-1f, 1.5f, 5f);
    //public GameObject maximize;
    //public GameObject minimize;
    public int MaxCount = 1;
    Machine_Behaviour machinebehaviour;
    public AudioSource wooosh;

    public void SelectMachineToShow(string objname)
    {
        GameObject ObjecToInstantiate;
        GameObject InfoiBox;
        Debug.Log(GetGameObject(objname));
        
        if (GetGameObject(objname)!=null)
        {
            ObjecToInstantiate = GetGameObject(objname);
            InfoiBox = GameObject.Find("InfoiBox1");

            if (ObjecToInstantiate.name == "Machine1")
            {
                InfoiBox = GameObject.Find("InfoiBox1");
            }
            if (ObjecToInstantiate.name == "Machine2")
            {
                InfoiBox = GameObject.Find("InfoiBox2");
            }
            if (ObjecToInstantiate.name == "Machine3")
            {
                InfoiBox = GameObject.Find("InfoiBox3");
            }
            
            
            machinebehaviour = ObjecToInstantiate.GetComponent<Machine_Behaviour>();
            //gameManager.GetComponent<Print>().settext(InFloatMachines.Count+" beginning ");
            
                    if (machinebehaviour.GetMachineStates() == MachineStates.Onshelf)
                    {
                        if (InFloatMachines.Count < MaxCount)
                        {
                        wooosh.Play();
                        //temp = ObjecToInstantiate.transform.position;
                        // ObjecToInstantiate.transform.SetPositionAndRotation(new Vector3(0f, 1.5f, 1f), Quaternion.identity);
                        StartCoroutine(MoveTo(ObjecToInstantiate.transform, new Vector3(0, 1.5f, 1f), 1.5f));
                        //dict.Add(ObjecToInstantiate, temp);
                        InFloatMachines.Add(ObjecToInstantiate);
                        machinebehaviour.SetMachineState(MachineStates.Floating);
                        }
                    }
                    else if (machinebehaviour.GetMachineStates() == MachineStates.Floating)
                    {
                    wooosh.Play();
                    machinebehaviour.SetMachineState(MachineStates.Onshelf);

                    if (ObjecToInstantiate.name == "Machine1")
                    {
                        ObjecToInstantiate.transform.SetPositionAndRotation(ObjecToInstantiate.transform.position, new Quaternion(0, 1, 0, 0));
                        StartCoroutine(MoveTo(ObjecToInstantiate.transform, machine1pos, 1.5f));
                    }
                    if (ObjecToInstantiate.name == "Machine2")
                    {
                        ObjecToInstantiate.transform.SetPositionAndRotation(ObjecToInstantiate.transform.position, new Quaternion(0, 1, 0, 0));
                        StartCoroutine(MoveTo(ObjecToInstantiate.transform, machine2pos, 1.5f));
                    }
                    if (ObjecToInstantiate.name == "Machine3")
                    {
                        ObjecToInstantiate.transform.SetPositionAndRotation(ObjecToInstantiate.transform.position, new Quaternion(0, 1, 0, 0));
                        StartCoroutine(MoveTo(ObjecToInstantiate.transform, machine3pos, 1.5f));
                    }


                        InFloatMachines.Remove(ObjecToInstantiate);
                  //gameManager.GetComponent<Print>().settext(InFloatMachines.Count+" float to shelf ");
                        ObjecToInstantiate.transform.localScale = new Vector3(2, 2, 2);
                        OnGroundMachines.Add(ObjecToInstantiate);
                       
                        return;
                    }else if(machinebehaviour.GetMachineStates() == MachineStates.Onground)
                    {
                    wooosh.Play();
                    machinebehaviour.SetMachineState(MachineStates.Onshelf);
                    if (ObjecToInstantiate.name == "Machine1")
                    {
                        ObjecToInstantiate.transform.SetPositionAndRotation(ObjecToInstantiate.transform.position, new Quaternion(0, 1, 0, 0));
                        StartCoroutine(MoveTo(ObjecToInstantiate.transform, machine1pos, 1.5f));
                    }
                    if (ObjecToInstantiate.name == "Machine2")
                    {
                        ObjecToInstantiate.transform.SetPositionAndRotation(ObjecToInstantiate.transform.position, new Quaternion(0, 1, 0, 0));
                        StartCoroutine(MoveTo(ObjecToInstantiate.transform, machine2pos, 1.5f));
                    }
                    if (ObjecToInstantiate.name == "Machine3")
                    {
                        ObjecToInstantiate.transform.SetPositionAndRotation(ObjecToInstantiate.transform.position, new Quaternion(0, 1, 0, 0));
                        StartCoroutine(MoveTo(ObjecToInstantiate.transform, machine3pos, 1.5f));
                    }

              //  InFloatMachines.Remove(ObjecToInstantiate);
                OnGroundMachines.Remove(ObjecToInstantiate);
                //gameManager.GetComponent<Print>().settext(InFloatMachines.Count + " ground to shelf select machine ");
                ObjecToInstantiate.transform.localScale = new Vector3(2, 2, 2);
                        InfoiBox.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                    foreach (Transform child in ObjecToInstantiate.transform)
                        {
                            if (child.tag == "tree")
                            {
                            child.gameObject.SetActive(false);
                            }
                        }

                    gameManager.GetComponent<AddGravity>().removeGravityMachine(ObjecToInstantiate);
                        
                        return;
                    }
            }
        
       
    }


    public void RemoveObjectFromInFloatMachines(GameObject obj)
    {
        InFloatMachines.Remove(GetGameObject(obj.name));
        gameManager.GetComponent<Print>().settext(InFloatMachines.Count + " ground to shelf removing ");
    }
    

    public  GameObject GetGameObject(string name)
    {
        GameObject gameObject;

        for (int i = 0; i < Machines.Length;i++)
        {
            Debug.Log(Machines[i].name + "----" + name);
            if(Machines[i].name == name)
            {
                return Machines[i];
            }
        }
        return null;
    }
    public GameObject GetGameObjectNotwithName(string name)
    {
        GameObject gameObject;

        for (int i = 0; i < Machines.Length; i++)
        {
            Debug.Log(Machines[i].name + "----" + name);
            if (Machines[i].name != name)
            {

                return Machines[i];
            }
        }
        return null;
    }

    /* public void minimizeUI()
     {
         maximize.SetActive(false);
         minimize.SetActive(true);
     }

     public void maximizeUI()
     {
         minimize.SetActive(false);
         maximize.SetActive(true);

     }
    */

    IEnumerator MoveTo(Transform T,Vector3 position, float time)
    {
        Vector3 start = T.position;
        Vector3 end = position;
        float t = 0;

        while (t < 1)
        {
            yield return null;
            t += Time.deltaTime / time;
            T.position = Vector3.Lerp(start, end, t);
        }
        T.position = end;
    }
}

