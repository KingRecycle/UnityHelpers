using UnityEngine;

namespace CharlieMadeAThing.TooManyBricks.Helpers {
    public static class Logger {
        public static void Log( this MonoBehaviour mb, string message ) {
            Debug.Log( $"[{mb.name}]: {message}" );
        }
        
        public static void LogWarning( this MonoBehaviour mb, string message ) {
            Debug.LogWarning( $"[{mb.name}]: {message}" );
        }
        
        public static void LogError( this MonoBehaviour mb, string message ) {
            Debug.LogError( $"[{mb.name}]: {message}" );
        }
        
        public static void Log( this ScriptableObject so, string message ) {
            Debug.Log( $"[{so.name}]: {message}" );
        }
        
        public static void LogWarning( this ScriptableObject so, string message ) {
            Debug.LogWarning( $"[{so.name}]: {message}" );
        }
        
        public static void LogError( this ScriptableObject so, string message ) {
            Debug.LogError( $"[{so.name}]: {message}" );
        }

    }
}