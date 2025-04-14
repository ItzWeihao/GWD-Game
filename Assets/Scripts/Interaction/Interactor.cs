using UnityEngine;
using DialogueEditor;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public PlayerMovement PlayerMovement;
    public GameObject indicator;

    void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObjIndicator) || hitInfo.collider.gameObject.TryGetComponent(out NPCConversation conversationObjIndicator))
            {
                indicator.SetActive(true);
            } else
            {
                indicator.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                //if (hitInfo.collider.gameObject.CompareTag("LockedDoor"))
                //{
                //    Debug.Log("It won't budge");
                //}
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }

                else if (hitInfo.collider.gameObject.TryGetComponent(out NPCConversation conversationObj))
                {
                    PlayerMovement.CursorSetting(0, true);
                    PlayerMovement.StopPlayerMovement();

                    if (!ConversationManager.Instance.IsConversationActive)
                    {
                        PlayerMovement.inDialogue = true;
                        ConversationManager.Instance.StartConversation(conversationObj);
                    }
                }
            }
        }
        else if (indicator.activeSelf)
        {
            indicator.SetActive(false);
        }
        

        if (!ConversationManager.Instance.IsConversationActive && PlayerMovement.inDialogue)
        {
            PlayerMovement.inDialogue = false;
            PlayerMovement.ResumePlayerMovement();
            PlayerMovement.CursorSetting(CursorLockMode.Locked, false);
        }
    }
}
