using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Controllers
{
    public class UIPanelController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> PanelsList;

        public void OpenPanel(UIPanels panels)
        {
            PanelsList[(int)panels].SetActive(true);
        }

        public void ClosePanel(UIPanels panels)
        {
            PanelsList[(int)panels].SetActive(false);
        }
    }
}