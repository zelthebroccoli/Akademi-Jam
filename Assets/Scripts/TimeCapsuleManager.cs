using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeCapsuleManager : MonoBehaviour
{
    public int capsuleCount;
    public Text capsuleText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        capsuleText.text = ":" + capsuleCount.ToString();
    }
}
