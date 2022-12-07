using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteActionChangeScene : AbstractCompleteAction
{
    public int sceneIndex;

    // Update is called once per frame
    public override void CompleteAction()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
