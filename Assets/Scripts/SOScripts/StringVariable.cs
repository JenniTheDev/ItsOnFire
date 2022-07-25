using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Variables
{
    [CreateAssetMenu(fileName = "New Game Variable (string)", menuName = "Game Variable/New Game Variable (string)")]
    public class StringVariable : ScriptableObject
    {
        [SerializeField] private string stringValue;

        public string StringValue
        { get { return this.stringValue; } set { this.stringValue = value; } }

        public StringVariable(string stringValue)
        {
            this.stringValue = stringValue;
        }

        public static implicit operator string(StringVariable v)
        {
            return v.stringValue;
        }
    }
}