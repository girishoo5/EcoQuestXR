using UnityEngine;
using UnityEngine.UI;


public class Color_Change : MonoBehaviour
{
    public Material blueMaterial;
    public Material redMaterial;
    public Material yellowMaterial;

    private Renderer cubeRenderer;

    void Start()
    {
        // Get the renderer component of the cube
        cubeRenderer = GetComponent<Renderer>();
    }

    public void ChangeColor()
    {
        // Check for key input

        cubeRenderer.material = blueMaterial;
        Debug.Log("1");
    }

  
}
