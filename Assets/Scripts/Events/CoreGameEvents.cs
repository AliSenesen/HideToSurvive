using Extentions;
using UnityEngine.Events;

namespace Events
{
    public class CoreGameEvents : MonoSingleton<CoreGameEvents>
    {
        public UnityAction onWin = delegate { };
        public UnityAction onFail = delegate { };
        public UnityAction onLevelChange = delegate {  };
        public UnityAction onRestart = delegate {  };
    }
}

