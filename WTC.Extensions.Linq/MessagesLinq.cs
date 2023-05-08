using Optional;
using TL;
using WTC.Extensions.Linq.Wrappers;

namespace WTC.Extensions.Linq;

public static class MessagesLinq
{
    public static Option<MessageWrapper> Message(this Update update) => update switch
    {
        UpdateNewMessage nm  => Option.Some(MessageWrapper.From(nm.message)),
        UpdateEditMessage em => Option.Some(MessageWrapper.From(em.message)),
        _                    => Option.None<MessageWrapper>()
    };
    public static Option<Photo> Photo(this MessageMedia media) => media switch
    {
        MessageMediaPhoto { photo: Photo photo } => Option.Some(photo),
        _                                        => Option.None<Photo>()
    };
    public static Option<Document> Document(this MessageMedia media) => media switch
    {
        MessageMediaDocument { document: Document d } => Option.Some(d),
        _                                             => Option.None<Document>()
    };
}