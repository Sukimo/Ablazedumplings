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
            _interact = true;
            _interactUI.UpdateUI(transform.parent.name, true, _key);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _interact = false;
            _interactUI.UpdateUI("", false, _key);
        }
    }
}
