using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public SceneTransition _sceneTransition;
    
    void OnTriggerEnter(UnityEngine.Collider other)
    {
        GameObject collidedObject = other.gameObject;
        if (collidedObject.tag == "PlayerObject")
        {
            collidedObject.GetComponent<PlayerMovement>().SetMovementDirectionToZero(); 

            // Get the current Scene by Index
            var currentSceneIndex = _sceneTransition.GetSceneIndex();
            
            // Increment to the next Scene by Index
            currentSceneIndex++;

            // We set the current Scene Index and switch to that scene
            _sceneTransition.SetSceneIndex(currentSceneIndex);
            _sceneTransition.SwitchScene(currentSceneIndex);
        }
    }
}
