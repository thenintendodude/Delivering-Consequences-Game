using System;
using System.IO;
using UnityEngine;

namespace Helpers
{
    // (Credit: Zee helped with idea to store manuscript in Json and provided tool to read Json)
    public static class JsonHelper
    {
        public static T[] getNodeArray<T>(string json)
        {

            Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);

            return wrapper.nodes;
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] nodes;
        }
    }
}