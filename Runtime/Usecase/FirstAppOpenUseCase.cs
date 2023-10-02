using System;
using AffiseAttributionLib.AffiseParameters;
using AffiseAttributionLib.Session;
using AffiseAttributionLib.Utils;
using UnityEngine;

namespace AffiseAttributionLib.Usecase
{
    internal class FirstAppOpenUseCase
    {
        private readonly ICurrentActiveActivityCountProvider _activityCountProvider;

        public FirstAppOpenUseCase(ICurrentActiveActivityCountProvider activityCountProvider)
        {
            _activityCountProvider = activityCountProvider;
        }

        private const string FIRST_OPENED = "FIRST_OPENED";
        private const string FIRST_OPENED_DATE_KEY = "FIRST_OPENED_DATE_KEY";
        private const string AFF_DEVICE_ID = "AFF_DEVICE_ID";
        private const string AFF_ALT_DEVICE_ID = "AFF_ALT_DEVICE_ID";

        /**
         * Check preferences for have first opened date and generate properties if no data
         */
        public void OnAppCreated()
        {
            if (PrefUtils.GetLong(FIRST_OPENED_DATE_KEY) == 0L)
            {
                OnAppFirstOpen();
            }

            CheckSaveUUIDs();

            //init session observer
            _activityCountProvider.Init();
        }
        
        /**
         * Generate properties on app first open
         */
        private void OnAppFirstOpen()
        {
            //Create first open date
            var firstOpenDate = Timestamp.New();

            CheckSaveUUIDs();
            
            //Save properties
            PrefUtils.SaveLong(FIRST_OPENED_DATE_KEY, firstOpenDate);
            PrefUtils.SaveBoolean(FIRST_OPENED, true);
        }

        private void CheckSaveUUIDs()
        {
            //Create affDevId
            PrefUtils.CheckSaveString(AFF_DEVICE_ID, Uuid.Generate);
            //Create affAltDevId
            PrefUtils.CheckSaveString(AFF_ALT_DEVICE_ID, Uuid.Generate);
            //Create randomUserId
            PrefUtils.CheckSaveString(ProviderType.RANDOM_USER_ID.Provider(), Uuid.Generate);
        }

        /**
         * Get first open
         * @return is first open
         */
        public bool IsFirstOpen()
        {
            var firstOpened = PrefUtils.GetBoolean(FIRST_OPENED, true);
            if (!firstOpened) return false;
            PrefUtils.SaveBoolean(FIRST_OPENED, false);
            return true;
        }
        
        /**
         * Get first open date
         * @return first open date
         */
        public DateTime? GetFirstOpenDate()
        {
            var time = PrefUtils.GetLong(FIRST_OPENED_DATE_KEY, 0);
            if (time == 0L) return null;
            
            return DateTimeOffset.FromUnixTimeMilliseconds(time).UtcDateTime;
        }
        
        /**
         * Get devise id
         * @return devise id
         */
        public string GetAffiseDeviseId() => PrefUtils.GetString(AFF_DEVICE_ID, "");
        
        /**
         * Get alt devise id
         * @return alt devise id
         */
        public string GetAffiseAltDeviseId() => PrefUtils.GetString(AFF_ALT_DEVICE_ID, "");


        /**
         * Get random user id
         * @return random user id
         */
        public string GetRandomUserId() => PrefUtils.GetString(ProviderType.RANDOM_USER_ID.Provider(), "");
    }
}