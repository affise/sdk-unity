import AffiseAttributionLib


internal protocol AffiseBaseEvens {
    func event(_ map: [String: Any?]?) -> Event?
}

internal class AffiseBaseEvensFactory {
    let KEY_SERIALIZE = "serialize"
    let KEY_USERDATA = "userData"
    let KEY_PREDEFINED_PARAMETERS = "predefinedParameters"
    let KEY_DATA = "data"

    func addPredefinedParameters<T: Event>(event: inout T, map: [String: Any?]?)  {
        for (key, value) in getPredefinedParameter(map) {
            if let param = toPredefinedParameters(key) {
                event.addPredefinedParameter(parameter: param, value: value)
            }
        }
    }

    func getPredefinedParameter(_ map: [String: Any?]?) -> [String: Any?]  {
        return map?[KEY_PREDEFINED_PARAMETERS] as? [String: Any?] ?? [:]
    }
    
    func getData(_ map: [String: Any?]?) -> [String: Any?]  {
        return map?[KEY_DATA] as? [String: Any?] ?? [:]
    }

    func getDataArray(_ map: [String: Any?]?) -> [(String, Any?)] {
        return mapToArray(getData(map))
    }
    
    func getSerialize(_ map: [String: Any?]?) -> [String: Any?] {
        return map?[KEY_SERIALIZE]  as? [String: Any?]  ?? [:]
    }

    func getSerializeByKey(_ map: [String: Any?]?, _ key: String) -> Any? {
        return getSerialize(map)[key] ?? nil
    }
    
    func getSerializeArrayOfAny(_ map: [String: Any?]?, _ key: String) -> [Any] {
        if let list = getSerializeByKey(map, key) as? [Any] {
            return list.map {
                if let subMap = $0 as? [String: Any?] {
                    return mapToArray(subMap)
                }
                return $0
            }
        }
        return []
    }

    func getSerializeArrayOfArray(_ map: [String: Any?]?, _ key: String) -> [[(String, Any?)]] {
        if let list = getSerializeByKey(map, key) as? [Any] {
            return list.map {
                if let subMap = $0 as? [String: Any?] {
                    return mapToArray(subMap)
                }
                return []
            }
        }
        return []
    }

    func getSerializeString(_ map: [String: Any?]?, _ key: String) -> String? {
        return getSerializeByKey(map, key) as? String
    }

    func getSerializeBool(_ map: [String: Any?]?, _ key: String) -> Bool {
        return getSerializeByKey(map, key) as? Bool ?? false
    }

    func getSerializeNumber(_ map: [String: Any?]?, _ key: String) -> NSNumber? {
        return getSerializeByKey(map, key) as? NSNumber
    }

    func getUserData(_ map: [String: Any?]?) -> String? {
        return map?[KEY_USERDATA] as? String
    }
    
    func mapToArray(_ map: [String: Any?]) -> [(String, Any?)] {
        return map.map {
            var value = $0.value
            if let subMap = value as? [String: Any?] {
                value = mapToArray(subMap)
            }
            return ($0.key, value)
        }
    }

    func getArrayOfData(_ map: [String: Any?]?, _ key: String) -> [(String, Any?)] {
        if let serialized = getSerializeByKey(map, key) as? [String: Any?] {
            return mapToArray(serialized)
        }
        return []
    }

    func getUserDataAndTimeStamp(_ map: [String: Any?]?, _ key: String) -> (Int64, String?) {
        var timeStamp: Int64 = 0
        if let val = getSerializeByKey(map, key) as? NSNumber {
            timeStamp = val.int64Value
        }
        let userData = getUserData(map)
        return (timeStamp, userData)
    }
}
