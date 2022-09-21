using UnityEngine;
using POW.Creators;
using POW.Datas;
using POW.BroadcastingChannels.CubePlatformChannel;

public class References : MonoBehaviour
{
    public static References Instance;

    public GameObject CubePref;
    public PlatformCreatedChannel PlatformCreatedChannel;

    public CubePlatformData CubePlatformData { get; set; }

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