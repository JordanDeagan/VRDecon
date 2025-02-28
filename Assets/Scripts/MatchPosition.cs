using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPosition : MonoBehaviour
{
    [SerializeField]
    private GameObject follow;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetPositionAndRotation(follow.transform.position, follow.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(follow.transform.position, follow.transform.rotation);
    }
}
