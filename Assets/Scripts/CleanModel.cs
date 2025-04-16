using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanModel : CleanAbstract
{
    [SerializeField]
    private List<BrushModel> Spots;

    private int numContaminated, numCleaned;

    private List<int> contaminatedIndexes;

    [SerializeField]
    private ContaminationList results;

    private void Start()
    {
        RandomizeContamination();
    }

    public override void Result()
    {
        numCleaned = 0;
        for (int i = 0; i < contaminatedIndexes.Count; i++)
        {
            BrushModel part = Spots[contaminatedIndexes[i]];
            if (part.scrubbed == true)
            {
                part.ColorShift(part.SucessMaterial);
                numCleaned++;
                results.AddSpot(part.Position, part.SucessMaterial);
            }
            else if (part.timesCleaned > 0)
            {
                part.ColorShift(part.PartialMaterial);
                results.AddSpot(part.Position, part.PartialMaterial);
            }
            else
            {
                part.ColorShift(part.FailMaterial);
                results.AddSpot(part.Position, part.FailMaterial);
            }
        }
    }

    public override void SetBack()
    {
        for (int i = 0; i < Spots.Count; i++)
        {
            Spots[i].SetBack();
        }

        RandomizeContamination();
    }

    private void RandomizeContamination()
    {
        numContaminated = Random.Range(2, (Spots.Count / 2));
        contaminatedIndexes = new List<int>(numContaminated);
        while (contaminatedIndexes.Count < numContaminated)
        {
            int index = Random.Range(0, Spots.Count);
            if (!contaminatedIndexes.Contains(index))
            {
                contaminatedIndexes.Add(index);
            }
        }
        for (int i = 0; i < Spots.Count; i++)
        {
            if (contaminatedIndexes.Contains(i))
            {
                Spots[i].SetContamination(true, Random.Range(1, 10));
            }
            else
            {
                Spots[i].SetContamination(false, 0);
            }
        }
    }
}
