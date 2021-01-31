using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public string _sceneName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneModule.Instance.LoadSceneByName(_sceneName, true);
            other.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
