using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine.Objects;
using System.Collections;

namespace TextAdventureEngine.Locations
{
    public class NearObjects : IEnumerable
    {
        private List<GameObject> _list;

        public NearObjects()
        {
            _list = new List<GameObject>();
        }

        public string Description { 
            get {
                return _list.Aggregate(string.Empty, (a, b) => (a + b.Description));
            } 
        }

        public void Add(GameObject gameObject) {

            _list.Add(gameObject); 
        }

        public void Remove(GameObject gameObject)
        {
            _list.Remove(gameObject);
        }

        public bool Contains(GameObject gameObject)
        {
            return _list.Contains(gameObject);
        }

        public GameObject FirstOrDefault(Func<GameObject, bool> condition)
        {
            return _list.FirstOrDefault(condition);
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            //just so I can use the collection initializer
            throw new NotImplementedException();
        }
    }
}
