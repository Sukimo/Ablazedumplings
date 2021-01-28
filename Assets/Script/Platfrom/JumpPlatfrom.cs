using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatfrom : MonoBehaviour
{
    public bool _isDirty;
    public float _jumpForce;
    public void StartEvent()
    {
        _isDirty = true;
    }

    public void StopEvent()
    {
        _isDirty = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (_isDirty)
            {
                print("JUMP!");
                collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
            }
        }
    }
}
