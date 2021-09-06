using UnityEngine;

public class P_DialogueBase : MonoBehaviour
{
    [SerializeField] public GameObject interact;
    public bool pressedE;
    [HideInInspector] public string actor;
}
