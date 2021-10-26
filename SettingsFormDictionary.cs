using Road_Lap1.SettingsForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Road_Lap1
{
    public class SettingsFormDictionary : IDictionary<SettingsForm, ISettingForm>
    {
        private Dictionary<SettingsForm, ISettingForm> _dictionary;

        private static SettingsFormDictionary _instance;

        public static SettingsFormDictionary Instance => _instance ?? new SettingsFormDictionary();

        public ICollection<SettingsForm> Keys => _dictionary.Keys;

        public ICollection<ISettingForm> Values => _dictionary.Values;

        public int Count => _dictionary.Count;

        public bool IsReadOnly => false;

        public ISettingForm this[SettingsForm key]
        {
            get => _dictionary[key];
            set => _dictionary[key] = value;
        }

        private SettingsFormDictionary()
        {
            _instance = this;
            _dictionary = new Dictionary<SettingsForm, ISettingForm>();
        }

        public IEnumerator GetEnumerator() => _dictionary.GetEnumerator();

        public bool ContainsKey(SettingsForm key) => _dictionary.ContainsKey(key);

        public void Add(SettingsForm key, ISettingForm value) => _dictionary.Add(key, value);

        public bool Remove(SettingsForm key) => _dictionary.Remove(key);

        public bool TryGetValue(SettingsForm key, out ISettingForm value) => _dictionary.TryGetValue(key, out value);

        public void Add(KeyValuePair<SettingsForm, ISettingForm> item) => _dictionary.Add(item.Key, item.Value);

        public void Clear() => _dictionary.Clear();

        public bool Contains(KeyValuePair<SettingsForm, ISettingForm> item) => _dictionary.ContainsKey(item.Key);

        public void CopyTo(KeyValuePair<SettingsForm, ISettingForm>[] array, int arrayIndex) 
                                              => ((IDictionary<SettingsForm, ISettingForm>)_dictionary).CopyTo(array, arrayIndex);

        public bool Remove(KeyValuePair<SettingsForm, ISettingForm> item) => _dictionary.Remove(item.Key);

        IEnumerator<KeyValuePair<SettingsForm, ISettingForm>> IEnumerable<KeyValuePair<SettingsForm, ISettingForm>>.GetEnumerator() 
                                                                                           => _dictionary.GetEnumerator();

        public bool TryAdd(SettingsForm key, ISettingForm value)
        {
            if(_dictionary.ContainsKey(key))
            {
                return false;
            }

            _dictionary[key] = value;

            return true;
        }
    }
}
