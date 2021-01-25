using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace Bug
{
    public class ObjectCounter : INotifyPropertyChanged
    {
        public static ObjectCounter Instance { get; } = new ObjectCounter();
        public long Bytes { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void TrackObject(string key, object obj)
        {
            Bytes = GC.GetTotalMemory(true);

            if (!_tracked.TryGetValue(key, out var list))
            {
                list = new List<WeakReference>();
                _tracked.Add(key, list);
            }
            list.RemoveAll(x => !x.IsAlive);
            list.Add(new WeakReference(obj));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tracked)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Bytes)));
        }

        private readonly Dictionary<string, List<WeakReference>> _tracked = new Dictionary<string, List<WeakReference>>();

        public IEnumerable<KeyValuePair<string, int>> Tracked
            => _tracked.Select(x => new KeyValuePair<string, int>(x.Key, x.Value.Count));
    }
}
