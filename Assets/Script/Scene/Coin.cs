using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject _paticleEffect;
    public AudioClip _sound;
    private AudioSource _source;
    public float _score;
    private void Start()
    {
        foreach (Transform item in ScoreController.Instance.gameObject.transform)
        {
            print(item.name + " " + this.gameObject.name);
            if (item.name == this.gameObject.name)
            {
                Destroy(this.gameObject);
            }
        }
        transform.parent = ScoreController.Instance.gameObject.transform;
        //ScoreController.Instance.CheckCoin(this);
        _source = Camera.main.GetComponent<AudioSource>();
        ScoreController.Instance._allCoin +=1;
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
            ScoreController.Instance.AddScore(_score);
            //this.transform.parent = ScoreController.Instance.transform;
            gameObject.SetActive(false);
        }
    }
    
}
