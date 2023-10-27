func toString(_ raw: UnsafePointer<CChar>?) -> String? {
    guard let raw = raw else { return nil }
    return String(validatingUTF8: raw)
}

extension String {
    func toUnsafePointer() -> UnsafePointer<CChar>?  {
        let str = strdup(self)
        return UnsafePointer(str)
    }
}
