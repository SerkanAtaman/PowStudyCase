using UnityEngine;
using POW.Datas;


public class References : MonoBehaviour
{
    public static References Instance;

    public GameObject CubePref;

    public CubePlatformData CubePlatformData { get; set; }

    private void Awake()
    {
        Instance = this;
    }
}