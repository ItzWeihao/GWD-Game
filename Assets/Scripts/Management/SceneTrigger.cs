using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public SceneTransition _sceneTransition;
    public Transform _respawnPoint;
    public Transform _player;
    public PlayerMovement _playerMovement;
    
    void OnTriggerEnter(UnityEngine.Collider other)
    {
        GameObject collidedObject = other.gameObject;
        if (collidedObject.tag == "PlayerObject")
        {
            _playerMovement.SetMovementDirectionToZero();

            // Get the current Scene by Index
            var currentSceneIndex = _sceneTransition.GetSceneIndex();
            
            // Increment to the next Scene by Index
            currentSceneIndex++;

            // We set the current Scene Index and switch to that scene
            _sceneTransition.SetSceneIndex(currentSceneIndex);
            _sceneTransition.SwitchScene(currentSceneIndex);

            // We also repsawn the player to the set coordinate
            
            _player.position = _respawnPoint.position;
            _player.rotation = _respawnPoint.rotation;
            Debug.Log(_player.position);
        }
    }
}
