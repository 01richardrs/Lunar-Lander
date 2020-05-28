using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text bottomText;
    public AudioSource audiosource;
    public AudioClip winAudio;
    public AudioClip LoseAudio;

    public string NextLevel;

    public IEnumerator GameOverWin(){
        audiosource.clip = winAudio;
        audiosource.Play();
        bottomText.text = "You have landed your Landerer";
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(NextLevel);
    }
    public IEnumerator GameOverLose(){
        audiosource.clip = LoseAudio;
        audiosource.Play();
        bottomText.text = "You have exploded your Landerer";
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
