using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private void Awake()
    {
        _text.text = Score.totalScore.ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TimeCapsuleKeys"))
        {
            Destroy(other.gameObject);
            Score.totalScore++;
            _text.text=Score.totalScore.ToString();
        }
    }
}
