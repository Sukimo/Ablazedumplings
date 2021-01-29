using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public static ColorController Instance { get; private set; }
    public List<ChangedColorObject> _colorObj = new List<ChangedColorObject>();
    public List<ColorData> _cheat = new List<ColorData>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PickUpColor(_cheat[0]);
            ColorUI.Instance.AddColor(_cheat[0]);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            PickUpColor(_cheat[1]);
            ColorUI.Instance.AddColor(_cheat[1]);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            ColorUI.Instance.AddColor(_cheat[2]);
            PickUpColor(_cheat[2]);
        }
    }
    public void PickUpColor(ColorData color)
    {
        foreach (ChangedColorObject item in _colorObj)
        {
            if (color._color == item._currentColor._color)
            {
                item._activeColor = true;
                item._defaltMode.Invoke(0);
                ColorUI.Instance._isDirty = false;
            }
        }
    }

    public void ResetColor()
    {
        foreach (ChangedColorObject item in _colorObj)
        {
            item._defaltMode.Invoke(0);
        }
    }

    public void AvtiveEvent(ColorData color)
    {
        ResetColor();
        foreach (ChangedColorObject item in _colorObj)
        {
            if (color._color == item._currentColor._color)
            {
                item._colorEvent.Invoke(0);
            }
        }
    }
}
