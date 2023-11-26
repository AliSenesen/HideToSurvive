using System;
using Controllers;
using DG.Tweening;
using Enums;
using Events;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIPanelController panelController;
        [SerializeField] private TextMeshProUGUI levelText;

        private int _levelCount;


        #region EventSubscription

        private void Awake()
        {
            _levelCount = 1;
            levelText.text = "Lv" + " " + _levelCount;
        }

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
            UpdateUI();
        }

        private void OnFail()
        {
            panelController.OpenPanel(UIPanels.Fail);
        }

        public void NextButton()
        {
            panelController.ClosePanel(UIPanels.Win);
            CoreGameEvents.Instance.onLevelChange?.Invoke();
           // AdManager.instance.ShowAd();
        }

        public void TryAgainButton()
        {
            panelController.ClosePanel(UIPanels.Fail);
            CoreGameEvents.Instance.onRestart?.Invoke();
            AdManager.instance.ShowAd();
        }

        private void UpdateUI()
        {
            _levelCount++;
            levelText.text = "Lv" + " " + _levelCount;
        }

        public void QuitGameButton()
        {
            Application.Quit();
        }
    }
}