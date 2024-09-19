# Changelog

## [1.6.22] - 2024-09-11

### Added

- Module `Subscription` support.

### Fixed

- Api callback executes on other thread.

### Changed

- Update native iOS to [`1.6.40`](https://github.com/affise/sdk-ios/blob/1.6.40/CHANGELOG.md).
- Update native Android to [`1.6.44`](https://github.com/affise/sdk-android/blob/v1.6.44/CHANGELOG.md).

## [1.6.21] - 2024-08-21

### Added

- iOS only api `Affise.IOS.GetReferrerOnServer`.
- iOS only api `Affise.IOS.GetReferrerOnServerValue`.

### Changed

- Api `Affise.GetReferrer` to `Affise.GetReferrerUrl`.
- Api `Affise.GetReferrerValue` to `Affise.GetReferrerUrlValue`.
- Update native iOS to [`1.6.39`](https://github.com/affise/sdk-ios/blob/1.6.39/CHANGELOG.md).
- Update native Android to [`1.6.42`](https://github.com/affise/sdk-android/blob/v1.6.42/CHANGELOG.md).

## [1.6.20] - 2024-07-31

### Added

- Modules compatibility check.

### Fixed

- Api `Affise.Module.GetStatus`.

### Changed

- Update native iOS to [`1.6.36`](https://github.com/affise/sdk-ios/blob/1.6.36/CHANGELOG.md).
- Update native Android to [`1.6.40`](https://github.com/affise/sdk-android/blob/v1.6.40/CHANGELOG.md).

## [1.6.19] - 2024-07-17

### Added

- Module `Link`
- Module `AndroidId`

### Changed

- Update native iOS to [`1.6.33`](https://github.com/affise/sdk-ios/blob/1.6.33/CHANGELOG.md).
- Update native Android to [`1.6.38`](https://github.com/affise/sdk-android/blob/v1.6.38/CHANGELOG.md).
- Update `RegisterDeeplinkCallback` change uri to convenient values.
- Update api `Affise.GetStatus` moved to `Affise.Module.GetStatus`.
- Update api `Affise.ModuleStart` moved to `Affise.Module.ModuleStart`.
- Update api `Affise.GetModulesInstalled` moved to `Affise.Module.GetModulesInstalled`.

## [1.6.18] - 2024-06-06

### Added

- Event api `SendNow`.
- Affise `internal` library group callback support.

### Removed

- Api `SendEvents`.

### Changed

- Update native iOS to [`1.6.32`](https://github.com/affise/sdk-ios/blob/1.6.32/CHANGELOG.md).
- Update native Android to [`1.6.34`](https://github.com/affise/sdk-android/blob/v1.6.34/CHANGELOG.md).

## [1.6.17] - 2024-03-14

### Added

- Api `IsFirstRun`.

### Changed

- Update native iOS to `1.6.27`.
- Update native Android to `1.6.26`.

## [1.6.16] - 2024-02-05

### Changed

- Update native iOS to `1.6.25`.

## [1.6.15] - 2024-02-01

### Added

- Settings `Deeplink`.

### Changed

- Update native iOS to `1.6.24`.
- Update native Android to `1.6.23`.

## [1.6.14] - 2023-12-29

### Added

- Settings `Modules`.
- Api `GetModulesInstalled`.
- New values in `ReferrerKey`.

## Deprecated

- Api `SendEvents`.

### Changed

- Update native iOS to `1.6.20`.
- Update native Android to `1.6.22`.
  
[1.6.22]: https://github.com/affise/sdk-unity/compare/1.6.21...1.6.22
[1.6.21]: https://github.com/affise/sdk-unity/compare/1.6.20...1.6.21
[1.6.20]: https://github.com/affise/sdk-unity/compare/1.6.19...1.6.20
[1.6.19]: https://github.com/affise/sdk-unity/compare/1.6.18...1.6.19
[1.6.18]: https://github.com/affise/sdk-unity/compare/1.6.17...1.6.18
[1.6.17]: https://github.com/affise/sdk-unity/compare/1.6.16...1.6.17
[1.6.16]: https://github.com/affise/sdk-unity/compare/1.6.15...1.6.16
[1.6.15]: https://github.com/affise/sdk-unity/compare/1.6.14...1.6.15
[1.6.14]: https://github.com/affise/sdk-unity/compare/1.6.13...1.6.14
