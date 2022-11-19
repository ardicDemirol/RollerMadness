using UnityEngine;




public class TeleportManager : MonoBehaviour
{
    public GameObject[] teleportBox;
    

    public Vector3 GetTeleportPosition(int index)
    {
        return teleportBox[GetNewIndex(index)].transform.position;
    }

    private int GetNewIndex(int index)
    {
        int newIndex = Random.Range(0, teleportBox.Length + 1);
        if (index != newIndex)
        {
            return newIndex;
        }
        else
        {
            return GetNewIndex(index);
        }  
    }
}
