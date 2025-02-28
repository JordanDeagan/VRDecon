using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushModel : BrushAbstract
{
    public Material PartialMaterial;

    public int contamLevel;

    //public Material Material3;

    public int timesCleaned;

    public bool contaminated;

    //private List<Collider> Touching;
    public override void Start()
    {
        Mesh = gameObj.GetComponent<MeshRenderer>();

        BaseMaterial = Mesh.material;

        scrubbed = false;

        timesCleaned = 0;
    }

    protected override void Scrub()
    {
        if (timesCleaned < contamLevel)
        {
            timesCleaned++;
            if (timesCleaned == contamLevel)
            {
                scrubbed = true;
            }
        }
    }

    public override void SetBack()
    {
        ColorShift(BaseMaterial);
        scrubbed = false;
        contaminated = false;
        timesCleaned = 0;
        contamLevel = 0;
    }

    public override void ColorShift(Material color)
    {
        Mesh.material = color;
    }

    public void SetContamination(bool isContaminated, int level)
    {
        contaminated = isContaminated;
        contamLevel = level;
    }

}
