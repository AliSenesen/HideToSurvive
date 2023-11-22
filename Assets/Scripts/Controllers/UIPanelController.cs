using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class UIPanelController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> panelsList;

        public void OpenPanel(UIPanels panels)
        {
            panelsList[(int)panels].SetActive(true);
        }

        public void ClosePanel(UIPanels panels)
        {
            panelsList[(int)panels].SetActive(false);
        }
    }
}