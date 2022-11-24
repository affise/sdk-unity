using AffiseAttributionLib.AffiseParameters.Factory;
using AffiseAttributionLib.Converter;
using AffiseAttributionLib.Deeplink;
using AffiseAttributionLib.Init;
using AffiseAttributionLib.Native;
using AffiseAttributionLib.Session;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib.AffiseParameters.Base
{
    internal class PropertiesProviderFactory
    {
        private readonly FirstAppOpenUseCase _firstAppOpenUseCase;
        private readonly ISessionManager _sessionManager;
        private readonly IInitPropertiesStorage _initPropertiesStorage;
        private readonly IConverter<string, string> _stringToSHA256Converter;
        private readonly IConverter<string, string> _stringToMd5Converter;
        private readonly INativeUseCase _nativeUseCase;
        private readonly IDeeplinkClickRepository _deeplinkClickRepository;
        private readonly InstallReferrerProvider _installReferrerProvider;

        public PropertiesProviderFactory(
            FirstAppOpenUseCase firstAppOpenUseCase,
            ISessionManager sessionManager,
            IInitPropertiesStorage initPropertiesStorage,
            IConverter<string, string> stringToSHA256Converter,
            IConverter<string, string> stringToMd5Converter,
            INativeUseCase nativeUseCase, 
            IDeeplinkClickRepository deeplinkClickRepository,
            InstallReferrerProvider installReferrerProvider
        )
        {
            _firstAppOpenUseCase = firstAppOpenUseCase;
            _sessionManager = sessionManager;
            _initPropertiesStorage = initPropertiesStorage;
            _stringToSHA256Converter = stringToSHA256Converter;
            _stringToMd5Converter = stringToMd5Converter;
            _nativeUseCase = nativeUseCase;
            _deeplinkClickRepository = deeplinkClickRepository;
            _installReferrerProvider = installReferrerProvider;
        }

        public PostBackModelFactory Create()
        {
            return new PostBackModelFactory(
                uuidProvider: new UuidProvider(),
                affiseAppIdProvider: new AffiseAppIdProvider(_initPropertiesStorage),
                affisePkgAppNameProvider: new AffisePackageAppNameProvider(),
                appVersionProvider: new AppVersionProvider(),
                appVersionRawProvider: new AppVersionRawProvider(),
                storeProvider: new StoreProvider(_nativeUseCase),
                installedTimeProvider: new InstalledTimeProvider(_nativeUseCase),
                firstOpenTimeProvider: new FirstOpenTimeProvider(_firstAppOpenUseCase),
                installedHourProvider: new InstalledHourProvider(_nativeUseCase),
                firstOpenHourProvider: new FirstOpenHourProvider(_firstAppOpenUseCase),
                installFirstEventProvider: new InstallFirstEventProvider(_firstAppOpenUseCase),
                installBeginTimeProvider: new InstallBeginTimeProvider(_nativeUseCase),
                installFinishTimeProvider: new InstallFinishTimeProvider(_firstAppOpenUseCase),
                referrerInstallVersionProvider: new ReferrerInstallVersionProvider(_nativeUseCase),
                referrerClickTimestampProvider: new ReferrerClickTimestampProvider(_nativeUseCase),
                referrerClickTimestampServerProvider: new ReferrerClickTimestampServerProvider(_nativeUseCase),
                referrerGooglePlayInstantProvider: new ReferrerGooglePlayInstantProvider(_nativeUseCase),
                createdTimeProvider: new CreatedTimeProvider(),
                createdTimeMilliProvider: new CreatedTimeMilliProvider(),
                createdTimeHourProvider: new CreatedTimeHourProvider(),
                lastSessionTimeProvider: new LastSessionTimeProvider(_sessionManager),
                connectionTypeProvider: new ConnectionTypeProvider(_nativeUseCase),
                cpuTypeProvider: new CpuTypeProvider(),
                hardwareNameProvider: new HardwareNameProvider(),
                networkTypeProvider: new NetworkTypeProvider(_nativeUseCase),
                deviceManufacturerProvider: new DeviceManufacturerProvider(_nativeUseCase),
                deeplinkClickProvider: new DeeplinkClickPropertyProvider(_deeplinkClickRepository),
                affDeviceIdProvider: new AffiseDeviceIdProvider(_firstAppOpenUseCase),
                affAltDeviceIdProvider: new AffiseAltDeviceIdProvider(_firstAppOpenUseCase),
                androidIdProvider: new AndroidIdProvider(_nativeUseCase),
                gaidAdidProvider: new GoogleAdvertisingIdProvider(_nativeUseCase),
                gaidAdidMd5Provider: new GoogleAdvertisingIdMd5Provider(_nativeUseCase, _stringToMd5Converter),
                reftokenProvider: new RefTokenProvider(),
                referrerProvider: _installReferrerProvider,
                userAgentProvider: new UserAgentProvider(),
                ispProvider: new IspNameProvider(_nativeUseCase),
                languageProvider: new LanguageProvider(),
                deviceNameProvider: new DeviceNameProvider(),
                deviceTypeProvider: new DeviceTypeProvider(),
                osNameProvider: new OsNameProvider(),
                platformProvider: new PlatformNameProvider(),
                apiLevelOsProvider: new ApiLevelOSProvider(_nativeUseCase),
                affSdkVersionProvider: new AffSDKVersionProvider(_initPropertiesStorage),
                osVersionProvider: new OSVersionProvider(_nativeUseCase),
                randomUserIdProvider: new RandomUserIdProvider(_firstAppOpenUseCase),
                affSdkPosProvider: new IsProductionPropertyProvider(_initPropertiesStorage),
                timezoneDevProvider: new TimezoneDeviceProvider(),
                lastTimeSessionProvider: new LastSessionTimeProvider(_sessionManager),
                timeSessionProvider: new TimeSessionProvider(_sessionManager),
                affSessionCountProvider: new AffiseSessionCountProvider(_sessionManager),
                affAppOpenedProvider: new AffiseAppOpenedProvider(_sessionManager),
                lifetimeSessionCountProvider: new LifetimeSessionCountProvider(_sessionManager),
                affDeeplinkProvider: new DeeplinkProvider(_deeplinkClickRepository),
                affPartParamNameProvider: new AffPartParamNamePropertyProvider(_initPropertiesStorage),
                affPartParamNameTokenProvider: new AffPartParamNameTokenPropertyProvider(_initPropertiesStorage),
                affAppTokenProvider: new AffAppTokenPropertyProvider(_initPropertiesStorage, _stringToSHA256Converter),
                affsdkSecretIdProvider: new AffSDKSecretIdProvider(_initPropertiesStorage),
                pushtokenProvider: new PushTokenProvider()
            );
        }
    }
}