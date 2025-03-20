using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BrushAbstract : MonoBehaviour
{
    public GameObject gameObj;

    public bool scrubbed;

    public Material FailMaterial;

    public Material SucessMaterial;

    protected MeshRenderer Mesh;

    protected Material BaseMaterial;

    //private List<Collider> Touching;
    public abstract void Start();

    public abstract void Scrub();

    public abstract void SetBack();

    public abstract void ColorShift(Material color);
}
