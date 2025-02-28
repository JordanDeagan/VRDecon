using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanArea : CleanAbstract
{
    [SerializeField]
    private List<BrushArea> Spots;

    public override void Result()
    {
        for (int i = 0; i < Spots.Count; i++)
        {
            if (Spots[i].scrubbed == false)
            {
                Spots[i].ColorShift(Spots[i].FailMaterial);
            }
        }
    }

    public override void SetBack()
    {
        for (int i = 0; i < Spots.Count; i++)
        {
            Spots[i].SetBack();
        }
    }
}
