using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPaint : MonoBehaviour
{

    public Whiteboard whiteboard;
    public PaintBrush_Model brush;
    public Material displayColor;
    public Material clearColor;
    public Material initColor;

    public bool display;

    private Material buttonColor;
    private MeshRenderer mesh;


    // Start is called before the first frame update
    void Start()
    {
        display = false;
        mesh = GetComponent<MeshRenderer>();
        buttonColor = mesh.material;
    }

    public void changeColor()
    {
        if (!display)
        {
            //print("1");
            mesh.material = displayColor;
            display = true;
            whiteboard.setMaterial(initColor);
            //whiteboard.alterColored(displayColor.color, brush._penSize);
        }
        else if (display)
        {
            //print("2");
            mesh.material = buttonColor;
            display = false;
            whiteboard.setMaterial(clearColor);
            //whiteboard.alterColored(clearColor.color, brush._penSize);
        }
    }
}
