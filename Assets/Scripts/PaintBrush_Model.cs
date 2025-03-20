using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBrush_Model : MonoBehaviour
{
    [SerializeField]
    private GameObject currentScrub;
    [SerializeField]
    private bool Scrubbing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Model" && !Scrubbing)
        { 
            currentScrub = other.gameObject;
            Scrubbing = true;
            currentScrub.GetComponent<BrushModel>().Scrub();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentScrub)
        {
            Scrubbing = false;
        }
    }
}
