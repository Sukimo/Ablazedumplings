using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject _paticleEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_paticleEffect)
            {
                Destroy(Instantiate(_paticleEffect, transform.position, Quaternion.identity).gameObject, 5);
            }
            Destroy(this.gameObject);
        }
    }
}
