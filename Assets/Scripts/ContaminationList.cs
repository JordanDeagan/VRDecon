using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContaminationList : MonoBehaviour
{
    private List<string> Spots; //Create a custom object for this list to hold

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSpot(string Position, Material Condition)
    {
        Spots.Add(Position);
    }
}
