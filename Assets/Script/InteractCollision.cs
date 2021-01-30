using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InteractCollision : MonoBehaviour
{
    public bool _interact;
    public InteractUI _interactUI;
    public string _detail;
    public KeyCode _key;
    private void Start()
    {
        _interactUI = CanvasMain.Instance._interactUI;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Toast.Instance._objectCollistion = this;
            ShowText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            HideText();
        }
    }

    public void ShowText()
    {
        _interact = true;
        _interactUI.UpdateUI(_detail, true, _key);
    }

    public void HideText()
    {
        _interact = false;
        _interactUI.UpdateUI("", false, _key);
        Toast.Instance.ResetToast();
    }
}
