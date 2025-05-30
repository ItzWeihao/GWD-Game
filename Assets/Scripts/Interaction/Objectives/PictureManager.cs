using UnityEngine;

public class PictureManager : MonoBehaviour
{
    [SerializeField] private RobinPicture _robinPicture;
    [SerializeField] private SagePicture _sagePicture;

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
            count++;
            _objectiveSceneTrigger.SetActive();
        }
    }

    public void CountInteractions()
    {
        count++;
    }
}
