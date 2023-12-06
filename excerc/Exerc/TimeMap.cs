namespace excerc.Exerc
{
    public class TimeMap
    {
        private Dictionary<string, List<(int Version, string Value)>> _mapper = new();
        public TimeMap() { }

        public void Set(string key, string value, int timestamp)
        {
            if (_mapper.ContainsKey(key))
                _mapper[key].Add((timestamp, value));

            else
                _mapper[key] = new List<(int Version, string Value)>() { (timestamp, value) };
        }

        public string Get(string key, int timestamp)
        {
            if (!_mapper.ContainsKey(key))
                return string.Empty;

            var vals = _mapper[key];

            var l = 0;
            var r = vals.Count - 1;

            while (l <= r)
            {
                var mid = (r - l) / 2;

                if (vals[mid].Version == timestamp)
                    return vals[mid].Value;
                else if (vals[mid].Version > timestamp)
                    r = mid - 1;
                else l = mid + 1;
            }

            return l == 0 ? string.Empty : vals[l - 1].Value;
        }
    }
}