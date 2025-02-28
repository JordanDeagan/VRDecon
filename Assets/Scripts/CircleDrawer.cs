using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDrawer : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 priorPos;

    [SerializeField]
    private float minDistance = 0.1f;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 1;
        priorPos = transform.position;
    }

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPos.z += 0.31f;

            if (Vector3.Distance(currentPos, priorPos) > minDistance)
            {
                if(priorPos == transform.position)
                {
                    lr.SetPosition(0, currentPos);
                }
                else
                {
                    lr.positionCount++;
                    lr.SetPosition(lr.positionCount - 1, currentPos);
                }

                priorPos = currentPos;
            }
        }
    }

}