using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(LoadScene());
        }
    }

    private IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.5f);
        ShipShoot.multiplier = 1;
        SceneManager.LoadSceneAsync(sceneName);
    }
}
