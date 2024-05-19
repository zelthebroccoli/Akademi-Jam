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
        UpdateCapsuleText();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        capsuleCount -= damage;
        if (capsuleCount < 0)
        {
            capsuleCount = 0;
        }
        UpdateCapsuleText();
        Debug.Log("capsule azaldý");
    }

    private void UpdateCapsuleText()
    {
        capsuleText.text = ":" + capsuleCount.ToString();
        Debug.Log("capsule azaldý");
    }
   
}

