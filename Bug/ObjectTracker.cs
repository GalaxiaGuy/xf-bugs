using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace Bug
{
    public class ObjectTracker : INotifyPropertyChanged
    {
        public static ObjectTracker Instance { get; } = new ObjectTracker();

        private Dictionary<string, List<WeakReference>> _references { get; } = new Dictionary<string, List<WeakReference>>();

        public IReadOnlyDictionary<string, List<WeakReference>> Items => _references;

        public event PropertyChangedEventHandler PropertyChanged;

        public void Track(string key, object obj)
        {
            if (!_references.TryGetValue(key, out var list))
            {
                list = new List<WeakReference>();
                _references.Add(key, list);
            }
            if (!list.Any(x => x.Target == obj))
            {
                list.Add(new WeakReference(obj));
            }
            Clean();
        }

        public void Clean()
        {
            GC.Collect();
            foreach (var list in _references.Values)
            {
                list.RemoveAll(x => !x.IsAlive);
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
        }
    }
}
