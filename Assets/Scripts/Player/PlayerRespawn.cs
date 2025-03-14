using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public Quaternion GetRotation()
    {
        return transform.rotation;
    }

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }
}
