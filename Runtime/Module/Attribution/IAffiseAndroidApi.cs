#nullable enable


namespace AffiseAttributionLib.Module.Attribution
{
    public interface IAffiseAndroidApi
    {
        /**
          * Send enabled autoCatching [types]
          */
//      public void SetAutoCatchingTypes(List<AutoCatchingType> types);

        /**
         * Erases all user data
         */
        public void Forget(string userData);

        /**
         * Set [enabled] to collect metrics
         */
//      public void SetEnabledMetrics(bool enabled);

        public void CrashApplication();
    }
}