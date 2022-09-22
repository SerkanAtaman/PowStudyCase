using System;
using UnityEngine;
using POW.Datas.Assets;
using POW.BroadcastingChannels.InteractionChannel;
using POW.BroadcastingChannels.CubeAnimationChannel;

namespace POW.Cubes
{
    public class CubeMono : MonoBehaviour, IInteractable
    {
        [SerializeField] private CubeRotator _cubeRotator;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private AssetData _assetData;

        [Header("Broadcasting On")]
        [SerializeField] private CubeReserveDemandChannel _cubeReserveChannel;
        [SerializeField] private CubeTweenChannel _cubeTweenChannel;

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
            _renderer.material = _assetData.CubeMaterials[(int)Type];
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

        public void GetBackToPlatform(Action callback)
        {
            References.Instance.CubePlatformData.AddCube(this);
            _cubeRotator.enabled = false;

            transform.SetParent(References.Instance.CubePlatformData.PlatformHolder);

            _cubeTweenChannel.OnCubeTweenDemanded?.Invoke(new CubeTweenData(transform, CubeTweenType.TPositionRotationScale, DefaultLocalPos, Quaternion.identity, Vector3.one, Space.Self, callback));

            _interactAbility.InteractType = CubeInteractType.Reserve;
        }

        public void GoToMatchArea(Transform parent, Vector3 localPos, Quaternion localRot, Vector3 localScale, Action callback)
        {
            References.Instance.CubePlatformData.RemoveCube(this);

            transform.SetParent(parent);

            _cubeTweenChannel.OnCubeTweenDemanded?.Invoke(new CubeTweenData(transform, CubeTweenType.TPositionRotationScale, localPos, localRot, localScale, Space.Self, callback));

            _cubeRotator.enabled = true;
            _interactAbility.InteractType = CubeInteractType.None;
        }

        public void SetPositionInReserve(Vector3 localPos)
        {
            _cubeTweenChannel.OnCubeTweenDemanded?.Invoke(new CubeTweenData(transform, CubeTweenType.TPosition, localPos, Space.Self));
        }
    }
}