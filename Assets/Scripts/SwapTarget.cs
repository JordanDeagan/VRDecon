using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targets;

    public void switchTargets(int index)
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if (i == index)
            {
                targets[i].SetActive(true);
            }
            else
            {
                targets[i].SetActive(false);
            }
        }
    }
}
