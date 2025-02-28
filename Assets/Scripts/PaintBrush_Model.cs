using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PaintBrush_Model : MonoBehaviour
{
    [SerializeField] public Transform _tip;
    [SerializeField] public int _penSize = 120;
    //add x and y for size of brush/to make rectangle

    public Material useColor;
    public Color[] _colors;
    public float _tipHeight;

    public RaycastHit _touch;
    public Whiteboard _whiteboard;
    public Vector2 _touchPos, _lastTouchedPos;
    public bool _touchedLastFrame;

    // Start is called before the first frame update
    void Start()
    {
        _colors = Enumerable.Repeat(useColor.color, _penSize * _penSize).ToArray();
        _tipHeight = _tip.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Draw();
    }

    private void Draw()
    {
        //Debug.DrawRay(_tip.position, -transform.up);
        if (Physics.Raycast(_tip.position, -transform.up, out _touch, _tipHeight))
        {
            if (_touch.transform.CompareTag("Whiteboard"))
            {
                if (_whiteboard == null)
                {
                    _whiteboard = _touch.transform.GetComponent<Whiteboard>();
                    //Debug.Log(_whiteboard.textureSize.y);
                    //Debug.Log(_whiteboard.textureSize.x);
                }

                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);


                //error of out of bounds still occuring
                var x = (int)(_touchPos.x * _whiteboard.textureSize.x - (_penSize / 2));
                //Debug.Log(x);
                var y = (int)(_touchPos.y * _whiteboard.textureSize.y - (_penSize / 2));
                //Debug.Log(y);

                if (y < 0 || y > (_whiteboard.textureSize.y-_penSize) || x < 0 || x > (_whiteboard.textureSize.x - _penSize)) 
                {
                    //Debug.Log("Exit");
                    return; 
                }

                if (_touchedLastFrame)
                {
                    (int x, int y) coords = (x, y);
                    _whiteboard.texture.SetPixels(x, y, _penSize, _penSize, _colors);
                    _whiteboard.colorSpots(x, y, _penSize);
                    if (!_whiteboard.painted.Contains(coords))
                    {
                        _whiteboard.painted.Add(coords);
                    }


                    for (float f = 0.01f; f < 1.00f; f += 0.01f)
                    {
                        var lerpX = (int)Mathf.Lerp(_lastTouchedPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(_lastTouchedPos.y, y, f);

                        if (lerpY > 0 && lerpY < (_whiteboard.textureSize.y - _penSize) && lerpX > 0 && lerpX < (_whiteboard.textureSize.x - _penSize))
                        {
                            (int x, int y) lerpCoords = (lerpX, lerpY);
                            if (!_whiteboard.painted.Contains(lerpCoords))
                            {
                                _whiteboard.painted.Add(lerpCoords);
                            }
                            //Debug.Log(lerpX);
                            //Debug.Log(lerpY);
                            _whiteboard.texture.SetPixels(lerpX, lerpY, _penSize, _penSize, _colors);
                            _whiteboard.colorSpots(lerpX, lerpY, _penSize);
                        }

                    }

                    _whiteboard.texture.Apply();
                }

                _lastTouchedPos = new Vector2(x, y);
                _touchedLastFrame = true;
                return;
            }
        }

        _whiteboard = null;
        _touchedLastFrame = false;
    }

    private void Point(int x, int y)
    {
        if (y < 0 || y > (_whiteboard.textureSize.y - _penSize) || x < 0 || x > (_whiteboard.textureSize.x - _penSize))
        {
            //Debug.Log("Exit");
            return;
        }

        (int x, int y) coords = (x, y);
        _whiteboard.texture.SetPixels(x, y, _penSize, _penSize, _colors);
        _whiteboard.colorSpots(x, y, _penSize);
        if (!_whiteboard.painted.Contains(coords))
        {
            _whiteboard.painted.Add(coords);
        }


        for (float f = 0.01f; f < 1.00f; f += 0.01f)
        {
            var lerpX = (int)Mathf.Lerp(_lastTouchedPos.x, x, f);
            var lerpY = (int)Mathf.Lerp(_lastTouchedPos.y, y, f);

            if (lerpY > 0 && lerpY < (_whiteboard.textureSize.y - _penSize) && lerpX > 0 && lerpX < (_whiteboard.textureSize.x - _penSize))
            {
                (int x, int y) lerpCoords = (lerpX, lerpY);
                if (!_whiteboard.painted.Contains(lerpCoords))
                {
                    _whiteboard.painted.Add(lerpCoords);
                }
                //Debug.Log(lerpX);
                //Debug.Log(lerpY);
                _whiteboard.texture.SetPixels(lerpX, lerpY, _penSize, _penSize, _colors);
                _whiteboard.colorSpots(lerpX, lerpY, _penSize);
            }

        }

        _whiteboard.texture.Apply();
    }
}


