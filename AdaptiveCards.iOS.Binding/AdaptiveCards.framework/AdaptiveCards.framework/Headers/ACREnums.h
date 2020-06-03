//
//  ACREnums.h
//  AdaptiveCards
//
//  Copyright © 2020 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>

typedef enum ACRWarningStatusCode : NSUInteger {
    ACRUnknownElementType = 0,
    ACRUnknownActionElementType,
    ACRUnknownPropertyOnElement,
    ACRUnknownEnumValue,
    ACRNoRendererForType,
    ACRInteractivityNotSupported,
    ACRMaxActionsExceeded,
    ACRAssetLoadFailed,
    ACRUnsupportedSchemaVersion,
    ACRUnsupportedMediaType,
    ACRInvalidMediaMix,
    ACRInvalidColorFormat,
    ACRInvalidDimensionSpecified,
    ACRInvalidLanguage,
    ACRInvalidValue,
    ACRCustomWarning,
} ACRWarningStatusCode;
