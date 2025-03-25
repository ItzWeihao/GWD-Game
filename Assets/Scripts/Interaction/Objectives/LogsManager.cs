using UnityEngine;

public class LogsManager : MonoBehaviour
{
    [SerializeField] private LogsInteractable log1;
    [SerializeField] private LogsInteractable log2;
    [SerializeField] private LogsInteractable log3;

    public Light doorLight;
    public GameObject door;

    private int count;
    private ObjectiveSceneTrigger _objectiveSceneTrigger;

    private void Awake()
    {
        count = 0;
        _objectiveSceneTrigger = door.GetComponent<ObjectiveSceneTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 3)
        {
            doorLight.enabled = true;
            _objectiveSceneTrigger.SetActive();
            door.tag = "Untagged";
        }
    }

    public void CountInteractions()
    {
        count++;
    }
}
