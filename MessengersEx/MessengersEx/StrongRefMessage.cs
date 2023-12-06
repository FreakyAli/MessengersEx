using System;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MessengersEx;

public class StrongRefdMessage : ValueChangedMessage<string>
{
    public StrongRefdMessage(string value) : base(value)
    {
    }
}