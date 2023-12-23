namespace SWIFTcard.ContentViews;

public partial class DeckView : ContentView
{
    public static readonly BindableProperty QuestionHeaderProperty = BindableProperty.Create(nameof(QuestionHeader), typeof(string), typeof(DeckView), string.Empty);

    public string QuestionHeader
    {
        get => (string)GetValue(QuestionHeaderProperty);
        set => SetValue(QuestionHeaderProperty, value);
    }

    public static readonly BindableProperty AnswerHeaderProperty = BindableProperty.Create(nameof(AnswerHeader), typeof(string), typeof(DeckView), string.Empty);

    public string AnswerHeader
    {
        get => (string)GetValue(AnswerHeaderProperty);
        set => SetValue(AnswerHeaderProperty, value);
    }

    public static readonly BindableProperty InfoFooterProperty = BindableProperty.Create(nameof(InfoFooter), typeof(string), typeof(DeckView), string.Empty);

    public string InfoFooter
    {
        get => (string)GetValue(InfoFooterProperty);
        set => SetValue(InfoFooterProperty, value);
    }

    public static readonly BindableProperty IsActiveProperty = BindableProperty.Create(nameof(IsActive), typeof(bool), typeof(DeckView), false);

    public bool IsActive
    {
        get => (bool)GetValue(IsActiveProperty);
        set => SetValue(IsActiveProperty, value);
    }

    public static readonly BindableProperty IsAddCardProperty = BindableProperty.Create(nameof(IsAddCard), typeof(bool), typeof(DeckView), false);

    public bool IsAddCard
    {
        get => (bool)GetValue(IsAddCardProperty);
        set => SetValue(IsAddCardProperty, value);
    }

    public DeckView()
	{
		InitializeComponent();
	}
}
