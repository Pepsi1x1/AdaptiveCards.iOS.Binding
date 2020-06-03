using ObjCRuntime;

namespace AdaptiveCards.iOS.Binding
{
	[Native]
	public enum ACRWarningStatusCode : ulong
	{
		UnknownElementType = 0,
		UnknownActionElementType,
		UnknownPropertyOnElement,
		UnknownEnumValue,
		NoRendererForType,
		InteractivityNotSupported,
		MaxActionsExceeded,
		AssetLoadFailed,
		UnsupportedSchemaVersion,
		UnsupportedMediaType,
		InvalidMediaMix,
		InvalidColorFormat,
		InvalidDimensionSpecified,
		InvalidLanguage,
		InvalidValue,
		CustomWarning
	}

	[Native]
	public enum ACRCardElementType : long
	{
		ActionSet = 0,
		AdaptiveCard,
		ChoiceInput,
		ChoiceSetInput,
		Column,
		ColumnSet,
		Container,
		Custom,
		DateInput,
		Fact,
		FactSet,
		Image,
		ImageSet,
		Media,
		NumberInput,
		RichTextBlock,
		TextBlock,
		TextInput,
		TimeInput,
		ToggleInput,
		Unknown
	}

	[Native]
	public enum ACRContainerStyle : long
	{
		None,
		Default,
		Emphasis,
		Good,
		Warning,
		Attention,
		Accent
	}

	[Native]
	public enum ACRBleedDirection : long
	{
		Restricted = 0,
		ToLeadingEdge = 1,
		ToTrailingEdge = 16,
		ToTopEdge = 256,
		ToBottomEdge = 4096,
		ToAll = ToLeadingEdge | ToTrailingEdge | ToTopEdge | ToBottomEdge
	}

	[Native]
	public enum ACOResolverIFType : long
	{
		DefaultIF = 0,
		ImageIF = 0,
		ImageViewIF
	}

	[Native]
	public enum ACRActionType : long
	{
		ShowCard = 1,
		Submit,
		OpenUrl,
		ToggleVisibility,
		UnknownAction = 6
	}

	[Native]
	public enum ACRIconPlacement : long
	{
		AboveTitle = 0,
		LeftOfTitle,
		NoTitle
	}

	[Native]
	public enum ACRColumnWidthPriority : long
	{
		Stretch = 249,
		StretchAuto = 251,
		Auto
	}

	[Native]
	public enum ACRInputError : ulong
	{
		ValueMissing,
		LessThanMin,
		GreaterThanMax,
		LessThanMinDate,
		GreaterThanMaxDate
	}

	[Native]
	public enum ACRRenderingStatus : ulong
	{
		Ok = 0,
		Failed,
		Unsupported
	}
}
