using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTree : MonoBehaviour
{
    public GameObject gameManager;
    public List<MeshRenderer> GrowTreeMeshes;
    public float TimeToGrow = 5f;
    public float RefreshRate = 0.05f;
    [Range(0,1)]
    public float MinGrow = 0.2f;
    [Range(0, 1)]
    public float MaxGrow = 0.97f;

    private List<Material> GrowTreeMaterials = new List<Material>();
    private bool FullyGrown;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GrowTreeMeshes.Count; i++)
        {
            for (int j = 0; j < GrowTreeMeshes[i].materials.Length; j++)
            {
                if (GrowTreeMeshes[i].materials[j].HasProperty("Grow_"))
                {
                    GrowTreeMeshes[i].materials[j].SetFloat("Grow_", MinGrow);
                    GrowTreeMaterials.Add(GrowTreeMeshes[i].materials[j]);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < GrowTreeMaterials.Count; i++)
            {
                StartCoroutine(GrowTrees(GrowTreeMaterials[i]));
            }

        }
    }

    public void startGrowing()
    {
        for (int i = 0; i < GrowTreeMaterials.Count; i++)
        {
            StartCoroutine(GrowTrees(GrowTreeMaterials[i]));
        }
        return;
    }

    IEnumerator GrowTrees(Material mat)
    {
        float growValue = 0f;
     //   gameManager.GetComponent<Print>().settext("grow treeeeeee");
        //if (!FullyGrown)
        //{
        while (growValue < MaxGrow)
            {
                growValue += 1 / (TimeToGrow / RefreshRate);
                mat.SetFloat("Grow_", growValue);

                yield return new WaitForSeconds(RefreshRate);
            }
        //}
        //else
        //{
        //    while (growValue > MinGrow)
        //    {
        //        growValue -= 1 / (TimeToGrow / RefreshRate);
        //        mat.SetFloat("Grow_", growValue);

        //        yield return new WaitForSeconds(RefreshRate);
        //    }
        //}

        if (growValue >= MaxGrow)
        {
            FullyGrown = true;
        }
        else
        {
            FullyGrown = false;
        }
    }
}
