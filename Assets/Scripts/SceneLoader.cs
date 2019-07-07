﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // シーンの管理をするための宣言

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// シーンを切り替える
    /// </summary>
    /// <param name="sceneName">読み込みたいシーンの名前</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}