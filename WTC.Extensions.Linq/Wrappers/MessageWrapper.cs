using Optional;
using TL;

namespace WTC.Extensions.Linq.Wrappers;

public class MessageWrapper
{
    private MessageWrapper(MessageBase messageBase) => MessageBase = messageBase;

    public static MessageWrapper From(MessageBase l) => new(l);
    private MessageBase MessageBase { get; }

    public Option<Peer> Sender() => MessageBase switch
    {
        Message msg       => Option.Some(msg.From),
        MessageService ms => Option.Some(ms.From),
        MessageEmpty me   => Option.Some(me.From),
        _                 => Option.None<Peer>()
    };
    public Option<string> Text() => MessageBase switch
    {
        Message msg => Option.Some(msg.message),
        _           => Option.None<string>()
    };
    public Option<MessageMedia> Media() => MessageBase switch
    {
        Message msg => Option.Some(msg.media),
        _           => Option.None<MessageMedia>()
    };
}