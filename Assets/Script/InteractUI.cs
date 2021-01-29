using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InteractUI : MonoBehaviour
{
    public TextMeshProUGUI _text;
    public Transform _group;
    public void UpdateUI(string str,bool state,KeyCode keycode)
    {
        string key = "";
        if (keycode == KeyCode.F)
            key = "F";

        _group.gameObject.SetActive(state);
        if (state)
        {
            //_text.text = "[Press "+key+" To Pickup " + str + "]";
            _text.text = str;
        }   
        else
        {
            _text.text = "";
        }
    }
}
