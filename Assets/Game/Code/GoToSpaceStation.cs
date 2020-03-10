﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSpaceStation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);
        if (other.gameObject.name == "PlayerShip")
            SceneManager.LoadSceneAsync(3);
    }
}
