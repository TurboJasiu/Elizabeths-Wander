using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMReasue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BGM.Instance.gameObject.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
