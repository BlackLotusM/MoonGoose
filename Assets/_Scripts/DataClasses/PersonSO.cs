using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterObject", order = 1)]
public class PersonSO : ScriptableObject
{
    public string characterName;
    public Sprite profilePic;
}