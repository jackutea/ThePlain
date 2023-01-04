using UnityEngine;

namespace ThePlain {

    public static class PLog {

        public static void Log(object message) {
            Debug.Log(message);
        }

        public static void Warning(object message) {
            Debug.LogWarning(message);
        }

        public static void Error(object message) {
            Debug.LogError(message);
        }

    }

}