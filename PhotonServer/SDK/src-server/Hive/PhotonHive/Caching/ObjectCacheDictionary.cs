namespace Photon.Hive.Caching
{
    #region

    using System;
    using System.Collections;
    using System.Collections.Generic;

    #endregion

    [Serializable]
    public class ObjectCacheDictionary : IEnumerable<KeyValuePair<string, Hashtable>>
    {
        private readonly Dictionary<string, Hashtable> dictionary = new Dictionary<string, Hashtable>();


        public bool TryToUpdateObject(Hashtable data)
        {
            string objectId = (string)data["oid"];
            if (String.IsNullOrEmpty(objectId))
            {
                return false;
            }

            if (dictionary.TryGetValue(objectId, out Hashtable cachedData))
            {
                dictionary[objectId] = data;
                return true;
            }
            else
                return false;
        }

        public bool TryRemoveObject(string objectId)
        {
            if (dictionary.Remove(objectId))
                return true;
            else
                return false;
        }

        public bool CreateNewObject(Hashtable data)
        {
            string objectId = (string)data["oid"];
            if (String.IsNullOrEmpty(objectId))
            {
                return false;
            }
            dictionary.Add(objectId, data);
            return true;
        }

        public Dictionary<string, Hashtable> GetSerializationData()
        {
            Dictionary<string, Hashtable> serializationData = new Dictionary<string, Hashtable>();
            foreach (KeyValuePair<string, Hashtable> obj in dictionary)
            {
                serializationData.Add(obj.Key, obj.Value);
            }
            return serializationData;
        }

        public void SetDeserializedData(Dictionary<string, Hashtable> dict)
        {
            foreach (KeyValuePair<string, Hashtable> obj in dict)
            {
                if (!this.dictionary.ContainsKey(obj.Key))
                {
                    this.dictionary.Add(obj.Key, obj.Value);
                }
            }
        }

        public int GetNumerOfObjects()
        {
            return this.dictionary.Count;
        } 

        public Dictionary<string, Hashtable> GetAllObjects()
        {
            return this.dictionary;
        }

        /*




        public ObjectCache GetOrCreateObjectCache(string objectId)
        {
            ObjectCache objectCache;
            if (this.TryGetObjectCache(objectId, out objectCache) == false)
            {
                objectCache = new ObjectCache();
                this.dictionary.Add(objectId, objectCache);
            }

            return objectCache;
        }

        public bool TryGetObjectCache(string objectId, out ObjectCache objectCache)
        {
            return this.dictionary.TryGetValue(objectId, out objectCache);
        }

        public bool RemoveObjectCache(string objectId)
        {
            return this.dictionary.Remove(objectId);
        }

        public void ReplaceObject(string objectId, byte objectEventCode, Hashtable objectData)
        {
            var objectCache = this.GetOrCreateObjectCache(objectId);
            if (objectData == null)
            {
                objectCache.Remove(objectEventCode);
            }
            else
            {
                objectCache[objectEventCode] = objectData;
            }
        }

        public bool RemoveObject(string objectId, byte objectEventCode)
        {
            ObjectCache objectCache;
            if (!this.dictionary.TryGetValue(objectId, out objectCache))
            {
                return false;
            }

            return objectCache.Remove(objectEventCode);
        }

        public void MergeObject(string objectId, Hashtable objectData)
        {
            // if obeject data is null the object will be removed from the cache
            if (objectData == null)
            {
                this.RemoveObject(objectId, objectEventCode);
                return;
            }

            var objectCache = this.GetOrCreateObjectCache(objectId);

            Hashtable storedObjectData;
            if (objectCache.TryGetValue(objectEventCode, out storedObjectData) == false)
            {
                objectCache.Add(objectEventCode, objectData);
                return;
            }

            foreach (DictionaryEntry pair in objectData)
            {
                // null values are removed
                if (pair.Value == null)
                {
                    storedObjectData.Remove(pair.Key);
                }
                else
                {
                    storedObjectData[pair.Key] = pair.Value;
                }
            }
        }
        */

        public IEnumerator<KeyValuePair<string, Hashtable>> GetEnumerator()
        {
            return this.dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.dictionary.GetEnumerator();
        }
    }
}