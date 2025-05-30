using UnityEngine;

public class LogsManager : MonoBehaviour
{
    [SerializeField] private LogsInteractable log1;
    [SerializeField] private LogsInteractable log2;
    [SerializeField] private LogsInteractable log3;

    public GameObject phone;

    public AudioSource audioSource;
    [SerializeField] private int count;
    private ObjectiveSceneTrigger _objectiveSceneTrigger;

    private void Awake()
    {
        count = 0;
    }

    public void CountInteractions()
    {
        count++;
    }

    public void FinishObjective()
    {
        if (count == 3)
        {
            count++;
            phone.SetActive(true);
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
