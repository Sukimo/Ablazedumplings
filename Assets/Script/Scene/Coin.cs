using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject _paticleEffect;
    public AudioClip _sound;
    private AudioSource _source;
    private void Start()
    {
        _source = Camera.main.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_paticleEffect)
            {
                if (_sound) _source.PlayOneShot(_sound);
                Destroy(Instantiate(_paticleEffect, transform.position, Quaternion.identity).gameObject, 5);
            }
            Destroy(this.gameObject);
        }
    }
}
