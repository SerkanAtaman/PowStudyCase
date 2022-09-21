using UnityEngine;
using POW.BroadcastingChannels.InteractionChannel;

namespace POW.Cubes
{
    public class CubeMono : MonoBehaviour, IInteractable
    {
        [SerializeField] private CubeRotator _cubeRotator;

        [Header("Broadcasting On")]
        [SerializeField] private CubeReserveChannel _cubeReserveChannel;

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
        }

        public void Interact()
        {
            _interactAbility.Interact();
        }

        public void GetReserved()
        {
            _cubeReserveChannel.OnCubeReserveDemanded?.Invoke(this, OnSuccessfullyReserved);
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

        private void OnSuccessfullyReserved()
        {
            _cubeRotator.enabled = true;
            _interactAbility.InteractType = CubeInteractType.None;
        }
    }
}