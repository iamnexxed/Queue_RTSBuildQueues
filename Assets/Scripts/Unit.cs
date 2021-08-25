
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum Type
    {
        SPEEDSTER,
        NERD,
        HEAVY
    }

    public Type unitType;

    public float unitBuildTime = 2.0f;

    public bool isQueued;
    
}
