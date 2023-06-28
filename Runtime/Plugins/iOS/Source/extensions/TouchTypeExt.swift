import AffiseAttributionLib


internal func toTouchType(_ value: String?) -> TouchType? {
    switch value {
    case "CLICK": return TouchType.CLICK
    case "WEB_TO_APP_AUTO_REDIRECT": return TouchType.WEB_TO_APP_AUTO_REDIRECT
    case "IMPRESSION": return TouchType.IMPRESSION
            
    default:
        return nil
    }
}
