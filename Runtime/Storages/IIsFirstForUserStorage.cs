using System.Collections.Generic;

namespace AffiseAttributionLib.Storages
{
    internal interface IIsFirstForUserStorage
    {
        void Add(string eventClass);
        
        List<string> GetEventNames();
    }
}