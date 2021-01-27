using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public InteractCollision _interactable;
    public System.Action<int> _pickUpEvent;
    public KeyCode _key;
    // Start is called before the first frame update
    void Start()
    {
        _pickUpEvent += delegate { Picked(); };
    }

    // Update is called once per frame
    void Update()
    {
        if (_interactable._interact)
        {
            if (Input.GetKeyDown(_key))
            {
                _pickUpEvent.Invoke(0);
            }
        }
    }

    public void Picked()
    {
        Destroy(this.gameObject);
        _interactable._interact = false;
        _interactable._interactUI.UpdateUI("", true);
    }
}
