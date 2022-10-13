using UnityEngine;

namespace GeneralScripts
{
    public class MonoSigleton<T> : MonoBehaviour where T: MonoSigleton<T>
    {
        private static volatile T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<T>();
                return _instance;
            }
        }
    }
}
