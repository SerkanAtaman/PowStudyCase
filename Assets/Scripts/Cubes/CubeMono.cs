using UnityEngine;
using POW.BroadcastingChannels.InteractionChannel;

namespace POW.Cubes
{
    public class CubeMono : MonoBehaviour, IInteractable
    {
        [SerializeField] private CubeRotator _cubeRotator;
        [SerializeField] private Renderer _renderer;

        [Header("Broadcasting On")]
        [SerializeField] private CubeReserveDemandChannel _cubeReserveChannel;

        public CubeType Type { get; private set; }

        public Vector3Int Coordinates { get; private set; }
        public Vector3 DefaultLocalPos { get; private set; }

        private CubeInteractAbility _interactAbility;

        public void Init(CubeType type, Vector3Int coords)
        {
            _interactAbility = new CubeInteractAbility(this);
            _interactAbility.InteractType = CubeInteractType.Reserve;
            Type = type;
            Coordinates = coords;
            _cubeRotator.enabled = false;
            DefaultLocalPos = transform.localPosition;
            _renderer.material = References.Instance.AssetData.CubeMaterials[(int)Type];
        }

        public void Interact()
        {
            _interactAbility.Interact();
        }

        public bool IsMatchableWith(CubeMono cube)
        {
            return cube.Type == Type;
        }

        public void GetReserved()
        {
            _cubeReserveChannel.OnCubeReserveDemanded?.Invoke(this);
        }

        public void GetBackToPlatform()
        {
            _cubeRotator.enabled = false;

            transform.SetParent(References.Instance.CubePlatformData.PlatformHolder);
            transform.localPosition = DefaultLocalPos;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;

            _interactAbility.InteractType = CubeInteractType.Reserve;
        }

        public void GoToMatchArea(Transform parent, Vector3 localPos, Quaternion localRot, Vector3 localScale)
        {
            transform.SetParent(parent);
            transform.localPosition = localPos;
            transform.localRotation = localRot;
            transform.localScale = localScale;

            _cubeRotator.enabled = true;
            _interactAbility.InteractType = CubeInteractType.None;
        }

        public void SlideInReserve(float slideAmount)
        {
            transform.localPosition += new Vector3(slideAmount, 0, 0);
        }
    }
}