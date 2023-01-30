package com.affise.attribution.unity.ext;

import com.affise.attribution.events.predefined.TouchType;

public class TouchTypeExt {

    public static TouchType toTouchType(String value) {
        switch (value) {
            case "CLICK":
                return TouchType.CLICK;
            case "WEB_TO_APP_AUTO_REDIRECT":
                return TouchType.WEB_TO_APP_AUTO_REDIRECT;
            case "IMPRESSION":
                return TouchType.IMPRESSION;
        }
        return null;
    }
}
