using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangedColorObject : MonoBehaviour
{
    public ColorTemp _colorTemp;
    public ColorData _currentColor;
    public ColorData _defaltColor;
    public Material _mat;
    private float r=255, g=255, b = 255;
    public Collider _co;
    public System.Action<int> _defaltMode;
    public System.Action<int> _colorEvent;
    private MeshRenderer _mr;
    public bool _startVisible,_activeColor,_flashDirty,_isDirty;
    public PlatfromMove _Moveplatfrom;
    public JumpPlatfrom _jumpPlatfrom;
    public Color _unSelect,_flash;
    // Start is called before the first frame update
    void Start()
    {
        ColorController.Instance._colorObj.Add(this);
        _mat = GetComponent<Renderer>().material;
        _co = GetComponent<MeshCollider>();
        _defaltMode += delegate { DefaltMode(); AddChangeColor(); };
        _colorEvent += delegate { EventColor(); AddChangeColor(); };
        _mr = GetComponent<MeshRenderer>();
        //_defaltMode.Invoke(_currentColor);

        if(GetComponent<PlatfromMove>()!=null)
            _Moveplatfrom = GetComponent<PlatfromMove>();
        if (GetComponent<JumpPlatfrom>() != null)
            _jumpPlatfrom = GetComponent<JumpPlatfrom>();
    }
    public void Update()
    {
        
    }

    public void AddChangeColor()
    {
        if(!_flashDirty&& !_isDirty)
            StartCoroutine(StartChangeColor());
    }
    public IEnumerator StartChangeColor()
    {
        StartCoroutine(Flash());
        yield return new WaitUntil(()=>_flashDirty==false);
        _isDirty = true;

        float time = 0;
        //_mat.color != _colorTemp._color
        var _matTemp = _mat.color;

        while (time<=0.99f)
        {
            _mat.color = Color.Lerp(_matTemp, _colorTemp._color, time);
            time += Time.deltaTime;
            yield return null;
        }
        _isDirty = false;
        yield break;
        //_mat.color = _colorTemp._color;

    }
    public IEnumerator Flash()
    {

        _flashDirty = true;
        float time = 0;
        var _matTemp = _mat.color;
        //_mat.color != _flash
        while (time<=0.99f)
        {
            _mat.color = Color.Lerp(_matTemp, _flash, time);
            time += Time.deltaTime * 8.8888f;
            yield return null;
        }
        _flashDirty = false;
    }
    public void DefaltMode()
    {
        if (_currentColor._name == "red")
        {
            _co.enabled = true;
            _colorTemp._color = _unSelect;
        }
        if (_currentColor._name == "green")
        {
            if (_Moveplatfrom != null)
                _Moveplatfrom.StopMove();
            _colorTemp._color = _unSelect;
        }
        if (_currentColor._name == "blue")
        {
            if (_jumpPlatfrom != null)
                _jumpPlatfrom.StopEvent();
            _colorTemp._color = _unSelect;
        }
    }

    public void EventColor()
    {
        //print("ActiveEvent : "+_currentColor._name);
        if (_currentColor._name == "red")
        {
            _co.enabled = false;
        }
        if (_currentColor._name == "green")
        {
            if (_Moveplatfrom != null)
                _Moveplatfrom.StartMove();
        }
        if (_currentColor._name == "blue")
        {
            if (_jumpPlatfrom != null)
                _jumpPlatfrom.StartEvent();
        }
        ChangeColor(_currentColor);
    }

    public void ChangeColor(ColorData color)
    {
        if (!_activeColor)
            return;

        if (color._name == "red")
        {
            if (_currentColor._name == "red")
            {
                _colorTemp._color = new Color(r,0,0);
            }
            else if (_currentColor._name == "green")
            {
                _colorTemp._color = new Color(r, g, 0);
            }
            else if (_currentColor._name == "blue")
            {
                _colorTemp._color = new Color(r, 0, b);
            }
            
        }
        if (color._name == "green")
        {
            if (_currentColor._name == "red")
            {
                _colorTemp._color = new Color(r, g, 0);
            }
            else if (_currentColor._name == "green")
            {
                _colorTemp._color = new Color(0, g, 0);
            }
            else if (_currentColor._name == "blue")
            {
                _colorTemp._color = new Color(0, g, b);
            }
            
        }
        if (color._name == "blue")
        {
            if (_currentColor._name == "red")
            {
                _colorTemp._color = new Color(r, 0, b);
            }
            else if (_currentColor._name == "green")
            {
                _colorTemp._color = new Color(0, g, b);
            }
            else if (_currentColor._name == "blue")
            {
                _colorTemp._color = new Color(0, 0, b);
            }
        }
        if (color._name == "temp")
        {
            _colorTemp._color = _defaltColor._color;
        }
    }
}
