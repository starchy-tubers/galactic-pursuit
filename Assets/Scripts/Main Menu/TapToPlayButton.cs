using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToPlayButton : MonoBehaviour
{
    //TODO: Change this to OnGUI()?
    void Update()
    {
        if(Input.GetMouseButton(0)) 
        {
            // SceneManager.LoadSceneAsync("Level1");
        } 
    }
}
