//
//  ACRColumnView
//  ACRColumnView.h
//
//  Copyright © 2017 Microsoft. All rights reserved.
//
#import "ACRContentStackView.h"

@interface ACRColumnView : ACRContentStackView

typedef enum ACRColumnWidthPriority : NSInteger {
    ACRColumnWidthPriorityStretch = 249,
    ACRColumnWidthPriorityStretchAuto = 251,
    ACRColumnWidthPriorityAuto,
} ACRColumnWidthPriority;

@property NSString *columnWidth;
@property CGFloat pixelWidth;
@property BOOL hasStretchableView;
@property BOOL isLastColumn;

- (UIView *)addPaddingSpace;

@end
