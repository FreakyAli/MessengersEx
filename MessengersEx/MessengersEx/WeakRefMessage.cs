using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MessengersEx;

public class WeakRefMessage : ValueChangedMessage<string>
{
    public WeakRefMessage(string value) : base(value)
    {
    }
}