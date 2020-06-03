using System;
using AVFoundation;
using AVKit;
using AdaptiveCards;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace AdaptiveCards.iOS.Binding
{
	[Static]
	partial interface Constants
	{
		// extern double AdaptiveCardsFrameworkVersionNumber;
		[Field ("AdaptiveCardsFrameworkVersionNumber", "__Internal")]
		double AdaptiveCardsFrameworkVersionNumber { get; }

		// extern const unsigned char [] AdaptiveCarsFrameworkVersionString;
		//[Field ("AdaptiveCarsFrameworkVersionString", "__Internal")]
		//string AdaptiveCarsFrameworkVersionString { get; }
	}

	// @interface ACRParseWarning : NSObject
	[BaseType (typeof(NSObject))]
	interface ACRParseWarning
	{
		// @property (readonly) ACRWarningStatusCode statusCode;
		[Export ("statusCode")]
		ACRWarningStatusCode StatusCode { get; }

		// @property (readonly) NSString * reason;
		[Export ("reason")]
		string Reason { get; }
	}

	// @interface ACOAdaptiveCardParseResult : NSObject
	[BaseType (typeof(NSObject))]
	interface ACOAdaptiveCardParseResult
	{
		// @property (readonly) ACOAdaptiveCard * card;
		[Export ("card")]
		ACOAdaptiveCard Card { get; }

		// @property (readonly) BOOL isValid;
		[Export ("isValid")]
		bool IsValid { get; }

		// @property (readonly) NSArray<NSError *> * parseErrors;
		[Export ("parseErrors")]
		NSError[] ParseErrors { get; }

		// @property (readonly) NSArray<ACRParseWarning *> * parseWarnings;
		[Export ("parseWarnings")]
		ACRParseWarning[] ParseWarnings { get; }

		// -(instancetype)init:(ACOAdaptiveCard *)card errors:(NSArray<NSError *> *)errors warnings:(NSArray<ACRParseWarning *> *)warnings;
		[Export ("init:errors:warnings:")]
		IntPtr Constructor (ACOAdaptiveCard card, NSError[] errors, ACRParseWarning[] warnings);
	}

	// @interface ACOParseContext : NSObject
	[BaseType (typeof(NSObject))]
	interface ACOParseContext
	{
	}

	// @interface ACOBaseCardElement : NSObject
	[BaseType (typeof(NSObject))]
	interface ACOBaseCardElement
	{
		// -(NSData *)additionalProperty;
		[Export ("additionalProperty")]
		NSData AdditionalProperty { get; }

		// @property ACRCardElementType type;
		[Export ("type", ArgumentSemantic.Assign)]
		ACRCardElementType Type { get; set; }

		// -(BOOL)meetsRequirements:(ACOFeatureRegistration *)featureReg;
		[Export ("meetsRequirements:")]
		bool MeetsRequirements (ACOFeatureRegistration featureReg);
	}

	// @protocol ACOIBaseCardElementParser
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[Model]
	[BaseType(typeof(NSObject))]
	interface ACOIBaseCardElementParser
	{
		// @required -(ACOBaseCardElement *)deserialize:(NSData *)json parseContext:(ACOParseContext *)parseContext;
		[Abstract]
		[Export ("deserialize:parseContext:")]
		ACOBaseCardElement ParseContext (NSData json, ACOParseContext parseContext);
	}

	// @interface ACORemoteResourceInformation : NSObject
	[BaseType (typeof(NSObject))]
	interface ACORemoteResourceInformation
	{
		// @property (readonly) NSURL * url;
		[Export ("url")]
		NSUrl Url { get; }

		// @property (readonly) NSString * mimeType;
		[Export ("mimeType")]
		string MimeType { get; }
	}

	// @interface ACOAdaptiveCard : NSObject
	[BaseType (typeof(NSObject))]
	interface ACOAdaptiveCard
	{
		// +(ACOAdaptiveCardParseResult *)fromJson:(NSString *)payload;
		[Static]
		[Export ("fromJson:")]
		ACOAdaptiveCardParseResult FromJson (string payload);

		// -(NSData *)inputs;
		[Export ("inputs")]
		NSData Inputs { get; }

		// -(NSArray *)getInputs;
		[Export("getInputs")]
		ACRIBaseInputHandler[] GetInputs();

		// -(void)setInputs:(NSArray *)inputs;
		[Export ("setInputs:")]
		void SetInputs (ACRIBaseInputHandler[] inputs);

		// -(void)appendInputs:(NSArray *)inputs;
		[Export ("appendInputs:")]
		void AppendInputs (ACRIBaseInputHandler[] inputs);

		// -(NSArray<ACORemoteResourceInformation *> *)remoteResourceInformation;
		[Export ("remoteResourceInformation")]
		ACORemoteResourceInformation[] RemoteResourceInformation { get; }
	}

	// @interface ACOHostConfigParseResult : NSObject
	[BaseType (typeof(NSObject))]
	interface ACOHostConfigParseResult
	{
		// @property (readonly) ACOHostConfig * config;
		[Export ("config")]
		ACOHostConfig Config { get; }

		// @property (readonly) BOOL isValid;
		[Export ("isValid")]
		bool IsValid { get; }

		// @property (readonly) NSArray<NSError *> * parseErrors;
		[Export ("parseErrors")]
		NSError[] ParseErrors { get; }

		// -(instancetype)init:(ACOHostConfig *)config errors:(NSArray<NSError *> *)errors;
		[Export ("init:errors:")]
		IntPtr Constructor (ACOHostConfig config, NSError[] errors);
	}

	// @protocol ACOIResourceResolver
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[Model]
	[BaseType(typeof(NSObject))]
	interface ACOIResourceResolver
	{
		// @optional -(UIImage *)resolveImageResource:(NSURL *)url;
		[Export ("resolveImageResource:")]
		UIImage ResolveImageResource (NSUrl url);

		// @optional -(UIImageView *)resolveImageViewResource:(NSURL *)url;
		[Export ("resolveImageViewResource:")]
		UIImageView ResolveImageViewResource (NSUrl url);

		// @optional -(UIImageView *)resolveBackgroundImageViewResource:(NSURL *)url hasStretch:(BOOL)hasStretch;
		[Export ("resolveBackgroundImageViewResource:hasStretch:")]
		UIImageView ResolveBackgroundImageViewResource (NSUrl url, bool hasStretch);
	}

	// @interface ACOResourceResolvers : NSObject
	[BaseType (typeof(NSObject))]
	interface ACOResourceResolvers
	{
		// -(ACOResolverIFType)getResolverIFType:(NSString *)scheme;
		[Export ("getResolverIFType:")]
		ACOResolverIFType GetResolverIFType (string scheme);

		// -(NSObject<ACOIResourceResolver> *)getResourceResolverForScheme:(NSString *)scheme;
		[Export ("getResourceResolverForScheme:")]
		ACOIResourceResolver GetResourceResolverForScheme (string scheme);

		// -(void)setResourceResolver:(NSObject<ACOIResourceResolver> *)resolver scheme:(NSString *)scheme;
		[Export ("setResourceResolver:scheme:")]
		void SetResourceResolver (ACOIResourceResolver resolver, string scheme);
	}

	// @interface ACOHostConfig : NSObject
	[BaseType (typeof(NSObject))]
	interface ACOHostConfig
	{
		// @property BOOL allActionsHaveIcons;
		[Export ("allActionsHaveIcons")]
		bool AllActionsHaveIcons { get; set; }

		// @property CGFloat buttonPadding;
		[Export ("buttonPadding")]
		nfloat ButtonPadding { get; set; }

		// @property ACOResourceResolvers * resolvers;
		[Export ("resolvers", ArgumentSemantic.Assign)]
		ACOResourceResolvers Resolvers { get; set; }

		// @property NSURL * baseURL;
		[Export ("baseURL", ArgumentSemantic.Assign)]
		NSUrl BaseURL { get; set; }

		// -(NSObject<ACOIResourceResolver> *)getResourceResolverForScheme:(NSString *)scheme;
		[Export ("getResourceResolverForScheme:")]
		ACOIResourceResolver GetResourceResolverForScheme (string scheme);

		// -(ACOResolverIFType)getResolverIFType:(NSString *)scheme;
		[Export ("getResolverIFType:")]
		ACOResolverIFType GetResolverIFType (string scheme);

		// +(ACOHostConfigParseResult *)fromJson:(NSString *)payload;
		[Static]
		[Export ("fromJson:")]
		ACOHostConfigParseResult FromJson (string payload);

		// +(ACOHostConfigParseResult *)fromJson:(NSString *)payload resourceResolvers:(ACOResourceResolvers *)resolvers;
		[Static]
		[Export ("fromJson:resourceResolvers:")]
		ACOHostConfigParseResult FromJson (string payload, ACOResourceResolvers resolvers);
	}

	// @interface ACOMediaSource : NSObject
	[BaseType (typeof(NSObject))]
	interface ACOMediaSource
	{
		// @property NSString * url;
		[Export ("url")]
		string Url { get; set; }

		// @property NSString * mimeType;
		[Export ("mimeType")]
		string MimeType { get; set; }

		// @property BOOL isVideo;
		[Export ("isVideo")]
		bool IsVideo { get; set; }

		// @property NSString * mediaFormat;
		[Export ("mediaFormat")]
		string MediaFormat { get; set; }

		// @property BOOL isValid;
		[Export ("isValid")]
		bool IsValid { get; set; }
	}

	// @interface ACOMediaEvent : NSObject
	[BaseType (typeof(NSObject))]
	interface ACOMediaEvent
	{
		// @property NSArray<ACOMediaSource *> * sources;
		[Export ("sources", ArgumentSemantic.Assign)]
		ACOMediaSource[] Sources { get; set; }

		// @property BOOL isValid;
		[Export ("isValid")]
		bool IsValid { get; set; }
	}

	// @interface ACOBaseActionElement : NSObject
	[BaseType (typeof(NSObject))]
	interface ACOBaseActionElement
	{
		// @property ACRActionType type;
		[Export ("type", ArgumentSemantic.Assign)]
		ACRActionType Type { get; set; }

		// @property NSString * sentiment;
		[Export ("sentiment")]
		string Sentiment { get; set; }

		// -(NSString *)title;
		[Export ("title")]
		string Title { get; }

		// -(NSString *)elementId;
		[Export ("elementId")]
		string ElementId { get; }

		// -(NSString *)url;
		[Export ("url")]
		string Url { get; }

		// -(NSString *)data;
		[Export ("data")]
		string Data { get; }

		// -(NSData *)additionalProperty;
		[Export ("additionalProperty")]
		NSData AdditionalProperty { get; }

		// -(BOOL)meetsRequirements:(ACOFeatureRegistration *)featureReg;
		[Export ("meetsRequirements:")]
		bool MeetsRequirements (ACOFeatureRegistration featureReg);
	}

	// @protocol ACOIBaseActionElementParser
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[Model]
	[BaseType(typeof(NSObject))]
	interface ACOIBaseActionElementParser
	{
		// @required -(ACOBaseActionElement *)deserialize:(NSData *)json parseContext:(ACOParseContext *)parseContext;
		[Abstract]
		[Export ("deserialize:parseContext:")]
		ACOBaseActionElement ParseContext (NSData json, ACOParseContext parseContext);
	}

	// @protocol ACRActionDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACRActionDelegate
	{
		// @required -(void)didFetchUserResponses:(ACOAdaptiveCard *)card action:(ACOBaseActionElement *)action;
		[Abstract]
		[Export ("didFetchUserResponses:action:")]
		void DidFetchUserResponses (ACOAdaptiveCard card, ACOBaseActionElement action);

		// @optional -(void)didLoadElements;
		[Export ("didLoadElements")]
		void DidLoadElements ();

		// @optional -(void)didChangeVisibility:(UIButton *)button isVisible:(BOOL)isVisible;
		[Export ("didChangeVisibility:isVisible:")]
		void DidChangeVisibility (UIButton button, bool isVisible);

		// @optional -(void)didChangeViewLayout:(CGRect)oldFrame newFrame:(CGRect)newFrame;
		[Export ("didChangeViewLayout:newFrame:")]
		void DidChangeViewLayout (CGRect oldFrame, CGRect newFrame);
	}

	// @interface ACOWarning : NSObject
	[BaseType (typeof(NSObject))]
	interface ACOWarning
	{
		// @property ACRWarningStatusCode statusCode;
		[Export ("statusCode", ArgumentSemantic.Assign)]
		ACRWarningStatusCode StatusCode { get; set; }

		// @property NSString * message;
		[Export ("message")]
		string Message { get; set; }

		// -(instancetype)initWith:(ACRWarningStatusCode)statusCode message:(NSString *)message;
		[Export ("initWith:message:")]
		IntPtr Constructor (ACRWarningStatusCode statusCode, string message);
	}

	// @protocol ACRIContentHoldingView
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
	[Model]
	[BaseType(typeof(NSObject))]
	interface ACRIContentHoldingView
	{
		// @required -(instancetype)initWithStyle:(ACRContainerStyle)style parentStyle:(ACRContainerStyle)parentStyle hostConfig:(ACOHostConfig *)config superview:(UIView<ACRIContentHoldingView> *)superview;
		[Export("initWithStyle:parentStyle:hostConfig:superview:")]
		IntPtr Constructor(ACRContainerStyle style, ACRContainerStyle parentStyle, ACOHostConfig config, ACRIContentHoldingView superview);

		// @required -(void)addArrangedSubview:(UIView *)view;
		[Abstract]
		[Export("addArrangedSubview:")]
		void AddArrangedSubview(UIView view);

		// @required -(void)removeLastViewFromArrangedSubview;
		[Abstract]
		[Export("removeLastViewFromArrangedSubview")]
		void RemoveLastViewFromArrangedSubview();

		// @required -(void)addTarget:(NSObject *)target;
		[Abstract]
		[Export("addTarget:")]
		void AddTarget(NSObject target);

		// @required -(void)adjustHuggingForLastElement;
		[Abstract]
		[Export("adjustHuggingForLastElement")]
		void AdjustHuggingForLastElement();

		// @required -(ACRContainerStyle)style;
		// @required -(void)setStyle:(ACRContainerStyle)stye;
		[Abstract]
		[Export("style")]
		ACRContainerStyle Style { get; set; }

		// @required -(void)hideAllShowCards;
		[Abstract]
		[Export("hideAllShowCards")]
		void HideAllShowCards();

		// @required -(NSUInteger)subviewsCounts;
		[Abstract]
		[Export("subviewsCounts")]
		nuint SubviewsCounts();

		// @required -(UIView *)getLastSubview;
		[Abstract]
		[Export("getLastSubview")]
		UIView GetLastSubview();
	}

	// @interface ACRContentStackView : UIView <ACRIContentHoldingView>
	[BaseType (typeof(UIView))]
	interface ACRContentStackView : ACRIContentHoldingView
	{
		// @property (weak) UIView * _Nullable backgroundView;
		[NullAllowed, Export ("backgroundView", ArgumentSemantic.Weak)]
		UIView BackgroundView { get; set; }

		// @property NSArray<NSLayoutConstraint *> * _Nonnull widthconstraint;
		[Export ("widthconstraint", ArgumentSemantic.Assign)]
		NSLayoutConstraint[] Widthconstraint { get; set; }

		// @property NSArray<NSLayoutConstraint *> * _Nonnull heightconstraint;
		[Export ("heightconstraint", ArgumentSemantic.Assign)]
		NSLayoutConstraint[] Heightconstraint { get; set; }

		// @property CGSize combinedContentSize;
		[Export ("combinedContentSize", ArgumentSemantic.Assign)]
		CGSize CombinedContentSize { get; set; }

		// @property UILayoutConstraintAxis axis;
		[Export ("axis", ArgumentSemantic.Assign)]
		UILayoutConstraintAxis Axis { get; set; }

		// @property UIStackViewDistribution distribution;
		[Export ("distribution", ArgumentSemantic.Assign)]
		UIStackViewDistribution Distribution { get; set; }

		// @property UIStackViewAlignment alignment;
		[Export ("alignment", ArgumentSemantic.Assign)]
		UIStackViewAlignment Alignment { get; set; }

		// @property BOOL isActionSet;
		[Export ("isActionSet")]
		bool IsActionSet { get; set; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame;
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame attributes:(NSDictionary<NSString *,id> * _Nullable)attributes;
		[Export ("initWithFrame:attributes:")]
		IntPtr Constructor (CGRect frame, [NullAllowed] NSDictionary<NSString, NSObject> attributes);

		// -(void)addArrangedSubview:(UIView * _Nonnull)view;
		[Export ("addArrangedSubview:")]
		void AddArrangedSubview (UIView view);

		// -(void)config:(NSDictionary<NSString *,id> * _Nullable)attributes;
		[Export ("config:")]
		void Config ([NullAllowed] NSDictionary<NSString, NSObject> attributes);

		// -(void)adjustHuggingForLastElement;
		[Export ("adjustHuggingForLastElement")]
		void AdjustHuggingForLastElement ();

		// -(void)addTarget:(NSObject * _Nonnull)target;
		[Export ("addTarget:")]
		void AddTarget (NSObject target);

		// -(void)applyPadding:(unsigned int)padding priority:(unsigned int)priority;
		[Export ("applyPadding:priority:")]
		void ApplyPadding (uint padding, uint priority);

		// -(void)applyPaddingToTop:(CGFloat)top left:(CGFloat)left bottom:(CGFloat)bottom right:(CGFloat)right priority:(unsigned int)priority location:(ACRBleedDirection)location;
		[Export ("applyPaddingToTop:left:bottom:right:priority:location:")]
		void ApplyPaddingToTop (nfloat top, nfloat left, nfloat bottom, nfloat right, uint priority, ACRBleedDirection location);

		// -(UIView * _Nullable)getLastArrangedSubview;
		[NullAllowed, Export ("getLastArrangedSubview")]
		UIView LastArrangedSubview { get; }

		// -(CGFloat)getMaxWidthOfSubviewsAfterExcluding:(UIView * _Nonnull)view;
		[Export ("getMaxWidthOfSubviewsAfterExcluding:")]
		nfloat GetMaxWidthOfSubviewsAfterExcluding (UIView view);

		// -(CGFloat)getMaxHeightOfSubviewsAfterExcluding:(UIView * _Nonnull)view;
		[Export ("getMaxHeightOfSubviewsAfterExcluding:")]
		nfloat GetMaxHeightOfSubviewsAfterExcluding (UIView view);

		// -(void)increaseIntrinsicContentSize:(UIView * _Nonnull)view;
		[Export ("increaseIntrinsicContentSize:")]
		void IncreaseIntrinsicContentSize (UIView view);

		// -(void)decreaseIntrinsicContentSize:(UIView * _Nonnull)view;
		[Export ("decreaseIntrinsicContentSize:")]
		void DecreaseIntrinsicContentSize (UIView view);

		// -(void)hideIfSubviewsAreAllHidden;
		[Export ("hideIfSubviewsAreAllHidden")]
		void HideIfSubviewsAreAllHidden ();

		// -(void)bleed:(unsigned int)padding priority:(unsigned int)priority target:(UIView * _Nonnull)target direction:(ACRBleedDirection)direction parentView:(UIView * _Nonnull)parent;
		[Export ("bleed:priority:target:direction:parentView:")]
		void Bleed (uint padding, uint priority, UIView target, ACRBleedDirection direction, UIView parent);

		// -(void)removeViewFromContentStackView:(UIView * _Nonnull)view;
		[Export ("removeViewFromContentStackView:")]
		void RemoveViewFromContentStackView (UIView view);
	}

	// @interface ACRColumnView : ACRContentStackView
	[BaseType (typeof(ACRContentStackView))]
	interface ACRColumnView
	{
		// @property NSString * columnWidth;
		[Export ("columnWidth")]
		string ColumnWidth { get; set; }

		// @property CGFloat pixelWidth;
		[Export ("pixelWidth")]
		nfloat PixelWidth { get; set; }

		// @property BOOL hasStretchableView;
		[Export ("hasStretchableView")]
		bool HasStretchableView { get; set; }

		// @property BOOL isLastColumn;
		[Export ("isLastColumn")]
		bool IsLastColumn { get; set; }

		// -(UIView *)addPaddingSpace;
		[Export ("addPaddingSpace")]
		UIView AddPaddingSpace { get; }
	}

	// @protocol ACRMediaDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACRMediaDelegate
	{
		// @required -(void)didFetchMediaViewController:(AVPlayerViewController *)controller card:(ACOAdaptiveCard *)card;
		[Abstract]
		[Export ("didFetchMediaViewController:card:")]
		void DidFetchMediaViewController (AVPlayerViewController controller, ACOAdaptiveCard card);

		// @optional -(void)didFetchMediaEvent:(ACOMediaEvent *)mediaElement card:(ACOAdaptiveCard *)card;
		[Export ("didFetchMediaEvent:card:")]
		void DidFetchMediaEvent (ACOMediaEvent mediaElement, ACOAdaptiveCard card);
	}

	// @interface ACRView : ACRColumnView
	[BaseType (typeof(ACRColumnView))]
	interface ACRView
	{
		[Wrap ("WeakAcrActionDelegate")]
		ACRActionDelegate AcrActionDelegate { get; set; }

		// @property (weak) id<ACRActionDelegate> acrActionDelegate;
		[NullAllowed, Export ("acrActionDelegate", ArgumentSemantic.Weak)]
		NSObject WeakAcrActionDelegate { get; set; }

		[Wrap ("WeakMediaDelegate")]
		ACRMediaDelegate MediaDelegate { get; set; }

		// @property (weak) id<ACRMediaDelegate> mediaDelegate;
		[NullAllowed, Export ("mediaDelegate", ArgumentSemantic.Weak)]
		NSObject WeakMediaDelegate { get; set; }

		// @property NSArray<ACOWarning *> * warnings;
		[Export ("warnings", ArgumentSemantic.Assign)]
		ACOWarning[] Warnings { get; set; }

		// -(instancetype)init:(ACOAdaptiveCard *)card hostconfig:(ACOHostConfig *)config widthConstraint:(float)width;
		[Export ("init:hostconfig:widthConstraint:")]
		IntPtr Constructor (ACOAdaptiveCard card, ACOHostConfig config, float width);

		// -(instancetype)init:(ACOAdaptiveCard *)card hostconfig:(ACOHostConfig *)config widthConstraint:(float)width delegate:(id<ACRActionDelegate>)acrActionDelegate;
		[Export ("init:hostconfig:widthConstraint:delegate:")]
		IntPtr Constructor (ACOAdaptiveCard card, ACOHostConfig config, float width, ACRActionDelegate acrActionDelegate);

		// -(NSMutableDictionary *)getImageMap;
		[Export ("getImageMap")]
		NSMutableDictionary ImageMap { get; }

		// -(UIImageView *)getImageView:(NSString *)key;
		[Export ("getImageView:")]
		UIImageView GetImageView (string key);

		// -(void)setImageView:(NSString *)key view:(UIView *)view;
		[Export ("setImageView:view:")]
		void SetImageView (string key, UIView view);

		// -(dispatch_queue_t)getSerialQueue;
		[Export ("getSerialQueue")]
		DispatchQueue SerialQueue { get; }

		// -(NSMutableDictionary *)getTextMap;
		[Export ("getTextMap")]
		NSMutableDictionary TextMap { get; }

		// -(ACOAdaptiveCard *)card;
		[Export ("card")]
		ACOAdaptiveCard Card { get; }

		// -(UIView *)render;
		[Export ("render")]
		UIView Render { get; }

		// -(void)waitForAsyncTasksToFinish;
		[Export ("waitForAsyncTasksToFinish")]
		void WaitForAsyncTasksToFinish ();
	}

	// @protocol ACRIBaseActionElementRenderer
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[Model]
	[BaseType(typeof(NSObject))]
	interface ACRIBaseActionElementRenderer
	{
		// @required -(UIButton *)renderButton:(ACRView *)rootView inputs:(NSMutableArray *)inputs superview:(UIView *)superview baseActionElement:(ACOBaseActionElement *)acoElem hostConfig:(ACOHostConfig *)acoConfig;
		[Abstract]
		[Export ("renderButton:inputs:superview:baseActionElement:hostConfig:")]
		UIButton Inputs (ACRView rootView, NSMutableArray inputs, UIView superview, ACOBaseActionElement acoElem, ACOHostConfig acoConfig);
	}

	// @protocol ACRIBaseActionSetRenderer
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[Model]
	[BaseType(typeof(NSObject))]
	interface ACRIBaseActionSetRenderer
	{
		// @required -(UIView *)renderButtons:(ACRView *)rootView inputs:(NSMutableArray *)inputs superview:(UIView<ACRIContentHoldingView> *)superview card:(ACOAdaptiveCard *)card hostConfig:(ACOHostConfig *)config;
		[Abstract]
		[Export ("renderButtons:inputs:superview:card:hostConfig:")]
		UIView Inputs (ACRView rootView, NSMutableArray inputs, ACRIContentHoldingView superview, ACOAdaptiveCard card, ACOHostConfig config);
	}

	// @interface ACRBaseActionElementRenderer : NSObject <ACRIBaseActionElementRenderer>
	[BaseType (typeof(NSObject))]
	interface ACRBaseActionElementRenderer : ACRIBaseActionElementRenderer
	{
	}

	// @interface ACRActionOpenURLRenderer : ACRBaseActionElementRenderer
	[BaseType (typeof(ACRBaseActionElementRenderer))]
	interface ACRActionOpenURLRenderer
	{
		// +(ACRActionOpenURLRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRActionOpenURLRenderer Instance { get; }
	}

	// @interface ACRActionShowCardRenderer : ACRBaseActionElementRenderer
	[BaseType (typeof(ACRBaseActionElementRenderer))]
	interface ACRActionShowCardRenderer
	{
		// +(ACRActionShowCardRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRActionShowCardRenderer Instance { get; }
	}

	// @interface ACRActionSubmitRenderer : ACRBaseActionElementRenderer
	[BaseType (typeof(ACRBaseActionElementRenderer))]
	interface ACRActionSubmitRenderer
	{
		// +(ACRActionSubmitRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRActionSubmitRenderer Instance { get; }
	}

	// @protocol ACRIBaseCardElementRenderer
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[Model]
	[BaseType(typeof(NSObject))]
	interface ACRIBaseCardElementRenderer
	{
		// @required +(ACRCardElementType)elemType;
		[Static, Abstract]
		[Export ("elemType")]
		ACRCardElementType ElemType { get; }

		// @required -(UIView *)render:(UIView<ACRIContentHoldingView> *)viewGroup rootView:(ACRView *)rootView inputs:(NSMutableArray *)inputs baseCardElement:(ACOBaseCardElement *)acoElem hostConfig:(ACOHostConfig *)acoConfig;
		[Abstract]
		[Export ("render:rootView:inputs:baseCardElement:hostConfig:")]
		UIView RootView (ACRIContentHoldingView viewGroup, ACRView rootView, NSMutableArray inputs, ACOBaseCardElement acoElem, ACOHostConfig acoConfig);
	}

	// @protocol ACRIKVONotificationHandler
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[Model]
	[BaseType(typeof(NSObject))]
	interface ACRIKVONotificationHandler
	{
		// @required -(void)configUpdateForUIImageView:(ACOBaseCardElement *)acoElem config:(ACOHostConfig *)acoConfig image:(UIImage *)image imageView:(UIImageView *)imageView;
		[Abstract]
		[Export ("configUpdateForUIImageView:config:image:imageView:")]
		void Config (ACOBaseCardElement acoElem, ACOHostConfig acoConfig, UIImage image, UIImageView imageView);
	}

	// @interface ACRBaseCardElementRenderer : NSObject <ACRIBaseCardElementRenderer>
	[BaseType (typeof(NSObject))]
	interface ACRBaseCardElementRenderer : ACRIBaseCardElementRenderer
	{
		// -(void)setSeparationConfig:(UIView *)viewGroup;
		[Export ("setSeparationConfig:")]
		void SetSeparationConfig (UIView viewGroup);

		// +(void)applyLayoutStyle:(NSString *)styleFormat viewsMap:(NSDictionary *)viewsMap;
		[Static]
		[Export ("applyLayoutStyle:viewsMap:")]
		void ApplyLayoutStyle (string styleFormat, NSDictionary viewsMap);
	}

	// @interface ACRButton : UIButton
	[BaseType (typeof(UIButton))]
	interface ACRButton
	{
		// @property NSNumber * positiveUseDefault;
		[Export ("positiveUseDefault", ArgumentSemantic.Assign)]
		NSNumber PositiveUseDefault { get; set; }

		// @property UIColor * positiveForegroundColor;
		[Export ("positiveForegroundColor", ArgumentSemantic.Assign)]
		UIColor PositiveForegroundColor { get; set; }

		// @property UIColor * positiveBackgroundColor;
		[Export ("positiveBackgroundColor", ArgumentSemantic.Assign)]
		UIColor PositiveBackgroundColor { get; set; }

		// @property NSNumber * destructiveUseDefault;
		[Export ("destructiveUseDefault", ArgumentSemantic.Assign)]
		NSNumber DestructiveUseDefault { get; set; }

		// @property UIColor * destructiveForegroundColor;
		[Export ("destructiveForegroundColor", ArgumentSemantic.Assign)]
		UIColor DestructiveForegroundColor { get; set; }

		// @property UIColor * destructiveBackgroundColor;
		[Export ("destructiveBackgroundColor", ArgumentSemantic.Assign)]
		UIColor DestructiveBackgroundColor { get; set; }

		// @property NSString * sentiment;
		[Export ("sentiment")]
		string Sentiment { get; set; }

		// @property UIColor * defaultPositiveBackgroundColor;
		[Export ("defaultPositiveBackgroundColor", ArgumentSemantic.Assign)]
		UIColor DefaultPositiveBackgroundColor { get; set; }

		// @property UIColor * defaultDestructiveForegroundColor;
		[Export ("defaultDestructiveForegroundColor", ArgumentSemantic.Assign)]
		UIColor DefaultDestructiveForegroundColor { get; set; }

		// @property ACRIconPlacement iconPlacement;
		[Export ("iconPlacement", ArgumentSemantic.Assign)]
		ACRIconPlacement IconPlacement { get; set; }

		// +(UIButton *)rootView:(ACRView *)rootView baseActionElement:(ACOBaseActionElement *)acoAction title:(NSString *)title andHostConfig:(ACOHostConfig *)config;
		[Static]
		[Export ("rootView:baseActionElement:title:andHostConfig:")]
		UIButton RootView (ACRView rootView, ACOBaseActionElement acoAction, string title, ACOHostConfig config);

		// -(void)setImageView:(UIImage *)image withConfig:(ACOHostConfig *)config;
		[Export ("setImageView:withConfig:")]
		void SetImageView (UIImage image, ACOHostConfig config);

		// -(void)applySentimentStyling;
		[Export ("applySentimentStyling")]
		void ApplySentimentStyling ();
	}

	// @interface ACRColumnRenderer : ACRBaseCardElementRenderer <ACRIKVONotificationHandler>
	[BaseType (typeof(ACRBaseCardElementRenderer))]
	interface ACRColumnRenderer : ACRIKVONotificationHandler
	{
		// @property BOOL fillAlignment;
		[Export ("fillAlignment")]
		bool FillAlignment { get; set; }

		// +(ACRColumnRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRColumnRenderer Instance { get; }

		// -(void)configUpdateForUIImageView:(ACOBaseCardElement *)acoElem config:(ACOHostConfig *)acoConfig image:(UIImage *)image imageView:(UIImageView *)imageView;
		[Export ("configUpdateForUIImageView:config:image:imageView:")]
		void ConfigUpdateForUIImageView (ACOBaseCardElement acoElem, ACOHostConfig acoConfig, UIImage image, UIImageView imageView);
	}

	// @interface ACRColumnSetRenderer : ACRBaseCardElementRenderer
	[BaseType (typeof(ACRBaseCardElementRenderer))]
	interface ACRColumnSetRenderer
	{
		// +(ACRColumnSetRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRColumnSetRenderer Instance { get; }
	}

	// @interface ACRContainerRenderer : ACRBaseCardElementRenderer <ACRIKVONotificationHandler>
	[BaseType (typeof(ACRBaseCardElementRenderer))]
	interface ACRContainerRenderer : ACRIKVONotificationHandler
	{
		// +(ACRContainerRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRContainerRenderer Instance { get; }

		// -(void)configUpdateForUIImageView:(ACOBaseCardElement *)acoElem config:(ACOHostConfig *)acoConfig image:(UIImage *)image imageView:(UIImageView *)imageView;
		[Export ("configUpdateForUIImageView:config:image:imageView:")]
		void ConfigUpdateForUIImageView (ACOBaseCardElement acoElem, ACOHostConfig acoConfig, UIImage image, UIImageView imageView);
	}

	partial interface Constants
	{
		// extern const NSInteger eACRUILabelTag;
		[Field ("eACRUILabelTag", "__Internal")]
		nint eACRUILabelTag { get; }

		// extern const NSInteger eACRUIFactSetTag;
		[Field ("eACRUIFactSetTag", "__Internal")]
		nint eACRUIFactSetTag { get; }

		// extern const NSInteger eACRUIImageTag;
		[Field ("eACRUIImageTag", "__Internal")]
		nint eACRUIImageTag { get; }
	}

	// @interface ACRContentHoldingUIView : UIView
	[BaseType (typeof(UIView))]
	interface ACRContentHoldingUIView
	{
		// @property CGSize desiredContentSize;
		[Export ("desiredContentSize", ArgumentSemantic.Assign)]
		CGSize DesiredContentSize { get; set; }

		// @property BOOL isPersonStyle;
		[Export ("isPersonStyle")]
		bool IsPersonStyle { get; set; }

		// @property BOOL hidePlayIcon;
		[Export ("hidePlayIcon")]
		bool HidePlayIcon { get; set; }

		// @property BOOL isMediaType;
		[Export ("isMediaType")]
		bool IsMediaType { get; set; }
	}

	partial interface Constants
	{
		// extern NSString *const ACRInputErrorDomain;
		[Field ("ACRInputErrorDomain", "__Internal")]
		NSString ACRInputErrorDomain { get; }

		// extern NSString *const ACRParseErrorDomain;
		[Field ("ACRParseErrorDomain", "__Internal")]
		NSString ACRParseErrorDomain { get; }
	}

	// @interface ACOFallbackException : NSObject
	[BaseType (typeof(NSObject))]
	interface ACOFallbackException
	{
		// +(ACOFallbackException *)fallbackException;
		[Static]
		[Export ("fallbackException")]
		ACOFallbackException FallbackException { get; }
	}

	// @interface ACRFactSetRenderer : ACRBaseCardElementRenderer
	[BaseType (typeof(ACRBaseCardElementRenderer))]
	interface ACRFactSetRenderer
	{
		// +(ACRFactSetRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRFactSetRenderer Instance { get; }
	}

	// @protocol ACRIBaseInputHandler
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	[Model]
	[BaseType(typeof(NSObject))]
	interface ACRIBaseInputHandler
	{
		// @required -(BOOL)validate:(NSError **)error;
		[Abstract]
		[Export ("validate:")]
		bool Validate (out NSError error);

		// @required -(void)getInput:(NSMutableDictionary *)dictionary;
		[Abstract]
		[Export ("getInput:")]
		void GetInput (NSMutableDictionary dictionary);
	}

	// @interface ACRImageRenderer : ACRBaseCardElementRenderer <ACRIKVONotificationHandler>
	[BaseType (typeof(ACRBaseCardElementRenderer))]
	interface ACRImageRenderer : ACRIKVONotificationHandler
	{
		// +(ACRImageRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRImageRenderer Instance { get; }

		// -(void)configUpdateForUIImageView:(ACOBaseCardElement *)acoElem config:(ACOHostConfig *)acoConfig image:(UIImage *)image imageView:(UIImageView *)imageView;
		[Export ("configUpdateForUIImageView:config:image:imageView:")]
		void ConfigUpdateForUIImageView (ACOBaseCardElement acoElem, ACOHostConfig acoConfig, UIImage image, UIImageView imageView);
	}

	// @interface ACRImageSetRenderer : ACRBaseCardElementRenderer
	[BaseType (typeof(ACRBaseCardElementRenderer))]
	interface ACRImageSetRenderer
	{
		// +(ACRImageSetRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRImageSetRenderer Instance { get; }
	}

	// @interface ACRInputChoiceSetRenderer : ACRBaseCardElementRenderer
	[BaseType (typeof(ACRBaseCardElementRenderer))]
	interface ACRInputChoiceSetRenderer
	{
		// +(ACRInputChoiceSetRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRInputChoiceSetRenderer Instance { get; }
	}

	// @interface ACRInputDateRenderer : ACRBaseCardElementRenderer
	[BaseType (typeof(ACRBaseCardElementRenderer))]
	interface ACRInputDateRenderer
	{
		// +(ACRInputDateRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRInputDateRenderer Instance { get; }
	}

	// @interface ACRInputNumberRenderer : ACRBaseCardElementRenderer
	[BaseType (typeof(ACRBaseCardElementRenderer))]
	interface ACRInputNumberRenderer
	{
		// +(ACRInputNumberRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRInputNumberRenderer Instance { get; }
	}

	// @interface ACRInputRenderer : ACRBaseCardElementRenderer
	[BaseType (typeof(ACRBaseCardElementRenderer))]
	interface ACRInputRenderer
	{
		// +(ACRInputRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRInputRenderer Instance { get; }
	}

	// @interface ACRInputTimeRenderer : ACRBaseCardElementRenderer
	[BaseType (typeof(ACRBaseCardElementRenderer))]
	interface ACRInputTimeRenderer
	{
		// +(ACRInputTimeRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRInputTimeRenderer Instance { get; }
	}

	// @interface ACRInputToggleRenderer : ACRBaseCardElementRenderer
	[BaseType (typeof(ACRBaseCardElementRenderer))]
	interface ACRInputToggleRenderer
	{
		// +(ACRInputToggleRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRInputToggleRenderer Instance { get; }
	}

	// @interface ACRMediaRenderer : ACRBaseCardElementRenderer <ACRIKVONotificationHandler>
	[BaseType (typeof(ACRBaseCardElementRenderer))]
	interface ACRMediaRenderer : ACRIKVONotificationHandler
	{
		// +(ACRMediaRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRMediaRenderer Instance { get; }
	}

	// @protocol ACRSelectActionDelegate
	[Protocol]
	[Model]
	[BaseType(typeof(NSObject))]
	interface ACRSelectActionDelegate
	{
		// @required -(void)doSelectAction;
		[Abstract]
		[Export ("doSelectAction")]
		void DoSelectAction ();
	}

	// @interface ACRLongPressGestureRecognizerEventHandler : NSObject <UIGestureRecognizerDelegate>
	[BaseType (typeof(NSObject))]
	interface ACRLongPressGestureRecognizerEventHandler : IUIGestureRecognizerDelegate
	{
		[Wrap ("WeakDelegate")]
		ACRSelectActionDelegate Delegate { get; set; }

		// @property (weak) id<ACRSelectActionDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)processLongPressGesture:(UILongPressGestureRecognizer *)recognizer __attribute__((ibaction));
		[Export ("processLongPressGesture:")]
		void ProcessLongPressGesture (UILongPressGestureRecognizer recognizer);
	}

	partial interface Constants
	{
		// extern const int playIconTag;
		[Field ("playIconTag", "__Internal")]
		int playIconTag { get; }

		// extern const int posterTag;
		[Field ("posterTag", "__Internal")]
		int posterTag { get; }
	}

	// @interface ACRMediaTarget : NSObject <ACRSelectActionDelegate>
	[BaseType (typeof(NSObject))]
	interface ACRMediaTarget : ACRSelectActionDelegate
	{
		// -(instancetype)initWithMediaEvent:(ACOMediaEvent *)mediaEvent rootView:(ACRView *)rootView config:(ACOHostConfig *)config;
		[Export ("initWithMediaEvent:rootView:config:")]
		IntPtr Constructor (ACOMediaEvent mediaEvent, ACRView rootView, ACOHostConfig config);

		// -(instancetype)initWithMediaEvent:(ACOMediaEvent *)mediaEvent rootView:(ACRView *)rootView config:(ACOHostConfig *)config containingview:(UIView *)containingview;
		[Export ("initWithMediaEvent:rootView:config:containingview:")]
		IntPtr Constructor (ACOMediaEvent mediaEvent, ACRView rootView, ACOHostConfig config, UIView containingview);

		// -(void)doSelectAction;
		[Export ("doSelectAction")]
		void DoSelectAction ();

		// -(void)playMedia:(AVAssetTrack *)track asset:(AVURLAsset *)asset;
		[Export ("playMedia:asset:")]
		void PlayMedia (AVAssetTrack track, AVUrlAsset asset);

		// -(void)playVideoWhenTrackIsReady:(AVURLAsset *)asset;
		[Export ("playVideoWhenTrackIsReady:")]
		void PlayVideoWhenTrackIsReady (AVUrlAsset asset);
	}

	// @interface ACRRegistration : NSObject
	[BaseType (typeof(NSObject))]
	interface ACRRegistration
	{
		// +(ACRRegistration * _Nonnull)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRRegistration Instance { get; }

		// -(ACRBaseCardElementRenderer * _Nullable)getRenderer:(NSNumber * _Nonnull)cardElementType;
		[Export ("getRenderer:")]
		[return: NullAllowed]
		ACRBaseCardElementRenderer GetRenderer (NSNumber cardElementType);

		// -(ACRBaseActionElementRenderer * _Nullable)getActionRenderer:(NSNumber * _Nonnull)cardElementType;
		[Export ("getActionRenderer:")]
		[return: NullAllowed]
		ACRBaseActionElementRenderer GetActionRenderer (NSNumber cardElementType);

		// -(id<ACRIBaseActionSetRenderer> _Nullable)getActionSetRenderer;
		[NullAllowed, Export ("getActionSetRenderer")]
		ACRIBaseActionSetRenderer ActionSetRenderer { get; }

		// -(void)setActionRenderer:(ACRBaseActionElementRenderer * _Nullable)renderer cardElementType:(NSNumber * _Nonnull)cardElementType;
		[Export ("setActionRenderer:cardElementType:")]
		void SetActionRenderer ([NullAllowed] ACRBaseActionElementRenderer renderer, NSNumber cardElementType);

		// -(void)setBaseCardElementRenderer:(ACRBaseCardElementRenderer * _Nullable)renderer cardElementType:(ACRCardElementType)cardElementType;
		[Export ("setBaseCardElementRenderer:cardElementType:")]
		void SetBaseCardElementRenderer ([NullAllowed] ACRBaseCardElementRenderer renderer, ACRCardElementType cardElementType);

		// -(void)setActionSetRenderer:(id<ACRIBaseActionSetRenderer> _Nullable)actionsetRenderer;
		[Export ("setActionSetRenderer:")]
		void SetActionSetRenderer ([NullAllowed] ACRIBaseActionSetRenderer actionsetRenderer);

		// -(void)setCustomElementParser:(NSObject<ACOIBaseCardElementParser> * _Nonnull)customElementPars_Nonnuller key:(NSString * _Nonnull)key;
		[Export ("setCustomElementParser:key:")]
		void SetCustomElementParser (ACOIBaseCardElementParser customElementPars_Nonnuller, string key);

		// -(NSObject<ACOIBaseCardElementParser> * _Nullable)getCustomElementParser:(NSString * _Nonnull)key;
		[Export ("getCustomElementParser:")]
		[return: NullAllowed]
		ACOIBaseCardElementParser GetCustomElementParser (string key);

		// -(void)setCustomElementRenderer:(ACRBaseCardElementRenderer * _Nonnull)renderer key:(NSString * _Nonnull)key;
		[Export ("setCustomElementRenderer:key:")]
		void SetCustomElementRenderer (ACRBaseCardElementRenderer renderer, string key);

		// -(BOOL)isElementRendererOverridden:(ACRCardElementType)cardElementType;
		[Export ("isElementRendererOverridden:")]
		bool IsElementRendererOverridden (ACRCardElementType cardElementType);

		// -(BOOL)isActionRendererOverridden:(NSNumber * _Nonnull)cardElementType;
		[Export ("isActionRendererOverridden:")]
		bool IsActionRendererOverridden (NSNumber cardElementType);

		// -(void)setCustomActionElementParser:(NSObject<ACOIBaseActionElementParser> * _Nonnull)parser key:(NSString * _Nonnull)key;
		[Export ("setCustomActionElementParser:key:")]
		void SetCustomActionElementParser (ACOIBaseActionElementParser parser, string key);

		// -(NSObject<ACOIBaseActionElementParser> * _Nullable)getCustomActionElementParser:(NSString * _Nonnull)key;
		[Export ("getCustomActionElementParser:")]
		[return: NullAllowed]
		ACOIBaseActionElementParser GetCustomActionElementParser (string key);

		// -(void)setCustomActionRenderer:(ACRBaseActionElementRenderer * _Nonnull)renderer key:(NSString * _Nonnull)key;
		[Export ("setCustomActionRenderer:key:")]
		void SetCustomActionRenderer (ACRBaseActionElementRenderer renderer, string key);

		// -(ACOParseContext * _Nonnull)getParseContext;
		[Export ("getParseContext")]
		ACOParseContext ParseContext { get; }
	}

	// @interface ACOFeatureRegistration : NSObject
	[BaseType (typeof(NSObject))]
	interface ACOFeatureRegistration
	{
		// +(ACOFeatureRegistration * _Nonnull)getInstance;
		[Static]
		[Export ("getInstance")]
		ACOFeatureRegistration Instance { get; }

		// -(void)addFeature:(NSString * _Nullable)featureName featureVersion:(NSString * _Nullable)version;
		[Export ("addFeature:featureVersion:")]
		void AddFeature ([NullAllowed] string featureName, [NullAllowed] string version);

		// -(void)removeFeature:(NSString * _Nullable)featureName;
		[Export ("removeFeature:")]
		void RemoveFeature ([NullAllowed] string featureName);

		// -(NSString * _Nonnull)getFeatureVersion:(NSString * _Nullable)featureName;
		[Export ("getFeatureVersion:")]
		string GetFeatureVersion ([NullAllowed] string featureName);
	}

	// @interface ACRViewController : UIViewController
	[BaseType (typeof(UIViewController))]
	interface ACRViewController
	{
		// -(instancetype)init:(ACOAdaptiveCard *)card hostconfig:(ACOHostConfig *)config frame:(CGRect)frame delegate:(id<ACRActionDelegate>)acrActionDelegate;
		[Export ("init:hostconfig:frame:delegate:")]
		IntPtr Constructor (ACOAdaptiveCard card, ACOHostConfig config, CGRect frame, ACRActionDelegate acrActionDelegate);
	}

	// @interface ACRRenderResult : NSObject
	[BaseType (typeof(NSObject))]
	interface ACRRenderResult
	{
		// @property ACRView * view;
		[Export ("view", ArgumentSemantic.Assign)]
		ACRView View { get; set; }

		// @property ACRViewController * viewcontroller;
		[Export ("viewcontroller", ArgumentSemantic.Assign)]
		ACRViewController Viewcontroller { get; set; }

		// @property BOOL succeeded;
		[Export ("succeeded")]
		bool Succeeded { get; set; }

		// @property (weak) NSArray<ACOWarning *> * warnings;
		[Export ("warnings", ArgumentSemantic.Weak)]
		ACOWarning[] Warnings { get; set; }
	}

	// @interface ACRRenderer : NSObject
	[BaseType (typeof(NSObject))]
	interface ACRRenderer
	{
		// +(ACRRenderResult *)render:(ACOAdaptiveCard *)card config:(ACOHostConfig *)config widthConstraint:(float)width;
		[Static]
		[Export ("render:config:widthConstraint:")]
		ACRRenderResult Render (ACOAdaptiveCard card, ACOHostConfig config, float width);

		// +(ACRRenderResult *)render:(ACOAdaptiveCard *)card config:(ACOHostConfig *)config widthConstraint:(float)width delegate:(id<ACRActionDelegate>)acrActionDelegate;
		[Static]
		[Export ("render:config:widthConstraint:delegate:")]
		ACRRenderResult Render (ACOAdaptiveCard card, ACOHostConfig config, float width, ACRActionDelegate acrActionDelegate);

		// +(ACRRenderResult *)renderAsViewController:(ACOAdaptiveCard *)card config:(ACOHostConfig *)config frame:(CGRect)frame delegate:(id<ACRActionDelegate>)acrActionDelegate;
		[Static]
		[Export ("renderAsViewController:config:frame:delegate:")]
		ACRRenderResult RenderAsViewController (ACOAdaptiveCard card, ACOHostConfig config, CGRect frame, ACRActionDelegate acrActionDelegate);
	}

	// @interface ACRRichTextBlockRenderer : ACRBaseCardElementRenderer
	[BaseType (typeof(ACRBaseCardElementRenderer))]
	interface ACRRichTextBlockRenderer
	{
		// +(ACRRichTextBlockRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRRichTextBlockRenderer Instance { get; }
	}

	// @interface ACRTextBlockRenderer : ACRBaseCardElementRenderer
	[BaseType (typeof(ACRBaseCardElementRenderer))]
	interface ACRTextBlockRenderer
	{
		// +(ACRTextBlockRenderer *)getInstance;
		[Static]
		[Export ("getInstance")]
		ACRTextBlockRenderer Instance { get; }
	}

	// @interface ACRTextView : UITextView <ACRIBaseInputHandler, UITextViewDelegate>
	[BaseType (typeof(UITextView))]
	interface ACRTextView : ACRIBaseInputHandler, IUITextViewDelegate
	{
		// @property NSString * id;
		[Export ("id")]
		string Id { get; set; }

		// @property NSString * placeholderText;
		[Export ("placeholderText")]
		string PlaceholderText { get; set; }

		// @property _Bool isRequired;
		[Export ("isRequired")]
		bool IsRequired { get; set; }

		// @property NSUInteger maxLength;
		[Export ("maxLength")]
		nuint MaxLength { get; set; }

		// @property UIColor * borderColor;
		[Export ("borderColor", ArgumentSemantic.Assign)]
		UIColor BorderColor { get; set; }

		// -(instancetype)initWithFrame:(CGRect)frame element:(ACOBaseCardElement *)element;
		[Export ("initWithFrame:element:")]
		IntPtr Constructor (CGRect frame, ACOBaseCardElement element);

		// -(void)configWithSharedModel:(ACOBaseCardElement *)element;
		[Export ("configWithSharedModel:")]
		void ConfigWithSharedModel (ACOBaseCardElement element);
	}
}
