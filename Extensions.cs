using UnityEngine;

namespace CharlieMadeAThing.TooManyBricks.Core
{
    public static class Extensions
    {
        public static Vector3 Round( this Vector3 vect )
        {
            return new Vector3( Mathf.Round( vect.x ), Mathf.Round( vect.y ), Mathf.Round( vect.z ) );
        }

        public static Vector2 Round( this Vector2 vect )
        {
            return new Vector2( Mathf.Round( vect.x ), Mathf.Round( vect.y ) );
        }

        public static Vector3 ToVector3( this Vector2Int vect )
        {
            return new Vector3( vect.x, vect.y, 0 );
        }

        public static Vector3 ToVector3Int( this Vector3 vect )
        {
            return new Vector3Int( (int)vect.x, (int)vect.y, (int)vect.z );
        }

        public static Vector2Int ToVector2Int( this Vector2 vect )
        {
            return new Vector2Int( (int)vect.x, (int)vect.y );
        }

        public static Vector2Int ToVector2Int( this Vector3 vect )
        {
            return new Vector2Int( (int)vect.x, (int)vect.y );
        }

        public static string RemoveLastCharacter( this string str )
        {
            return string.IsNullOrEmpty( str ) ? str : str.Remove( str.Length - 1, 1 );
        }
    }
}
