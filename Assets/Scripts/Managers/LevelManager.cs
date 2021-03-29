using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float waitingTime = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != null)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(waitingTime);

        Debug.Log("temps écoulé");

        SceneManager.LoadScene(levelIndex);
    }
}
