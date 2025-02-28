using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisual : MonoBehaviour
{
    [SerializeField]
    private List<MeshRenderer> visuals;
    [SerializeField]
    private bool isOn;
    private bool priorState;
    // Start is called before the first frame update
    void Start()
    {
        SwapState();
    }

    // Update is called once per frame
    void Update()
    {
        if (priorState != isOn)
        {
            SwapState();
        }
    }

    private void SwapState()
    {
        if (isOn)
        {
            foreach (MeshRenderer part in visuals)
            {
                part.enabled = true;
            }
        }
        else
        {
            foreach (MeshRenderer part in visuals)
            {
                part.enabled = false;
            }
        }
        priorState = isOn;
    }
}
