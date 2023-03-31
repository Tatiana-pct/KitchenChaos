using UnityEngine;

[CreateAssetMenu()]
public class KitchenObjectSO : ScriptableObject
{
    [SerializeField] public string _name;
    [SerializeField] public Sprite _visual;
    [SerializeField] public Transform _prefabs;


}
