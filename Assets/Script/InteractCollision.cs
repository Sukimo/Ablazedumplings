using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InteractCollision : MonoBehaviour
{
    public bool _interact;
    public InteractUI _interactUI;
    public string _detail;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _interact = true;
            _interactUI.UpdateUI(transform.parent.name, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _interact = false;
            _interactUI.UpdateUI("", false);
        }
    }
}
