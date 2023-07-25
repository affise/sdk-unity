﻿using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class UpdateEvent : NativeEvent
    {
        public UpdateEvent(): base()
        {}
        public UpdateEvent(string userData): base(userData: userData)
        {}
        public UpdateEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use UpdateEvent(userData, timeStampMillis)")]
        public UpdateEvent(JSONArray details, string userData): base(userData: userData)
        {
            AnyData = details;
        }

        public override string GetName() => EventName.UPDATE.ToValue();
    }
}