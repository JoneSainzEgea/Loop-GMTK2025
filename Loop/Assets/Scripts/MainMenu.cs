using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject videoScreen;
    [SerializeField] private VideoPlayer player;

    private float videoDuration = 0f;

    private void Start()
    {
        videoScreen.SetActive(false);      
    }

    public void StartGame()
    {
        videoScreen.SetActive(true);
        videoDuration = (float)player.clip.length;
        player.Play();
        StartCoroutine(StartGameAfterVideo());
    }

    IEnumerator StartGameAfterVideo()
    {
        yield return new WaitForSeconds(videoDuration);
        SceneManager.LoadScene(1);
    }
}
