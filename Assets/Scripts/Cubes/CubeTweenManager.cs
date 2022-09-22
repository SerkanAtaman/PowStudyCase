using System.Collections;
using UnityEngine;
using POW.BroadcastingChannels.CubeAnimationChannel;
using POW.BroadcastingChannels.CubePlatformChannel;
using POW.BroadcastingChannels.GameStateChannels;
using POW.BroadcastingChannels.MatchChannel;
using POW.Settings.Cube;
using POW.Datas;
using DG.Tweening;

namespace POW.Cubes
{
    public class CubeTweenManager : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private CubeTweenSettings _cubeTweenSettings;

        [Header("Listening To")]
        [SerializeField] private CubeTweenChannel _cubeTweenChannel;
        [SerializeField] private PlatformCreatedChannel _platformCreatedChannel;
        [SerializeField] private MatchCreatedChannel _matchCreatedChannel;

        [Header("Broadcasting On")]
        [SerializeField] private InitializationEndChannel _initializationEndChannel;
        [SerializeField] private MatchAnimEndChannel _matchAnimEndChannel;

        private CubeMono[] _matchedCubes;

        private void OnEnable()
        {
            _cubeTweenChannel.OnCubeTweenDemanded += OnCubeTweenDemanded;
            _platformCreatedChannel.OnCubePlatformCreated += OnCubePlatformCreated;
            _matchCreatedChannel.OnMatchCreatedWCubes += OnMatchCreated;
        }

        private void OnDisable()
        {
            _cubeTweenChannel.OnCubeTweenDemanded -= OnCubeTweenDemanded;
            _platformCreatedChannel.OnCubePlatformCreated -= OnCubePlatformCreated;
            _matchCreatedChannel.OnMatchCreatedWCubes -= OnMatchCreated;
        }

        private void OnCubeTweenDemanded(CubeTweenData tweenData)
        {
            ProcessTweenDemand(tweenData);
        }

        private void OnCubePlatformCreated()
        {
            StartAnimatingInitialPlatform();
        }

        private void OnMatchCreated(CubeMono[] matchedCubes)
        {
            MergeMatchedCubes(matchedCubes);
        }

        private void OnMatchedCubesMerged()
        {
            if (_matchedCubes == null)
            {
                Debug.LogError("MatchCubes can not be null");
                return;
            }

            foreach(CubeMono match in _matchedCubes)
            {
                Destroy(match.gameObject);
            }

            _matchAnimEndChannel.OnMatchAnimEnded?.Invoke();
        }

        private void ProcessTweenDemand(CubeTweenData tweenData)
        {
            switch (tweenData.Type)
            {
                case CubeTweenType.TRotation:

                    break;

                case CubeTweenType.TPosition:

                    TweenCubePosition(tweenData);
                    break;

                case CubeTweenType.TPositionAndRotation:

                    TweenCubePositionRotation(tweenData);
                    break;

                case CubeTweenType.TPositionRotationScale:

                    TweenCubePositionRotationScale(tweenData);
                    break;
            }
        }

        private void TweenCubePosition(CubeTweenData tweenData)
        {
            switch (tweenData.Space)
            {
                case Space.World:

                    tweenData.Cube.DOMove(tweenData.TargetPosition, _cubeTweenSettings.TweenPosDuration).onComplete += () => tweenData.OnTweenEnd?.Invoke();
                    break;

                case Space.Self:

                    tweenData.Cube.DOLocalMove(tweenData.TargetPosition, _cubeTweenSettings.TweenPosDuration).onComplete += () => tweenData.OnTweenEnd?.Invoke();
                    break;
            }
        }

        private void TweenCubePositionRotation(CubeTweenData tweenData)
        {
            switch (tweenData.Space)
            {
                case Space.World:

                    tweenData.Cube.DOMove(tweenData.TargetPosition, _cubeTweenSettings.TweenPosDuration).onComplete += () => tweenData.OnTweenEnd?.Invoke();
                    tweenData.Cube.DORotateQuaternion(tweenData.TargetRotation, _cubeTweenSettings.TweenRotDuration).onComplete += () => tweenData.OnTweenEnd?.Invoke();
                    break;

                case Space.Self:

                    tweenData.Cube.DOLocalMove(tweenData.TargetPosition, _cubeTweenSettings.TweenPosDuration).onComplete += () => tweenData.OnTweenEnd?.Invoke();
                    tweenData.Cube.DOLocalRotateQuaternion(tweenData.TargetRotation, _cubeTweenSettings.TweenRotDuration).onComplete += () => tweenData.OnTweenEnd?.Invoke();
                    break;
            }
        }

        private void TweenCubePositionRotationScale(CubeTweenData tweenData)
        {
            switch (tweenData.Space)
            {
                case Space.World:

                    tweenData.Cube.DOMove(tweenData.TargetPosition, _cubeTweenSettings.TweenPosDuration).onComplete += () => tweenData.OnTweenEnd?.Invoke();
                    tweenData.Cube.DORotateQuaternion(tweenData.TargetRotation, _cubeTweenSettings.TweenRotDuration).onComplete += () => tweenData.OnTweenEnd?.Invoke();
                    tweenData.Cube.DOScale(tweenData.TargetScale, _cubeTweenSettings.TweenScaleDuration).onComplete += () => tweenData.OnTweenEnd?.Invoke();
                    break;

                case Space.Self:

                    tweenData.Cube.DOLocalMove(tweenData.TargetPosition, _cubeTweenSettings.TweenPosDuration).onComplete += () => tweenData.OnTweenEnd?.Invoke();
                    tweenData.Cube.DOLocalRotateQuaternion(tweenData.TargetRotation, _cubeTweenSettings.TweenRotDuration).onComplete += () => tweenData.OnTweenEnd?.Invoke();
                    tweenData.Cube.DOScale(tweenData.TargetScale, _cubeTweenSettings.TweenScaleDuration).onComplete += () => tweenData.OnTweenEnd?.Invoke();
                    break;
            }
        }

        private void MergeMatchedCubes(CubeMono[] cubes)
        {
            _matchedCubes = cubes;

            cubes[0].transform.DOMove(cubes[1].transform.position, _cubeTweenSettings.TweenPosDuration);
            cubes[2].transform.DOMove(cubes[1].transform.position, _cubeTweenSettings.TweenPosDuration).onComplete += OnMatchedCubesMerged;
        }

        private void StartAnimatingInitialPlatform()
        {
            CubePlatformData platformData = References.Instance.CubePlatformData;

            for(int i = 0; i < platformData.Size; i++)
            {
                CubeMono cube = platformData.GetCube(i);
                if (cube) cube.transform.position += new Vector3(0, 30, 0);
            }

            StartCoroutine(AnimateInitialPlatform(platformData));
        }

        private IEnumerator AnimateInitialPlatform(CubePlatformData platformData)
        {
            int index = 0;

            while(index < platformData.Size)
            {
                CubeMono cube = platformData.GetCube(index);
                if (cube != null)
                {
                    cube.transform.DOLocalMove(cube.DefaultLocalPos, _cubeTweenSettings.TweenPosDuration);
                }

                index++;

                yield return null;
            }

            _initializationEndChannel.OnInitializationEnd?.Invoke();
        }
    }
}