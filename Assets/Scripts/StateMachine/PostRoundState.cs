using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace StateMachine
{
    [System.Serializable]
    public class PostRoundState : IGameState
    {
//        private bool buttonFound = false;
        public IGameState DoState(GameManager gameManager)
        {
            // todo: I need to fix the player controller being enabled in the next level
            GameEvents.OnPostRoundEvent?.Invoke();
            GameObject button = GameObject.Find("Next Level");
            if (button)
            {
                Button nextLevelButton = button.GetComponent<Button>();
                int sceneID = gameManager.CurrentLevel.sceneID;
                nextLevelButton.onClick.AddListener(() => SceneManager.LoadScene(sceneID + 1));
                return gameManager.PreGameState;
            }

            return gameManager.PostRoundState;
        }
    }
}
