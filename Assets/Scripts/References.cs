using UnityEngine;
using POW.Creators;

public class References : MonoBehaviour
{
    public static References Instance;

    public GameObject CubePref;

    private CubePlatformCreator creator;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        creator = new CubePlatformCreator();

        creator.CreateCubePlatform();
    }
}