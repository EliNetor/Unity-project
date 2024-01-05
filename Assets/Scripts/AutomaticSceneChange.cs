using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutomaticSceneChange : MonoBehaviour
{
    public Animator animator;  // The Animator component
    public string animationName = "YourAnimation";  // The name of your animation
    public string sceneToLoad = "NextScene";  // The name of the scene to load

    public void OnAnimationComplete()
    {
            SceneManager.LoadScene(sceneToLoad);
    }
}

//This script causes a change in scene at the end of an animation