using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class StairsSongController : MonoBehaviour
{
    [SerializeField] AudioSource song;

    private void OnEnable()
    {
        GameManager.OnRetry += Restart;
        GameManager.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        GameManager.OnRetry -= Restart;
        GameManager.OnGameOver -= GameOver;
    }

    private void GameOver()
    {
        song.pitch = 0.45f;
    }

    private void Restart()
    {
        song.pitch = 1.45f;
    }
}
