//
//  ACRErrors
//  ACRErrors.h
//
//  Copyright © 2017 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>

extern NSString *const ACRInputErrorDomain;
extern NSString *const ACRParseErrorDomain;

typedef enum ACRInputError : NSUInteger {
    ACRInputErrorValueMissing,
    ACRInputErrorLessThanMin,
    ACRInputErrorGreaterThanMax,
    ACRInputErrorLessThanMinDate,
    ACRInputErrorGreaterThanMaxDate,
} ACRInputError;

typedef enum ACRRenderingStatus : NSUInteger {
    ACROk = 0,
    ACRFailed,
    ACRUnsupported,
} ACRRenderingStatus;

@interface ACOFallbackException : NSObject

+ (ACOFallbackException *)fallbackException;

@end
