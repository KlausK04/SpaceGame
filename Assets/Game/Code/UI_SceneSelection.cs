using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class UI_SceneSelection : MonoBehaviour
{
    public GameObject buttonPrefab;
    public string SceneName { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        CreateSelectionMenu();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void Awake()
    {
        UpdateMenu();
    }

    public IEnumerator UpdateMenu()
    {
        yield return new WaitForSeconds(1);
        Canvas.ForceUpdateCanvases();
        CreateSelectionMenu();
    }

    public List<string> GetScenes()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings - 3;
        List<string> scenes = new List<string>();
        for (int i = 0; i < sceneCount; i++)
        {
            string name = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));

            if (name != "LoadingScene" || name != "SpaceStation") scenes.Add(name);
        }
        return scenes;
    }

    public void CreateSelectionMenu()
    {
        List<string> scenes = GetScenes();
        GameObject button;
        var panel = GameObject.FindGameObjectWithTag("SceneSelection");
        var size = 0f;
        for (int i = 0; i < scenes.Count; ++i)
        {
            button = (GameObject)Instantiate(buttonPrefab);
            button.transform.position = panel.transform.position;
            button.GetComponent<RectTransform>().SetParent(panel.transform);
            button.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 2, 200);
            button.layer = 5;
            Vector3 pos = button.transform.position;
            pos.y += size;
            pos.x -= 10f;
            button.transform.position = pos;
            button.GetComponentInChildren<Text>().text = scenes[i];
            button.GetComponentInChildren<Text>().name = scenes[i];
            button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(LoadLoadingScene);
            SceneName = scenes[i];
            size += 35f;


        }

    }

    public void LoadLoadingScene()
    {
        //Input.GetButton(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);
        AsyncOperation op = SceneManager.LoadSceneAsync(2);
    }
}
