using UnityEngine;

[System.Serializable]
public class Waypoint
{
    public string name;
    [SerializeField]
    public int index;
    [SerializeField]
    public Transform waypointTransform;
    public Targets targets;
}

[System.Serializable]
public class Targets
{
    public Transform left;
    public Transform right;
    public Transform up;
    public Transform down;
}