internal extension Array where Element == Any?  {
    func toJson() -> String {
        let array: [String] = compactMap { value in
            if value == nil {
                return "null"
            } else if let other = value as? String {
                return "\"\(other)\""
            } else if let other = value as? Bool {
                return other ? "true" : "false"
            } else if let other = value as? NSNumber {
                return "\(other)"
            } else if let other = value as? [String: Any?] {
                return other.toJson()
            } else if let other = value as? [(String, Any?)] {
                return other.toJson()
            } else if let other = value as? [Any?] {
                return other.toJson()
            } else {
                return "\"\(String(describing: value))\""
            }
        }
        return "[\(array.joined(separator: ","))]"
    }
}

internal extension Dictionary where Key == String, Value == Any? {
    func toJson() -> String {
        return self.map{ ($0, $1)}.toJson()
    }
}

internal extension Array where Element == (String, Any?) {
    func toJson() -> String {
        let array: [String] = compactMap { (key, value) in
            guard let value = value else {
                return nil
            }
            if let value = value as? String, value.count > 0, value.first != "{" {
                return "\"\(key)\":\"\(value)\""
            } else if let value = value as? String, value.count == 0 {
                return "\"\(key)\":\"\""
            } else if let value = value as? [String], value.count > 0, value.first!.first != "{" {
                return "\"\(key)\":[\"\(value.joined(separator: "\",\""))\"]"
            } else if let value = value as? [String] {
                return "\"\(key)\":[\(value.joined(separator: ","))]"
            } else if let value = value as? [(String, Any?)] {
                return "\"\(key)\":\(value.jsonString())"
            } else if let value = value as? [[(String, Any?)]] {
                return "\"\(key)\":[\(value.map { $0.jsonString() }.joined(separator: ","))]"
            } else if let value = value as? [[String: Any?]] {
                return "\"\(key)\":[\(value.map { $0.map { ($0, $1) }.jsonString() }.joined(separator: ","))]"
            } else {
                return "\"\(key)\":\(value)"
            }
        }
        return "{\(array.joined(separator: ","))}"
    }
}
