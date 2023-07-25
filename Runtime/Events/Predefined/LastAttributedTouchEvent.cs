using System;
using AffiseAttributionLib.Events.Property;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class LastAttributedTouchEvent : NativeEvent
    {
        private readonly TouchType _touchType;
        private readonly JSONObject _touchData;

        public LastAttributedTouchEvent(): base()
        {}
        public LastAttributedTouchEvent(string userData): base(userData: userData)
        {}
        public LastAttributedTouchEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use LastAttributedTouchEvent(userData, timeStampMillis)")]
        public LastAttributedTouchEvent(
            TouchType touchType,
            long timeStampMillis,
            JSONObject touchData,
            string userData
        )
            : base(userData, timeStampMillis)
        {
            _touchType = touchType;
            _touchData = touchData;
        }

        protected override AffisePropertyBuilder SerializeBuilder()
        {
            return base.SerializeBuilder()
                .Add("type", _touchType.ToValue())
                .Add("data", _touchData);
        }

        public override string GetName() => EventName.LAST_ATTRIBUTED_TOUCH.ToValue();
    }
}