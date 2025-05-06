using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContamItemText : MonoBehaviour
{
    private string location, count;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTextValues(string part, int cleaned, int total)
    {
        text.text = part + ": " + cleaned.ToString() + "/" + total.ToString();
    }
}
