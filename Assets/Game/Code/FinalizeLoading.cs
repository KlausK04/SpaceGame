using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalizeLoading : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(5));
        Debug.Log("LoadLevelAferDelay(5)");
    }
    public IEnumerator LoadLevelAfterDelay(float delay)
    {
        Debug.Log("LoadLevelAferDelay(5)");
        yield return new WaitForSeconds(delay);
        if (PlayerPrefs.GetString("SceneName") == "Unknown_Regions")
        {
            SceneManager.LoadSceneAsync(0);
            Debug.Log("LoadScene_0");
        }
        else if (PlayerPrefs.GetString("SceneName") == "CoreWorlds")
        {
            SceneManager.LoadSceneAsync(1);
            Debug.Log("LoadScene_1");
        }

    }
}