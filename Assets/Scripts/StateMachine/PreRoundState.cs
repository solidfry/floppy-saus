using System;
using UnityEngine;

namespace StateMachine
{
    [Serializable]
    public class PreRoundState : IGameState
    {
        [SerializeField] bool isPlaying = false;

        public bool IsPlaying
        {
            get => isPlaying;
            set => isPlaying = value;
        }

        [SerializeField] bool newRound = false;

        public bool NewRound
        {
            get => newRound;
            set => newRound = value;
        }

        public IGameState DoState(GameManager gameManager)
        {
//        Debug.Log("IsPlaying is " + IsPlaying);
            if (gameManager.CurrentLevelType == LevelType.Endless)
            {
                if (NewRound)
                {
                    NewRound = false;
                    DisableIsPlaying();

                    GameEvents.OnPreRoundEvent?.Invoke();
                    Debug.Log("A new round has started");
                    GameEvents.OnDestroyObstaclesEvent?.Invoke();
                    Debug.Log("DestroyObstaclesEvent has been invoked");
                    GameEvents.OnSpawnObstaclesEvent?.Invoke();
                    Debug.Log("OnSpawnObstaclesEvent has been invoked");

                    return gameManager.PreRoundState;
                }
            }

            if (IsPlaying)
            {
                DisableIsPlaying();
                NewRound = false;
                Debug.Log("Pre Round State is shifting to Playing state");
                return gameManager.PlayingState;
            }

            NewRound = false;
            return gameManager.PreRoundState;
        }

        public void EnableIsPlaying()
        {
            IsPlaying = true;
            // Debug.Log("EnablePlaying was done and isPlaying is " + isPlaying);
        }

        public void DisableIsPlaying()
        {
            IsPlaying = false;
            // Debug.Log("DisablePlaying was done and isPlaying is " + isPlaying);
        }

        public void SetNewRound()
        {
            NewRound = true;
            Debug.Log("SetNewRound was done");
        }
    }
}