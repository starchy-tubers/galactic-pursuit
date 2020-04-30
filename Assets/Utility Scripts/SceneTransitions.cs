﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public string sceneName;
    public Animator transitionAnim;

    private void Update()
    {
        if (Input.GetMouseButton(0)) StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.5f);
        ShipShoot.multiplier = 1;
        SceneManager.LoadScene(sceneName);
    }
}