import AffiseAttributionLib


internal func toAffiseFlag(_ value: String?) -> AffiseFlag? {
   switch value {
   case "IOS_REQUEST_ADID": return AffiseFlag.IOS_REQUEST_ADID

   default:
       return nil
   }
}
