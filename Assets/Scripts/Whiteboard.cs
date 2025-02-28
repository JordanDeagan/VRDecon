using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class Whiteboard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(1024, 1024);
    public MeshRenderer mesh;
    public Color baseColor;
    public List<List<int>> scrubbed;
    public List<(int, int)> painted;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        baseColor = mesh.material.color;
        scrubbed = new List<List<int>>((int)textureSize.x);
        for (int i = 0; i < (int)textureSize.x; i++)
        {
            scrubbed.Add(new List<int>((int)textureSize.y));

            for (int j = 0; j < (int)textureSize.y; j++)
            {
                scrubbed[i].Add(0);
            }
        }
        SetBoard();
    }

    public void SetBoard()
    {
        var r = GetComponent<Renderer>();
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        setColor(baseColor);
        r.material.mainTexture = texture;
        for (int i = 0; i < (int)textureSize.x; i++)
        {
            for (int j = 0; j < (int)textureSize.y; j++)
            {
                scrubbed[i][j] = 0;
            }
        }
        painted = new List<(int, int)>();
    }

    public void setColor(Color n)
    {
        Color[] temp = Enumerable.Repeat(n, (int)textureSize.x * (int)textureSize.y).ToArray();
        //Color[] temp = Enumerable.Repeat(n, 1).ToArray();
        //for (int i = 0; i < (int)textureSize.x; i++)
        //{
        //    for (int j = 0; j < (int)textureSize.y; j++)
        //    {
        //        texture.SetPixels(i, j, 1, 1, temp);
        //    }
        //}
        texture.SetPixels(0, 0, (int)textureSize.x, (int)textureSize.y, temp);
        texture.Apply();
    }

    public void setMaterial(Material mat)
    {
        mesh.material = mat;
        var r = GetComponent<Renderer>();
        r.material.mainTexture = texture;
    }

    public void colorSpots(int drawX, int drawY, int penSize)
    {
        int x = drawX;
        int y = drawY;

        for (int i = x; i < x + penSize; i++)
        {
            for (int j = y; j < y + penSize; j++)
            {
                scrubbed[i][j] = 1;
            }
        }
    }

    public int getColors()
    {
        int count = 0;

        for (int i = 0; i < (int)textureSize.x; i++)
        {
            for (int j = 0; j < (int)textureSize.y; j++)
            {
                count += scrubbed[i][j];
            }
        }
        //Debug.Log(count);
        int total = (int)textureSize.x * (int)textureSize.y;
        //Debug.Log(total);
        int per = (count * 100) / total;
        //Debug.Log(per);
        return per;
    }

    public void alterColored(Color n, int penSize)
    {
        Color[] temp = Enumerable.Repeat(n, penSize * penSize).ToArray();
        for (int i=0; i<painted.Count; i++)
        {
            (int x, int y) coords = painted[i];
            //Debug.Log(coords);
            texture.SetPixels(coords.x, coords.y, penSize, penSize, temp);
        }
        texture.Apply();
    }
}
