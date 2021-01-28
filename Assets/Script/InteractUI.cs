using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InteractUI : MonoBehaviour
{
    public TextMeshProUGUI _text;
    public Transform _group;

    public void UpdateUI(string str,bool state)
    {
        _group.gameObject.SetActive(state);
        if (state)
        {
            _text.text = "[Press F To Pickup " + str + "]";
        }
        else
        {
            _text.text = "";
        }
    }
}
