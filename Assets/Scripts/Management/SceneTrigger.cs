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

            // We set the current Scene Index and switch to that scene
            _sceneTransition.SwitchScene();
        }
    }
}
