using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StopAll : MonoBehaviour
{
    private void Start()
    {
            Destroy(Level.instance.gameObject);
            Level.instance = null;
    }
}
