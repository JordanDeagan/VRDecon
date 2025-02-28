using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushArea : BrushAbstract
{
    public Whiteboard whiteboard;
    public Calculations popUp;

    //public Material Material3;

    //private List<Collider> Touching;
    public override void Start()
    {
        whiteboard = gameObj.GetComponentInChildren<Whiteboard>();
        popUp = gameObj.GetComponentInChildren<Calculations>();
        popUp.canvas.SetActive(false);

        scrubbed = false;
    }

    protected override void Scrub()
    {
        ColorShift(SucessMaterial);
        scrubbed = true;
    }

    public override void SetBack()
    {
        whiteboard.SetBoard();
        popUp.closePopup();
        scrubbed = false;
    }

    public override void ColorShift(Material newColor)
    {
        int amount = whiteboard.getColors();
        
        popUp.openPopup(amount.ToString());

        if (amount < 95)
        {
            whiteboard.setColor(newColor.color);
            whiteboard.alterColored(SucessMaterial.color, 50);
        }
    }
    
}
