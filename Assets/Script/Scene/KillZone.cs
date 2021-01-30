using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public bool _skip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneModule.Instance.LoadSceneByName(SceneModule.Instance._currentScene, _skip);
        }
    }
}
