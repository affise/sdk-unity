#nullable enable
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.Usecase
{
    internal class IndexUseCaseImpl : IIndexUseCase
    {
        private const string UUID_INDEX_KEY = "com.affise.UUID_INDEX_KEY";
        private const string AFFISE_EVENT_ID_INDEX_KEY = "com.affise.AFFISE_EVENT_ID_INDEX_KEY";

        private long _uuidIndexValue = PrefUtils.GetLong(UUID_INDEX_KEY, 0);
        private long _affiseEventIdIndexValue = PrefUtils.GetLong(AFFISE_EVENT_ID_INDEX_KEY, 0);

        private object _lockUuidIndex = new();
        private object _lockAffiseEventIdIndex = new();

        public long GetUuidIndex()
        {
            lock(_lockUuidIndex)
            {
                _uuidIndexValue++;
                PrefSave(UUID_INDEX_KEY, _uuidIndexValue);
                return _uuidIndexValue;
            }
        }

        public long GetAffiseEventIdIndex()
        {
            lock(_lockAffiseEventIdIndex)
            {
                _affiseEventIdIndexValue++;
                PrefSave(AFFISE_EVENT_ID_INDEX_KEY, _affiseEventIdIndexValue);
                return _affiseEventIdIndexValue;   
            }
        }

        private void PrefSave(string key, long value)
        {
            PrefUtils.SaveLong(key, value);
        }
    }
}