using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBox : MonoBehaviour
{

    [SerializeField]
    private List<CleanAbstract> Bases;

    public bool check, repeat;

    void Start()
    {
        check = false;
        repeat = false;
    }


    void Update()
    {
        if (check)
        {
            this.Finish();
            check = false;
        }

        if (repeat)
        {
            this.Repeat();
            repeat = false;
        }
    }

    public void Finish()
    {
        for (int i=0; i<Bases.Count; i++)
        {
            Bases[i].Result();
        }
    }

    public void Repeat()
    {
        for (int i = 0; i < Bases.Count; i++)
        {
            Bases[i].SetBack();
        }
    }
    
}
