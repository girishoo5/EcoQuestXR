using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationShow : MonoBehaviour
{ 
    //[System.Obsolete]
    public void ToggleInformationPanel(GameObject InformationPanel)
    {
        if (InformationPanel.active)
        {

            InformationPanel.gameObject.SetActive(false);
        }
        else
        {
            InformationPanel.gameObject.SetActive(true);
        }
    }

    public void DestroyPanel(GameObject InstructionVideo)
    {
        if (InstructionVideo.active)
        {
            InstructionVideo.gameObject.SetActive(false);
        }
    }

    public void EnablePanel(GameObject InstructionVideo)
    {
        
            InstructionVideo.gameObject.SetActive(true);
       
    }
}
