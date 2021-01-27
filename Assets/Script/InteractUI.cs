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
        _text.text = str;
    }
}
