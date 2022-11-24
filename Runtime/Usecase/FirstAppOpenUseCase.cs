using System;
using AffiseAttributionLib.Extensions;
using AffiseAttributionLib.AffiseParameters;
using AffiseAttributionLib.Session;
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

        private const string FIRST_OPENED = "FIRST_OPENED_DATE_KEY";
        private const string FIRST_OPENED_DATE_KEY = "FIRST_OPENED_DATE_KEY";
        private const string AFF_DEVICE_ID = "AFF_DEVICE_ID";
        private const string AFF_ALT_DEVICE_ID = "AFF_ALT_DEVICE_ID";

        /**
         * Check preferences for have first opened date and generate properties if no data
         */
        public void OnAppCreated()
        {
            if (PlayerPrefsExt.GetLong(FIRST_OPENED_DATE_KEY, 0) == 0L)
            {
                OnAppFirstOpen();
            }

            //init session observer
            _activityCountProvider.Init();
        }
        
        /**
         * Generate properties on app first open
         */
        private void OnAppFirstOpen()
        {
            //Create first open date
            var firstOpenDate = DateTime.UtcNow.GetTimeInMillis();

            //Create affDevId
            var affDevId = Guid.NewGuid().ToString();

            //Create affAltDevId
            var affAltDevId = Guid.NewGuid().ToString();
            
            //Create randomUserId
            var randomUserId = Guid.NewGuid().ToString();

            PlayerPrefsExt.SetLong(FIRST_OPENED_DATE_KEY, firstOpenDate);
            PlayerPrefs.SetInt(FIRST_OPENED, 1);
            PlayerPrefs.SetString(AFF_DEVICE_ID, affDevId);
            PlayerPrefs.SetString(AFF_ALT_DEVICE_ID, affAltDevId);
            PlayerPrefs.SetString(Parameters.RANDOM_USER_ID, randomUserId);
        }
        
        /**
         * Get first open
         * @return is first open
         */
        public bool IsFirstOpen()
        {
            if (PlayerPrefs.GetInt(FIRST_OPENED, 1) == 0) return false;
            
            PlayerPrefs.SetInt(FIRST_OPENED, 0);
            return true;
        }
        
        /**
         * Get first open date
         * @return first open date
         */
        public DateTime GetFirstOpenDate()
        {
            var time = PlayerPrefsExt.GetLong(FIRST_OPENED_DATE_KEY, 0);
            if (time == 0L) return new DateTime(1970, 1, 1).ToLocalTime();
            
            return DateTimeOffset.FromUnixTimeMilliseconds(time).UtcDateTime;
        }
        
        /**
         * Get devise id
         * @return devise id
         */
        public string GetAffiseDeviseId() => PlayerPrefs.GetString(AFF_DEVICE_ID, "");
        
        /**
         * Get alt devise id
         * @return alt devise id
         */
        public string GetAffiseAltDeviseId() => PlayerPrefs.GetString(AFF_ALT_DEVICE_ID, "");


        /**
         * Get random user id
         * @return random user id
         */
        public string getRandomUserId() => PlayerPrefs.GetString(Parameters.RANDOM_USER_ID, "");
    }
}