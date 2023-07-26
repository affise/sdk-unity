using System;
using System.Collections.Generic;
using System.Globalization;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Events.Parameters;
using AffiseAttributionLib.Events.Predefined;
using AffiseAttributionLib.Events.Subscription;
using AffiseAttributionLib.Utils;
using SimpleJSON;
using UnityEngine;
using TouchType = AffiseAttributionLib.Events.Predefined.TouchType;

namespace AffiseDemo
{
    public class DefaultEventsFactory : MonoBehaviour
    {
        public List<AffiseEvent> CreateEvents()
        {
            return new List<AffiseEvent>()
            {
                CreateAchieveLevelEvent(),
                CreateAddPaymentInfoEvent(),
                CreateAddToCartEvent(),
                CreateAddToWishlistEvent(),
                CreateClickAdvEvent(),
                CreateCompleteRegistrationEvent(),
                CreateCompleteStreamEvent(),
                CreateCompleteTrialEvent(),
                CreateCompleteTutorialEvent(),
                CreateContactEvent(),
                CreateContentItemsViewEvent(),
                CreateCustomId01Event(),
                CreateCustomId02Event(),
                CreateCustomId03Event(),
                CreateCustomId04Event(),
                CreateCustomId05Event(),
                CreateCustomId06Event(),
                CreateCustomId07Event(),
                CreateCustomId08Event(),
                CreateCustomId09Event(),
                CreateCustomId10Event(),
                CreateCustomizeProductEvent(),
                CreateDeepLinkedEvent(),
                CreateDonateEvent(),
                CreateFindLocationEvent(),
                CreateInitiateCheckoutEvent(),
                CreateInitiatePurchaseEvent(),
                CreateInitiateStreamEvent(),
                CreateInviteEvent(),
                CreateLastAttributedTouchEvent(),
                CreateLeadEvent(),
                CreateListViewEvent(),
                CreateLoginEvent(),
                CreateOpenedFromPushNotificationEvent(),
                CreatePurchaseEvent(),
                CreateRateEvent(),
                CreateReEngageEvent(),
                CreateReserveEvent(),
                CreateScheduleEvent(),
                CreateSalesEvent(),
                CreateSearchEvent(),
                CreateShareEvent(),
                CreateSpendCreditsEvent(),
                CreateStartRegistrationEvent(),
                CreateStartTrialEvent(),
                CreateStartTutorialEvent(),
                CreateSubmitApplicationEvent(),
                CreateSubscribeEvent(),
                CreateTravelBookingEvent(),
                CreateUnlockAchievementEvent(),
                CreateUnsubscribeEvent(),
                CreateUpdateEvent(),
                CreateViewAdvEvent(),
                CreateViewContentEvent(),
                CreateViewCartEvent(),
                CreateViewItemEvent(),
                CreateViewItemsEvent(),

                CreateInitialSubscriptionEvent(),
                CreateInitialTrialEventEvent(),
                CreateInitialOfferEvent(),
                CreateFailedTrialEvent(),
                CreateFailedOfferiseEvent(),
                CreateFailedSubscriptionEvent(),
                CreateFailedTrialFromRetryEvent(),
                CreateFailedOfferFromRetryEvent(),
                CreateFailedSubscriptionFromRetryEvent(),
                CreateTrialInRetryEvent(),
                CreateOfferInRetryEvent(),
                CreateSubscriptionInRetryEvent(),
                CreateConvertedTrialEvent(),
                CreateConvertedOfferEvent(),
                CreateReactivatedSubscriptionEvent(),
                CreateRenewedSubscriptionEvent(),
                CreateConvertedTrialFromRetryEvent(),
                CreateConvertedOfferFromRetryEvent(),
                CreateRenewedSubscriptionFromRetryEvent(),
                CreateUnsubscriptionEvent(),
            };
        }

        private AffiseEvent CreateAchieveLevelEvent()
        {
            var level = new JSONObject
            {
                ["old_level"] = 69,
                ["new_level"] = 70
            };
            var affiseEvent = new AchieveLevelEvent(
                userData: "warlock"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.DEEP_LINK, "https://new-game.lt");
            affiseEvent.AddPredefinedParameter(PredefinedLong.SCORE, 25013L);
            affiseEvent.AddPredefinedParameter(PredefinedLong.LEVEL, 70L);
            affiseEvent.AddPredefinedParameter(PredefinedString.SUCCESS, "true");
            affiseEvent.AddPredefinedParameter(PredefinedString.TUTORIAL_ID, "12");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, level);

            return affiseEvent;
        }

        private AffiseEvent CreateAddPaymentInfoEvent()
        {
            var paymentInfo = new JSONObject
            {
                ["card"] = 4138,
                ["type"] = "phone"
            };

            var affiseEvent = new AddPaymentInfoEvent(
                userData: "taxi"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PURCHASE_CURRENCY, "USD");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, paymentInfo);

            return affiseEvent;
        }

        private AffiseEvent CreateAddToCartEvent()
        {
            var addToCartObject = new JSONObject
            {
                ["items"] = "milk",
            };

            var affiseEvent = new AddToCartEvent(
                userData: "cart"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.DESCRIPTION, "best before 2029");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, addToCartObject);

            return affiseEvent;
        }

        private AffiseEvent CreateAddToWishlistEvent()
        {
            var wishList = new JSONObject
            {
                ["items"] = "car",
            };

            var affiseEvent = new AddToWishlistEvent(
                userData: "next year"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.COUNTRY, "Russia");
            affiseEvent.AddPredefinedParameter(PredefinedString.CITY, "Voronezh");
            affiseEvent.AddPredefinedParameter(PredefinedFloat.LAT, 42);
            affiseEvent.AddPredefinedParameter(PredefinedFloat.LONG, 24);
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, wishList);

            return affiseEvent;
        }

        private AffiseEvent CreateClickAdvEvent()
        {
            var affiseEvent = new ClickAdvEvent(
                timeStampMillis: Timestamp.New(),
                userData: "header"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "PARAM_01");
            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_02, "PARAM_02");
            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_03, "PARAM_03");
            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_04, "PARAM_04");
            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_05, "PARAM_05");
            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_06, "PARAM_06");
            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_07, "PARAM_07");
            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_08, "PARAM_08");
            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_09, "PARAM_09");
            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_10, "PARAM_10");

            return affiseEvent;
        }

        private AffiseEvent CreateCompleteRegistrationEvent()
        {
            var registration = new JSONObject
            {
                ["email"] = "dog@gmail.com",
            };

            var affiseEvent = new CompleteRegistrationEvent(
                userData: "promo"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.VALIDATED, "02.11.2021");
            affiseEvent.AddPredefinedParameter(PredefinedString.REVIEW_TEXT, "approve");
            affiseEvent.AddPredefinedParameter(PredefinedString.CUSTOMER_SEGMENT, "DOG");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, registration);

            return affiseEvent;
        }

        private AffiseEvent CreateCompleteStreamEvent()
        {
            var stream = new JSONObject
            {
                ["streamer"] = "cat",
                ["max_viewers"] = "29",
            };

            var affiseEvent = new CompleteStreamEvent(
                userData: "23 hours"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, stream);

            return affiseEvent;
        }

        private AffiseEvent CreateCompleteTrialEvent()
        {
            var trial = new JSONObject
            {
                ["player"] = "ghost",
            };

            var affiseEvent = new CompleteTrialEvent(
                userData: "time"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.REGISTRATION_METHOD, "SMS");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, trial);

            return affiseEvent;
        }

        private AffiseEvent CreateCompleteTutorialEvent()
        {
            var tutorial = new JSONObject
            {
                ["name"] = "intro",
            };

            var affiseEvent = new CompleteTutorialEvent(
                userData: "intro"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.REGISTRATION_METHOD, "SMS");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, tutorial);

            return affiseEvent;
        }

        private AffiseEvent CreateContactEvent()
        {
            var affiseEvent = new ContactEvent(
                userData: "contact"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.REGISTRATION_METHOD, "SMS");

            return affiseEvent;
        }

        private AffiseEvent CreateContentItemsViewEvent()
        {
            var affiseEvent = new ContentItemsViewEvent(
                objects: new List<JSONObject>()
                {
                    new()
                    {
                        ["item"] = "book",
                    },
                    new()
                    {
                        ["item"] = "book",
                    },
                },
                userData: "intro"
            );

            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, new JSONObject
            {
                ["collection"] = "Greatest Hits"
            });
            affiseEvent.AddPredefinedParameter(PredefinedString.CONTENT_ID, "2561");
            affiseEvent.AddPredefinedParameter(PredefinedListObject.CONTENT_LIST, new List<JSONObject>()
            {
                new()
                {
                    ["content"] = "songs",
                },
                new()
                {
                    ["type"] = "videos",
                },
            });
            affiseEvent.AddPredefinedParameter(PredefinedListString.CONTENT_IDS, new List<string>()
            {
                "id_1", "id_2"
            });
            affiseEvent.AddPredefinedParameter(PredefinedString.CONTENT_TYPE, "MATURE");
            affiseEvent.AddPredefinedParameter(PredefinedString.CURRENCY, "USD");
            affiseEvent.AddPredefinedParameter(PredefinedLong.QUANTITY, 6L);
            affiseEvent.AddPredefinedParameter(PredefinedFloat.PRICE, 2.19f);

            return affiseEvent;
        }

        private AffiseEvent CreateCustomId01Event()
        {
            var affiseEvent = new CustomId01Event(
                userData: "custom"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1 Hits");

            return affiseEvent;
        }

        private AffiseEvent CreateCustomId02Event()
        {
            var affiseEvent = new CustomId02Event(
                userData: "custom"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1 Hits");

            return affiseEvent;
        }

        private AffiseEvent CreateCustomId03Event()
        {
            var affiseEvent = new CustomId03Event(
                userData: "custom"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1 Hits");

            return affiseEvent;
        }

        private AffiseEvent CreateCustomId04Event()
        {
            var affiseEvent = new CustomId04Event(
                userData: "custom"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1 Hits");

            return affiseEvent;
        }

        private AffiseEvent CreateCustomId05Event()
        {
            var affiseEvent = new CustomId05Event(
                userData: "custom"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1 Hits");

            return affiseEvent;
        }

        private AffiseEvent CreateCustomId06Event()
        {
            var affiseEvent = new CustomId06Event(
                userData: "custom"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1 Hits");

            return affiseEvent;
        }

        private AffiseEvent CreateCustomId07Event()
        {
            var affiseEvent = new CustomId07Event(
                userData: "custom"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1 Hits");

            return affiseEvent;
        }

        private AffiseEvent CreateCustomId08Event()
        {
            var affiseEvent = new CustomId08Event(
                userData: "custom"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1 Hits");

            return affiseEvent;
        }

        private AffiseEvent CreateCustomId09Event()
        {
            var affiseEvent = new CustomId09Event(
                userData: "custom"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1 Hits");

            return affiseEvent;
        }

        private AffiseEvent CreateCustomId10Event()
        {
            var affiseEvent = new CustomId10Event(
                userData: "custom"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1 Hits");

            return affiseEvent;
        }


        private AffiseEvent CreateCustomizeProductEvent()
        {
            var affiseEvent = new CustomizeProductEvent(
                userData: "Customize"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1");

            return affiseEvent;
        }

        private AffiseEvent CreateDeepLinkedEvent()
        {
            var affiseEvent = new DeepLinkedEvent(
                userData: "referrer: google"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.ADREV_AD_TYPE, "interstitial");
            affiseEvent.AddPredefinedParameter(PredefinedString.REGION, "ASIA");
            affiseEvent.AddPredefinedParameter(PredefinedString.CLASS, "student");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, new JSONObject
            {
                ["isLinked"] = true
            });

            return affiseEvent;
        }

        private AffiseEvent CreateDonateEvent()
        {
            var affiseEvent = new DonateEvent(
                userData: "Donate"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.ORDER_ID, "23123");
            affiseEvent.AddPredefinedParameter(PredefinedFloat.PRICE, 2.19f);
            affiseEvent.AddPredefinedParameter(PredefinedLong.QUANTITY, 1L);

            return affiseEvent;
        }

        private AffiseEvent CreateFindLocationEvent()
        {
            var affiseEvent = new FindLocationEvent(
                userData: "location"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.ORDER_ID, "23123");
            affiseEvent.AddPredefinedParameter(PredefinedFloat.PRICE, 2.19f);
            affiseEvent.AddPredefinedParameter(PredefinedLong.QUANTITY, 1L);

            return affiseEvent;
        }

        private AffiseEvent CreateInitiateCheckoutEvent()
        {
            var affiseEvent = new InitiateCheckoutEvent(
                userData: "checkout"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.ORDER_ID, "23123");
            affiseEvent.AddPredefinedParameter(PredefinedFloat.PRICE, 2.19f);
            affiseEvent.AddPredefinedParameter(PredefinedLong.QUANTITY, 1L);

            return affiseEvent;
        }

        private AffiseEvent CreateInitiatePurchaseEvent()
        {
            var purchaseData = new JSONObject
            {
                ["payment"] = "card",
            };

            var affiseEvent = new InitiatePurchaseEvent(
                userData: "best price"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.ORDER_ID, "23123");
            affiseEvent.AddPredefinedParameter(PredefinedFloat.PRICE, 2.19f);
            affiseEvent.AddPredefinedParameter(PredefinedLong.QUANTITY, 1L);
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, purchaseData);

            return affiseEvent;
        }

        private AffiseEvent CreateInitiateStreamEvent()
        {
            var stream = new JSONObject
            {
                ["streamer"] = "car",
                ["date"] = "02.03.2021",
            };
            var affiseEvent = new InitiateStreamEvent(
                userData: "shooter"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.COUPON_CODE, "25XLKM");
            affiseEvent.AddPredefinedParameter(PredefinedString.VIRTUAL_CURRENCY_NAME, "BTC");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, stream);

            return affiseEvent;
        }

        private AffiseEvent CreateInviteEvent()
        {
            var invite = new JSONObject
            {
                ["invitation"] = "mail",
                ["date"] = "02.03.2021",
            };
            var affiseEvent = new InviteEvent(
                userData: "dancing"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, invite);

            return affiseEvent;
        }

        private AffiseEvent CreateLastAttributedTouchEvent()
        {
            var touchData = new JSONObject
            {
                ["header"] = 2,
                ["touchType"] = TouchType.WEB_TO_APP_AUTO_REDIRECT.ToValue(),
            };

            var affiseEvent = new LastAttributedTouchEvent(
                userData: "tablet"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.SUBSCRIPTION_ID, "lasAK22");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, touchData);

            return affiseEvent;
        }

        private AffiseEvent CreateLeadEvent()
        {
            var affiseEvent = new LeadEvent(
                userData: "lead"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PAYMENT_INFO_AVAILABLE, "card");
            affiseEvent.AddPredefinedParameter(PredefinedString.SEARCH_STRING, "best car wash");

            return affiseEvent;
        }

        private AffiseEvent CreateListViewEvent()
        {
            var list = new JSONObject
            {
                ["clothes"] = 2,
            };

            var affiseEvent = new ListViewEvent(
                userData: "items"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PAYMENT_INFO_AVAILABLE, "card");
            affiseEvent.AddPredefinedParameter(PredefinedString.SEARCH_STRING, "best car wash");
            affiseEvent.AddPredefinedParameter(PredefinedString.SUGGESTED_DESTINATIONS, "crete, spain");
            affiseEvent.AddPredefinedParameter(PredefinedString.SUGGESTED_HOTELS, "beach resort, marina spa");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, list);

            return affiseEvent;
        }

        private AffiseEvent CreateLoginEvent()
        {
            var login = new JSONObject
            {
                ["email"] = "cat@gmail.com"
            };

            var affiseEvent = new LoginEvent(
                userData: "web"
            );

            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, login);

            return affiseEvent;
        }

        private AffiseEvent CreateOpenedFromPushNotificationEvent()
        {
            var affiseEvent = new OpenedFromPushNotificationEvent(
                userData: "active"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, new JSONObject
            {
                ["details"] = "silent"
            });
            return affiseEvent;
        }

        private AffiseEvent CreatePurchaseEvent()
        {
            var purchaseData = new JSONObject
            {
                ["phone"] = 1,
                ["case"] = 2,
            };

            var affiseEvent = new PurchaseEvent(
                userData: "items"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.ORDER_ID, "23123");
            affiseEvent.AddPredefinedParameter(PredefinedFloat.PRICE, 2.19f);
            affiseEvent.AddPredefinedParameter(PredefinedLong.QUANTITY, 1L);
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, purchaseData);

            return affiseEvent;
        }

        private AffiseEvent CreateRateEvent()
        {
            var rate = new JSONObject
            {
                ["rating"] = 5,
            };

            var affiseEvent = new RateEvent(
                userData: "no bugs"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PREFERRED_NEIGHBORHOODS, "2");
            affiseEvent.AddPredefinedParameter(PredefinedLong.PREFERRED_NUM_STOPS, 4L);
            affiseEvent.AddPredefinedParameter(PredefinedFloat.PREFERRED_PRICE_RANGE, 10.22f);
            affiseEvent.AddPredefinedParameter(PredefinedLong.PREFERRED_STAR_RATINGS, 6L);
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, rate);

            return affiseEvent;
        }

        private AffiseEvent CreateReEngageEvent()
        {
            var affiseEvent = new ReEngageEvent(
                userData: "web"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.CUSTOMER_USER_ID, "4");
            affiseEvent.AddPredefinedParameter(PredefinedString.VALIDATED, "data");

            return affiseEvent;
        }

        private AffiseEvent CreateReserveEvent()
        {
            var reserve = new List<JSONObject>()
            {
                new()
                {
                    ["item"] = "book",
                },
                new()
                {
                    ["item"] = "book",
                },
            };

            var affiseEvent = new ReserveEvent(
                userData: "web"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.CUSTOMER_USER_ID, "4");
            affiseEvent.AddPredefinedParameter(PredefinedListObject.CONTENT_LIST, reserve);

            return affiseEvent;
        }

        private AffiseEvent CreateScheduleEvent()
        {
            var affiseEvent = new ScheduleEvent(
                userData: "schedule"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.ORDER_ID, "23123");
            affiseEvent.AddPredefinedParameter(PredefinedFloat.PRICE, 2.19f);
            affiseEvent.AddPredefinedParameter(PredefinedLong.QUANTITY, 1L);

            return affiseEvent;
        }

        private AffiseEvent CreateSalesEvent()
        {
            var salesData = new JSONObject
            {
                ["phone"] = 1,
                ["case"] = 1,
            };

            var affiseEvent = new SalesEvent(
                userData: "apple"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.ORDER_ID, "23123");
            affiseEvent.AddPredefinedParameter(PredefinedFloat.PRICE, 2.19f);
            affiseEvent.AddPredefinedParameter(PredefinedLong.QUANTITY, 1L);
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, salesData);

            return affiseEvent;
        }

        private AffiseEvent CreateSearchEvent()
        {
            var arr = new JSONArray();
            arr.Add("eco milk");
            arr.Add("grass");

            var data = new JSONObject
            {
                ["data"] = arr
            };

            var affiseEvent = new SearchEvent(
                userData: "browser"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, data);

            return affiseEvent;
        }

        private AffiseEvent CreateShareEvent()
        {
            var share = new JSONObject
            {
                ["post_id"] = "252242",
                ["post_img"] = "img.webp",
            };

            var affiseEvent = new ShareEvent(
                userData: "telegram"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.RECEIPT_ID, "22");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, share);

            return affiseEvent;
        }

        private AffiseEvent CreateSpendCreditsEvent()
        {
            var affiseEvent = new SpendCreditsEvent(
                userData: "boosters"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1");
            affiseEvent.AddPredefinedParameter(PredefinedLong.QUANTITY, 2142);

            return affiseEvent;
        }

        private AffiseEvent CreateStartRegistrationEvent()
        {
            var registration = new JSONObject
            {
                ["time"] = "19:22:11",
            };

            var affiseEvent = new StartRegistrationEvent(
                userData: "referrer"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, registration);

            return affiseEvent;
        }

        private AffiseEvent CreateStartTrialEvent()
        {
            var trial = new JSONObject
            {
                ["time"] = "19:22:11",
            };

            var affiseEvent = new StartTrialEvent(
                userData: "30-days"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, trial);

            return affiseEvent;
        }

        private AffiseEvent CreateStartTutorialEvent()
        {
            var tutorial = new JSONObject
            {
                ["time"] = "19:22:11",
                ["reward"] = "22",
            };

            var affiseEvent = new StartTutorialEvent(
                userData: "video-feature"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, tutorial);

            return affiseEvent;
        }

        private AffiseEvent CreateSubmitApplicationEvent()
        {
            var affiseEvent = new SubmitApplicationEvent(
                userData: "submit"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1");

            return affiseEvent;
        }

        private AffiseEvent CreateSubscribeEvent()
        {
            var subscribe = new JSONObject
            {
                ["streamer"] = "cat",
            };

            var affiseEvent = new SubscribeEvent(
                userData: "wire"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, subscribe);

            return affiseEvent;
        }

        private AffiseEvent CreateTravelBookingEvent()
        {
            var arr = new JSONArray();
            arr.Add("may");
            arr.Add("august");

            var data = new JSONObject
            {
                ["months"] = arr
            };

            var affiseEvent = new TravelBookingEvent(
                userData: "booking"
            );

            affiseEvent.AddPredefinedParameter(PredefinedLong.NUM_ADULTS, 1L);
            affiseEvent.AddPredefinedParameter(PredefinedLong.NUM_CHILDREN, 2L);
            affiseEvent.AddPredefinedParameter(PredefinedLong.NUM_INFANTS, 1L);
            affiseEvent.AddPredefinedParameter(PredefinedLong.DATE_A, "30.12.2020".ToTimeStamp());
            affiseEvent.AddPredefinedParameter(PredefinedLong.DATE_B, "01.01.2021".ToTimeStamp());
            affiseEvent.AddPredefinedParameter(PredefinedLong.DEPARTING_ARRIVAL_DATE, "01.01.2021".ToTimeStamp());
            affiseEvent.AddPredefinedParameter(PredefinedLong.DEPARTING_DEPARTURE_DATE, "30.12.2020".ToTimeStamp());
            affiseEvent.AddPredefinedParameter(PredefinedString.DESTINATION_A, "usa");
            affiseEvent.AddPredefinedParameter(PredefinedString.DESTINATION_B, "mexico");
            affiseEvent.AddPredefinedParameter(PredefinedString.DESTINATION_LIST, "usa, mexico");
            affiseEvent.AddPredefinedParameter(PredefinedLong.HOTEL_SCORE, 5L);
            affiseEvent.AddPredefinedParameter(PredefinedLong.TRAVEL_START, "01.12.2020".ToTimeStamp());
            affiseEvent.AddPredefinedParameter(PredefinedLong.TRAVEL_END, "01.12.2021".ToTimeStamp());
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, data);

            return affiseEvent;
        }

        private AffiseEvent CreateUnlockAchievementEvent()
        {
            var achievement = new JSONObject
            {
                ["achievement"] = "new level",
            };

            var affiseEvent = new UnlockAchievementEvent(
                userData: "best damage"
            );

            affiseEvent.AddPredefinedParameter(PredefinedLong.USER_SCORE, 12552L);
            affiseEvent.AddPredefinedParameter(PredefinedString.ACHIEVEMENT_ID, "1334-1225-ASDZ");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, achievement);

            return affiseEvent;
        }

        private AffiseEvent CreateUnsubscribeEvent()
        {
            var unsubscribe = new JSONObject
            {
                ["reason"] = "span",
            };

            var affiseEvent = new UnsubscribeEvent(
                userData: "02.01.2021"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, unsubscribe);

            return affiseEvent;
        }

        private AffiseEvent CreateUpdateEvent()
        {
            var data = new JSONArray();
            data.Add("com.facebook");

            var affiseEvent = new UpdateEvent(
                userData: "firmware"
            );

            affiseEvent.AddPredefinedParameter(PredefinedLong.EVENT_START, "01.02.2021".ToTimeStamp());
            affiseEvent.AddPredefinedParameter(PredefinedLong.EVENT_END, "01.01.2022".ToTimeStamp());
            affiseEvent.AddPredefinedParameter(PredefinedString.NEW_VERSION, "8");
            affiseEvent.AddPredefinedParameter(PredefinedString.OLD_VERSION, "1.8");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, new JSONObject
            {
                ["data"] = data,
            });

            return affiseEvent;
        }

        private AffiseEvent CreateViewAdvEvent()
        {
            var ad = new JSONObject
            {
                ["source"] = "amazon",
            };

            var affiseEvent = new ViewAdvEvent(
                userData: "skip"
            );

            affiseEvent.AddPredefinedParameter(PredefinedLong.RETURNING_ARRIVAL_DATE, "01.12.2021".ToTimeStamp());
            affiseEvent.AddPredefinedParameter(PredefinedLong.RETURNING_DEPARTURE_DATE, "01.12.2020".ToTimeStamp());
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, ad);

            return affiseEvent;
        }

        private AffiseEvent CreateViewContentEvent()
        {
            var affiseEvent = new ViewContentEvent(
                userData: "ViewContent"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1");

            return affiseEvent;
        }

        private AffiseEvent CreateViewCartEvent()
        {
            var objects = new JSONObject
            {
                ["cart_value"] = "25.22$",
                ["cart_items"] = "2",
            };

            var affiseEvent = new ViewCartEvent(
                userData: "main"
            );

            affiseEvent.AddPredefinedParameter(PredefinedString.PARAM_01, "param1");
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, objects);

            return affiseEvent;
        }

        private AffiseEvent CreateViewItemEvent()
        {
            var item = new JSONObject
            {
                ["section_name"] = "header",
            };

            var affiseEvent = new ViewItemEvent(
                userData: "main"
            );

            affiseEvent.AddPredefinedParameter(PredefinedLong.MAX_RATING_VALUE, 5L);
            affiseEvent.AddPredefinedParameter(PredefinedLong.RATING_VALUE, 9L);
            affiseEvent.AddPredefinedParameter(PredefinedObject.CONTENT, item);

            return affiseEvent;
        }

        private AffiseEvent CreateViewItemsEvent()
        {
            var data = new List<JSONObject>
            {
                new JSONObject { ["section_name"] = "header" },
                new JSONObject { ["section_name"] = "section-1" },
                new JSONObject { ["section_name"] = "section-2" },
                new JSONObject { ["section_name"] = "footer" },
            };


            var affiseEvent = new ViewItemsEvent(
                userData: "main"
            );

            affiseEvent.AddPredefinedParameter(PredefinedLong.MAX_RATING_VALUE, 5L);
            affiseEvent.AddPredefinedParameter(PredefinedLong.RATING_VALUE, 9L);
            affiseEvent.AddPredefinedParameter(PredefinedListObject.CONTENT_LIST, data);

            return affiseEvent;
        }

        private AffiseEvent CreateInitialSubscriptionEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new InitialSubscriptionEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateInitialTrialEventEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new InitialTrialEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateInitialOfferEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new InitialOfferEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateFailedTrialEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new FailedTrialEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateFailedOfferiseEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new FailedOfferiseEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateFailedSubscriptionEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new FailedSubscriptionEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateFailedTrialFromRetryEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new FailedTrialFromRetryEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateFailedOfferFromRetryEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new FailedOfferFromRetryEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateFailedSubscriptionFromRetryEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new FailedSubscriptionFromRetryEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateTrialInRetryEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new TrialInRetryEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateOfferInRetryEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new OfferInRetryEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateSubscriptionInRetryEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new SubscriptionInRetryEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateConvertedTrialEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new ConvertedTrialEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateConvertedOfferEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new ConvertedOfferEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateReactivatedSubscriptionEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new ReactivatedSubscriptionEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateRenewedSubscriptionEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new RenewedSubscriptionEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateConvertedTrialFromRetryEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new ConvertedTrialFromRetryEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateConvertedOfferFromRetryEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new ConvertedOfferFromRetryEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateRenewedSubscriptionFromRetryEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new RenewedSubscriptionFromRetryEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }

        private AffiseEvent CreateUnsubscriptionEvent()
        {
            var data = new JSONObject
            {
                ["affise_event_revenue"] = 2.99,
                ["affise_event_currency"] = "USD",
                ["affise_event_product_id"] = 278459628375,
            };

            var affiseEvent = new UnsubscriptionEvent(
                data: data,
                userData: "Subscription Plus"
            );

            affiseEvent.AddPredefinedParameter(PredefinedFloat.REVENUE, 225522f);

            return affiseEvent;
        }
    }

    internal static class DateTimeExt
    {
        public static long ToTimeStamp(this string dateString)
        {
            var date = DateTime.ParseExact(dateString, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            return date.GetTimeInMillis();
        }
    }
}