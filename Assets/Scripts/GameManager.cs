using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public bool IsTimeStopped { get; private set; } = false;
        public float timeStopDuration = 5f; // Zamanýn duracaðý süre

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void StopTime(float duration)
        {
            if (!IsTimeStopped)
            {
                StartCoroutine(TimeStopCoroutine(duration));
            }
        }

        private IEnumerator TimeStopCoroutine(float duration)
        {
            IsTimeStopped = true;
            Time.timeScale = 0f; // Zamaný durdur
            yield return new WaitForSecondsRealtime(duration); // Gerçek zaman bekle
            Time.timeScale = 1f; // Zamaný tekrar baþlat
            IsTimeStopped = false;
        }
    }



