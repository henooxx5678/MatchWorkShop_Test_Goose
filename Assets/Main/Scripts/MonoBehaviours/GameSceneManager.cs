using Math = System.Math;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectTestGoose {

    [DisallowMultipleComponent]
    public class GameSceneManager : SingletonMonoBehaviour<GameSceneManager> {

        [Header("REFS")]
        public Inventory playerInventory;

        [Header("UI REFS")]
        [SerializeField] GameObject _endGameConfirmationPanel;

        public bool IsRunning {get; private set;} = false;

        void Start () {
            IsRunning = true;
        }

        public void PopOutEndGameConfirmation () {

            if (_endGameConfirmationPanel != null) {
                _endGameConfirmationPanel.SetActive(true);
                IsRunning = false;
            }
        }

        public void ResponseToEndGameConfirmation (bool endGame) {

            if (endGame) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else {
                if (_endGameConfirmationPanel != null) {
                    _endGameConfirmationPanel.SetActive(false);
                }
                IsRunning = true;
            }
        }

    }
}
