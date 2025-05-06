using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContaminationList : MonoBehaviour
{
    private List<GameObject> Spots; //Create a custom object for this list to hold

    [SerializeField]
    private GameObject ListPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSpot(string Position, Material Condition, int count, int total)
    {
        GameObject newItem = Instantiate(ListPrefab);
        newItem.GetComponent<Image>().material = Condition;
        newItem.GetComponentInChildren<ContamItemText>().SetTextValues(Position, count, total);
        Spots.Add(newItem);
    }
}
