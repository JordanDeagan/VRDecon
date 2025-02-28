using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculations : MonoBehaviour
{
    public string amount;
    public string basic;
    TMPro.TextMeshPro popupText;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        basic = "Percent cleaned: ";
        popupText = GetComponent<TMPro.TextMeshPro>();
        popupText.text = basic;
        canvas = gameObject.transform.parent.gameObject;
        //canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openPopup(string per)
    {
        amount = basic + per;
        popupText.text = amount;
        canvas.SetActive(true);
    }

    public void closePopup()
    {
        canvas.SetActive(false);
    }
}
