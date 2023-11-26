using System;
using Enums;
using Events;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            AdManager.instance.LoadInterstitialAd();
        }
    }
}