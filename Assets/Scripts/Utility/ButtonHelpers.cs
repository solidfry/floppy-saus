using UnityEngine;

namespace Utility
{
    public class ButtonHelpers : MonoBehaviour
    {
        public void NewRound()
        {
            Debug.Log("New Round pressed");
            GameEvents.OnPreRoundEvent?.Invoke();
            this.gameObject.SetActive(false);
        }

        public void NewGame()
        {
            Debug.Log("New Game pressed");
            GameEvents.OnPreGameEvent?.Invoke();
        }

        public void LeaveMenu()
        {
            GameEvents.OnLeaveMenuStateEvent?.Invoke();
        }
        public void EnterMenu()
        {
            GameEvents.OnEnterMenuStateEvent?.Invoke();
        }
    }
}
