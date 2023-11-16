using System;
using Controllers;
using DG.Tweening;
using Enums;
using Events;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIPanelController panelController;


        #region EventSubscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameEvents.Instance.onWin += OnWin;
            CoreGameEvents.Instance.onFail += OnFail;
        }


        private void UnsubscribeEvents()
        {
            CoreGameEvents.Instance.onWin -= OnWin;
            CoreGameEvents.Instance.onFail -= OnFail;
        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void Start()
        {
            panelController.OpenPanel(UIPanels.InGame);
        }

        private void OnWin()
        {
            panelController.OpenPanel(UIPanels.Win);
        }

        private void OnFail()
        {
            panelController.OpenPanel(UIPanels.Fail);
        }

        public void NextButton()
        {
            panelController.ClosePanel(UIPanels.Win);
            CoreGameEvents.Instance.onLevelChange?.Invoke();
        }
        public void TryAgainButton()
        {
            panelController.ClosePanel(UIPanels.Fail);
            CoreGameEvents.Instance.onRestart?.Invoke();
        }
        


        public void QuitGameButton()
        {
            Application.Quit();
        }
    }
}