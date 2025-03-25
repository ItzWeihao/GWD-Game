using UnityEngine;

public class PictureManager : MonoBehaviour
{
    [SerializeField] private RobinPicture _robinPicture;
    [SerializeField] private SagePicture _sagePicture;

    public Light doorLight;
    public GameObject door;

    private int count;
    private ObjectiveSceneTrigger _objectiveSceneTrigger;

    private void Awake()
    {
        count = 0;
        _objectiveSceneTrigger = door.GetComponent<ObjectiveSceneTrigger>();
    }

    private void Update()
    {
        if (count == 2)
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
