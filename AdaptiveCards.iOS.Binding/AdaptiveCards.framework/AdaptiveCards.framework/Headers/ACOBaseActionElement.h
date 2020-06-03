//
//  ACOBaseActionElement
//  ACOBaseActionElement.h
//
//  Copyright © 2017 Microsoft. All rights reserved.
//

#import "ACOParseContext.h"
#import <Foundation/Foundation.h>

@class ACOFeatureRegistration;

@interface ACOBaseActionElement : NSObject

typedef enum ACRActionType: NSInteger {
    ACRShowCard = 1,
    ACRSubmit,
    ACROpenUrl,
    ACRToggleVisibility,
    ACRUnknownAction = 6,
} ACRActionType;

typedef enum ACRIconPlacement : NSInteger {
    ACRAboveTitle = 0,
    ACRLeftOfTitle,
    ACRNoTitle,
} ACRIconPlacement;

@property ACRActionType type;
@property NSString *sentiment;

- (NSString *)title;
- (NSString *)elementId;
- (NSString *)url;
- (NSString *)data;
- (NSData *)additionalProperty;

- (BOOL)meetsRequirements:(ACOFeatureRegistration *)featureReg;

@end

@protocol ACOIBaseActionElementParser

- (ACOBaseActionElement *)deserialize:(NSData *)json parseContext:(ACOParseContext *)parseContext;

@end
