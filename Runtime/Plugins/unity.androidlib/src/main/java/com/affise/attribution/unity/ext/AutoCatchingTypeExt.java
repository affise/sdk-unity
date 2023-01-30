package com.affise.attribution.unity.ext;

import com.affise.attribution.events.autoCatchingClick.AutoCatchingType;

public class AutoCatchingTypeExt {
    public static AutoCatchingType toAutoCatchingType(String value) {
        switch (value) {
            case "BUTTON":
                return AutoCatchingType.BUTTON;
            case "TEXT":
                return AutoCatchingType.TEXT;
            case "IMAGE_BUTTON":
                return AutoCatchingType.IMAGE_BUTTON;
            case "IMAGE":
                return AutoCatchingType.IMAGE;
            case "GROUP":
                return AutoCatchingType.GROUP;
        }
        return null;
    }
}
