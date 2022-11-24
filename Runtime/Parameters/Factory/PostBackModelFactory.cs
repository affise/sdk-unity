using System.Collections.Generic;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Logs;
using AffiseAttributionLib.Network.Entity;

namespace AffiseAttributionLib.AffiseParameters.Factory
{
    internal class PostBackModelFactory
    {
        private readonly UuidProvider _uuidProvider;
        private readonly AffiseAppIdProvider _affiseAppIdProvider;
        private readonly AffisePackageAppNameProvider _affisePkgAppNameProvider;
        private readonly AppVersionProvider _appVersionProvider;
        private readonly AppVersionRawProvider _appVersionRawProvider;
        private readonly StoreProvider _storeProvider;
        private readonly InstalledTimeProvider _installedTimeProvider;
        private readonly FirstOpenTimeProvider _firstOpenTimeProvider;
        private readonly InstalledHourProvider _installedHourProvider;
        private readonly FirstOpenHourProvider _firstOpenHourProvider;
        private readonly InstallFirstEventProvider _installFirstEventProvider;
        private readonly InstallBeginTimeProvider _installBeginTimeProvider;
        private readonly InstallFinishTimeProvider _installFinishTimeProvider;
        private readonly ReferrerInstallVersionProvider _referrerInstallVersionProvider;
        private readonly ReferrerClickTimestampProvider _referrerClickTimestampProvider;
        private readonly ReferrerClickTimestampServerProvider _referrerClickTimestampServerProvider;
        private readonly ReferrerGooglePlayInstantProvider _referrerGooglePlayInstantProvider;
        private readonly AffiseDeviceIdProvider _affDeviceIdProvider;
        private readonly AffiseAltDeviceIdProvider _affAltDeviceIdProvider;
        private readonly AndroidIdProvider _androidIdProvider;
        private readonly GoogleAdvertisingIdProvider _gaidAdidProvider;
        private readonly GoogleAdvertisingIdMd5Provider _gaidAdidMd5Provider;
        private readonly RefTokenProvider _reftokenProvider;
        private readonly InstallReferrerProvider _referrerProvider;
        private readonly UserAgentProvider _userAgentProvider;
        private readonly IspNameProvider _ispProvider;
        private readonly LanguageProvider _languageProvider;
        private readonly DeviceNameProvider _deviceNameProvider;
        private readonly DeviceTypeProvider _deviceTypeProvider;
        private readonly OsNameProvider _osNameProvider;
        private readonly PlatformNameProvider _platformProvider;
        private readonly ApiLevelOSProvider _apiLevelOsProvider;
        private readonly AffSDKVersionProvider _affSdkVersionProvider;
        private readonly OSVersionProvider _osVersionProvider;
        private readonly RandomUserIdProvider _randomUserIdProvider;
        private readonly TimezoneDeviceProvider _timezoneDevProvider;
        private readonly LastSessionTimeProvider _lastTimeSessionProvider;
        private readonly TimeSessionProvider _timeSessionProvider;
        private readonly AffiseSessionCountProvider _affSessionCountProvider;
        private readonly AffiseAppOpenedProvider _affAppOpenedProvider;
        private readonly LifetimeSessionCountProvider _lifetimeSessionCountProvider;
        private readonly DeeplinkProvider _affDeeplinkProvider;
        private readonly CreatedTimeProvider _createdTimeProvider;
        private readonly CreatedTimeMilliProvider _createdTimeMilliProvider;
        private readonly CreatedTimeHourProvider _createdTimeHourProvider;
        private readonly LastSessionTimeProvider _lastSessionTimeProvider;
        private readonly ConnectionTypeProvider _connectionTypeProvider;
        private readonly CpuTypeProvider _cpuTypeProvider;
        private readonly HardwareNameProvider _hardwareNameProvider;
        private readonly NetworkTypeProvider _networkTypeProvider;
        private readonly DeviceManufacturerProvider _deviceManufacturerProvider;
        private readonly DeeplinkClickPropertyProvider _deeplinkClickProvider;
        private readonly IsProductionPropertyProvider _affSdkPosProvider;
        private readonly AffPartParamNamePropertyProvider _affPartParamNameProvider;
        private readonly AffPartParamNameTokenPropertyProvider _affPartParamNameTokenProvider;
        private readonly AffAppTokenPropertyProvider _affAppTokenProvider;
        private readonly AffSDKSecretIdProvider _affsdkSecretIdProvider;
        private readonly PushTokenProvider _pushtokenProvider;

        public PostBackModelFactory(
            UuidProvider uuidProvider,
            AffiseAppIdProvider affiseAppIdProvider,
            AffisePackageAppNameProvider affisePkgAppNameProvider,
            AppVersionProvider appVersionProvider,
            AppVersionRawProvider appVersionRawProvider,
            StoreProvider storeProvider,
            InstalledTimeProvider installedTimeProvider,
            FirstOpenTimeProvider firstOpenTimeProvider,
            InstalledHourProvider installedHourProvider,
            FirstOpenHourProvider firstOpenHourProvider,
            InstallFirstEventProvider installFirstEventProvider,
            InstallBeginTimeProvider installBeginTimeProvider,
            InstallFinishTimeProvider installFinishTimeProvider,
            ReferrerInstallVersionProvider referrerInstallVersionProvider,
            ReferrerClickTimestampProvider referrerClickTimestampProvider,
            ReferrerClickTimestampServerProvider referrerClickTimestampServerProvider,
            ReferrerGooglePlayInstantProvider referrerGooglePlayInstantProvider,
            CreatedTimeProvider createdTimeProvider,
            CreatedTimeMilliProvider createdTimeMilliProvider,
            CreatedTimeHourProvider createdTimeHourProvider,
            LastSessionTimeProvider lastSessionTimeProvider,
            ConnectionTypeProvider connectionTypeProvider,
            CpuTypeProvider cpuTypeProvider,
            HardwareNameProvider hardwareNameProvider,
            NetworkTypeProvider networkTypeProvider,
            DeviceManufacturerProvider deviceManufacturerProvider,
            DeeplinkClickPropertyProvider deeplinkClickProvider,
            AffiseDeviceIdProvider affDeviceIdProvider,
            AffiseAltDeviceIdProvider affAltDeviceIdProvider,
            AndroidIdProvider androidIdProvider,
            GoogleAdvertisingIdProvider gaidAdidProvider,
            GoogleAdvertisingIdMd5Provider gaidAdidMd5Provider,
            RefTokenProvider reftokenProvider,
            InstallReferrerProvider referrerProvider,
            UserAgentProvider userAgentProvider,
            IspNameProvider ispProvider,
            LanguageProvider languageProvider,
            DeviceNameProvider deviceNameProvider,
            DeviceTypeProvider deviceTypeProvider,
            OsNameProvider osNameProvider,
            PlatformNameProvider platformProvider,
            ApiLevelOSProvider apiLevelOsProvider,
            AffSDKVersionProvider affSdkVersionProvider,
            OSVersionProvider osVersionProvider,
            RandomUserIdProvider randomUserIdProvider,
            IsProductionPropertyProvider affSdkPosProvider,
            TimezoneDeviceProvider timezoneDevProvider,
            LastSessionTimeProvider lastTimeSessionProvider,
            TimeSessionProvider timeSessionProvider,
            AffiseSessionCountProvider affSessionCountProvider,
            AffiseAppOpenedProvider affAppOpenedProvider,
            LifetimeSessionCountProvider lifetimeSessionCountProvider,
            DeeplinkProvider affDeeplinkProvider,
            AffPartParamNamePropertyProvider affPartParamNameProvider,
            AffPartParamNameTokenPropertyProvider affPartParamNameTokenProvider,
            AffAppTokenPropertyProvider affAppTokenProvider,
            AffSDKSecretIdProvider affsdkSecretIdProvider,
            PushTokenProvider pushtokenProvider
        )
        {
            _uuidProvider = uuidProvider;
            _affiseAppIdProvider = affiseAppIdProvider;
            _affisePkgAppNameProvider = affisePkgAppNameProvider;
            _appVersionProvider = appVersionProvider;
            _appVersionRawProvider = appVersionRawProvider;
            _storeProvider = storeProvider;
            _installedTimeProvider = installedTimeProvider;
            _firstOpenTimeProvider = firstOpenTimeProvider;
            _installedHourProvider = installedHourProvider;
            _firstOpenHourProvider = firstOpenHourProvider;
            _installFirstEventProvider = installFirstEventProvider;
            _installBeginTimeProvider = installBeginTimeProvider;
            _installFinishTimeProvider = installFinishTimeProvider;
            _referrerInstallVersionProvider = referrerInstallVersionProvider;
            _referrerClickTimestampProvider = referrerClickTimestampProvider;
            _referrerClickTimestampServerProvider = referrerClickTimestampServerProvider;
            _referrerGooglePlayInstantProvider = referrerGooglePlayInstantProvider;
            _createdTimeProvider = createdTimeProvider;
            _createdTimeMilliProvider = createdTimeMilliProvider;
            _createdTimeHourProvider = createdTimeHourProvider;
            _lastSessionTimeProvider = lastSessionTimeProvider;
            _connectionTypeProvider = connectionTypeProvider;
            _cpuTypeProvider = cpuTypeProvider;
            _hardwareNameProvider = hardwareNameProvider;
            _networkTypeProvider = networkTypeProvider;
            _deviceManufacturerProvider = deviceManufacturerProvider;
            _deeplinkClickProvider = deeplinkClickProvider;
            _affDeviceIdProvider = affDeviceIdProvider;
            _affAltDeviceIdProvider = affAltDeviceIdProvider;
            _androidIdProvider = androidIdProvider;
            _gaidAdidProvider = gaidAdidProvider;
            _gaidAdidMd5Provider = gaidAdidMd5Provider;
            _reftokenProvider = reftokenProvider;
            _referrerProvider = referrerProvider;
            _userAgentProvider = userAgentProvider;
            _ispProvider = ispProvider;
            _languageProvider = languageProvider;
            _deviceNameProvider = deviceNameProvider;
            _deviceTypeProvider = deviceTypeProvider;
            _osNameProvider = osNameProvider;
            _platformProvider = platformProvider;
            _apiLevelOsProvider = apiLevelOsProvider;
            _affSdkVersionProvider = affSdkVersionProvider;
            _osVersionProvider = osVersionProvider;
            _randomUserIdProvider = randomUserIdProvider;
            _timezoneDevProvider = timezoneDevProvider;
            _lastTimeSessionProvider = lastTimeSessionProvider;
            _timeSessionProvider = timeSessionProvider;
            _affSessionCountProvider = affSessionCountProvider;
            _affAppOpenedProvider = affAppOpenedProvider;
            _lifetimeSessionCountProvider = lifetimeSessionCountProvider;
            _affDeeplinkProvider = affDeeplinkProvider;
            _affSdkPosProvider = affSdkPosProvider;
            _affPartParamNameProvider = affPartParamNameProvider;
            _affPartParamNameTokenProvider = affPartParamNameTokenProvider;
            _affAppTokenProvider = affAppTokenProvider;
            _affsdkSecretIdProvider = affsdkSecretIdProvider;
            _pushtokenProvider = pushtokenProvider;
        }

        public PostBackModel Create(List<SerializedEvent> events, List<SerializedLog> logs)
        {
            var createdTime = _createdTimeProvider.ProvideWithDefault();
            var firstOpenTime = _firstOpenTimeProvider.ProvideWithDefault();
            var lastTimeSession = _lastTimeSessionProvider.ProvideWithDefault();
            if (!(lastTimeSession > 0))
            {
                lastTimeSession = firstOpenTime;
            }

            return new PostBackModel(
                uuid: _uuidProvider.ProvideWithDefault(),
                affiseAppId: _affiseAppIdProvider.ProvideWithDefault(),
                affisePkgAppName: _affisePkgAppNameProvider.ProvideWithDefault(),
                appVersion: _appVersionProvider.ProvideWithDefault(),
                appVersionRaw: _appVersionRawProvider.ProvideWithDefault(),
                store: _storeProvider.ProvideWithDefault(),
                installedTime: _installedTimeProvider.ProvideWithDefault(),
                firstOpenTime: firstOpenTime,
                installedHour: _installedHourProvider.ProvideWithDefault(),
                firstOpenHour: _firstOpenHourProvider.ProvideWithDefault(),
                installFirstEvent: _installFirstEventProvider.ProvideWithDefault(),
                installBeginTime: _installBeginTimeProvider.ProvideWithDefault(),
                installFinishTime: _installFinishTimeProvider.ProvideWithDefault(),
                referrerInstallVersion: _referrerInstallVersionProvider.ProvideWithDefault(),
                referrerClickTimestamp: _referrerClickTimestampProvider.ProvideWithDefault(),
                referrerClickTimestampServer: _referrerClickTimestampServerProvider.ProvideWithDefault(),
                referrerGooglePlayInstant: _referrerGooglePlayInstantProvider.ProvideWithDefault(),
                createdTime: createdTime,
                createdTimeMilli: _createdTimeMilliProvider.ProvideWithDefault(),
                createdTimeHour: _createdTimeHourProvider.ProvideWithDefault(),
                lastSessionTime: _lastSessionTimeProvider.ProvideWithDefault(),
                connectionType: _connectionTypeProvider.ProvideWithDefault(),
                cpuType: _cpuTypeProvider.ProvideWithDefault(),
                hardwareName: _hardwareNameProvider.ProvideWithDefault(),
                networkType: _networkTypeProvider.ProvideWithDefault(),
                deviceManufacturer: _deviceManufacturerProvider.ProvideWithDefault(),
                deeplinkClick: _deeplinkClickProvider.ProvideWithDefault(),
                affDeviceId: _affDeviceIdProvider.ProvideWithDefault(),
                affAltDeviceId: _affAltDeviceIdProvider.ProvideWithDefault(),
                androidId: _androidIdProvider.ProvideWithDefault(),
                gaidAdid: _gaidAdidProvider.ProvideWithDefault(),
                gaidAdidMd5: _gaidAdidMd5Provider.ProvideWithDefault(),
                reftoken: _reftokenProvider.ProvideWithDefault(),
                referrer: _referrerProvider.ProvideWithDefault(),
                userAgent: _userAgentProvider.ProvideWithDefault(),
                isp: _ispProvider.ProvideWithDefault(),
                language: _languageProvider.ProvideWithDefault(),
                deviceName: _deviceNameProvider.ProvideWithDefault(),
                deviceType: _deviceTypeProvider.ProvideWithDefault(),
                osName: _osNameProvider.ProvideWithDefault(),
                platform: _platformProvider.ProvideWithDefault(),
                apiLevelOs: _apiLevelOsProvider.ProvideWithDefault(),
                affSdkVersion: _affSdkVersionProvider.ProvideWithDefault(),
                osVersion: _osVersionProvider.ProvideWithDefault(),
                randomUserId: _randomUserIdProvider.ProvideWithDefault(),
                affSdkPos: _affSdkPosProvider.ProvideWithDefault(),
                timezoneDev: _timezoneDevProvider.ProvideWithDefault(),
                affAppToken: _affAppTokenProvider.ProvideWithParamAndDefault(createdTime.ToString()),
                lastTimeSession: lastTimeSession,
                timeSession: _timeSessionProvider.ProvideWithDefault(),
                affSessionCount: _affSessionCountProvider.ProvideWithDefault(),
                affAppOpened: _affAppOpenedProvider.ProvideWithDefault(),
                lifetimeSessionCount: _lifetimeSessionCountProvider.ProvideWithDefault(),
                affDeeplink: _affDeeplinkProvider.ProvideWithDefault(),
                affPartParamName: _affPartParamNameProvider.ProvideWithDefault(),
                affPartParamNameToken: _affPartParamNameTokenProvider.ProvideWithDefault(),
                affsdkSecretId: _affsdkSecretIdProvider.ProvideWithDefault(),
                pushtoken: _pushtokenProvider.ProvideWithDefault(),
                events: events,
                logs: logs
            );
        }
    }
}