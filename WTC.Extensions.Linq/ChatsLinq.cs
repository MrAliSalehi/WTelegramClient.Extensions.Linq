using TL;

namespace WTC.Extensions.Linq;

public static class ChatsLinq
{
    public static List<Channel> Channels(this Messages_Chats mc, Func<Channel, bool>? predicate = null)
    {
        var ofType = mc.chats.Values.OfType<Channel>();
        return predicate is null ? ofType.ToList() : ofType.Where(predicate).ToList();
    }
}