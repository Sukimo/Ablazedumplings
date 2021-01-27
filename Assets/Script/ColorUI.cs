using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUI : MonoBehaviour
{
    public int _indexColor;
    public List<GameObject> _colors = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform item in transform)
        {
            _colors.Add(item.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        #region ControllerColor
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UpdateUI(0);
        }else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            UpdateUI(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UpdateUI(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UpdateUI(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            UpdateUI(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            UpdateUI(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            UpdateUI(6);
        }
        #endregion
    }

    public void UpdateUI(int index)
    {
        if (index >= _colors.Count)
        {
            return;
        }
        _indexColor = index;
        foreach (GameObject item in _colors)
        {
            item.transform.localScale = new Vector3(1, 1, 1);
        }
        _colors[_indexColor].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
}
