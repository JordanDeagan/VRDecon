using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassthroughToggle : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Objects;

    [SerializeField]
    private Camera MainCamera;

    [SerializeField]
    private Material SkyboxMaterial, PassthroughMaterial;

    private bool IsPassthroughOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePassthrough()
    {
        if (IsPassthroughOn)
        {
            foreach (GameObject obj in Objects)
            {
                obj.SetActive(true);
            }
            IsPassthroughOn = false;
            MainCamera.clearFlags = CameraClearFlags.Skybox;
            RenderSettings.skybox = SkyboxMaterial;
        }
        else
        {
            foreach (GameObject obj in Objects)
            {
                obj.SetActive(false);
            }
            IsPassthroughOn = true;
            MainCamera.clearFlags = CameraClearFlags.SolidColor;
            RenderSettings.skybox = PassthroughMaterial;
        }
    }
}
