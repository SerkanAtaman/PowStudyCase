using System.Collections.Generic;
using UnityEngine;

namespace POW.Utilities.Collections
{
    public class CustomDictionary<T, W>
    {
        private readonly List<T> _keys;
        private readonly List<W> _values;

        public int Length { get; private set; }

        public CustomDictionary()
        {
            _keys = new List<T>();
            _values = new List<W>();

            Length = 0;
        }

        public void Add(T key, W value)
        {
            _keys.Add(key);
            _values.Add(value);
            Length++;
        }

        public void Remove(T key)
        {
            if (Length == 0)
            {
                Debug.LogError("The dictionary does not have any keys or values");
                return;
            }

            int index = -1;

            for (int i = 0; i < Length; i++)
            {
                if (Equals(_keys[i], key))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Debug.LogError("The Dictionary does not contains the given key");
                return;
            }
            
            _keys.RemoveAt(index);
            _values.RemoveAt(index);
            Length--;
        }

        public void UpdateValue(T key, W newValue)
        {
            int index = -1;

            for (int i = 0; i < Length; i++)
            {
                if (Equals(_keys[i], key))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Debug.LogError("The Dictionary does not contains the given key");
                return;
            }

            _values[index] = newValue;
        }

        public W GetValue(T key)
        {
            int index = -1;

            for (int i = 0; i < Length; i++)
            {
                if (Equals(_keys[i], key))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Debug.LogError("The Dictionary does not contains the given key");
                return default;
            }

            return _values[index];
        }

        public W GetValueOnIndex(int index)
        {
            return _values[index];
        }

        public T GetKey(W value)
        {
            int index = -1;

            for (int i = 0; i < Length; i++)
            {
                if (Equals(_values[i], value))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Debug.LogError("The Dictionary does not contains the given value");
                return default;
            }

            return _keys[index];
        }

        public W GetRandomValue()
        {
            if(Length == 0)
            {
                Debug.LogError("The dictionary does not have any keys or values");
                return default;
            }

            int randIndex = Random.Range(0, Length);

            return _values[randIndex];
        }

        public T GetRandomKey()
        {
            if (Length == 0)
            {
                Debug.LogError("The dictionary does not have any keys or values");
                return default;
            }

            int randIndex = Random.Range(0, Length);

            return _keys[randIndex];
        }

        public bool ContainsKey(T key)
        {
            bool contains = false;

            for (int i = 0; i < Length; i++)
            {
                if (Equals(_keys[i], key))
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }
    }
}