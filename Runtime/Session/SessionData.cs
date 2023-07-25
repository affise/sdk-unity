namespace AffiseAttributionLib.Session
{
    internal class SessionData
    {
        public long LifetimeSessionCount { get; }
        public long AffiseSessionCount { get; }

        public SessionData(long lifetimeSessionCount = 0L, long affiseSessionCount = 0L)
        {
            LifetimeSessionCount = lifetimeSessionCount;
            AffiseSessionCount = affiseSessionCount;
        }

        public SessionData Copy(long? lifetimeSessionCount = null, long? affiseSessionCount = null)
        {
            return new SessionData(
                lifetimeSessionCount: lifetimeSessionCount ?? this.LifetimeSessionCount,
                affiseSessionCount: affiseSessionCount ?? this.AffiseSessionCount
            );
        }
    }
}