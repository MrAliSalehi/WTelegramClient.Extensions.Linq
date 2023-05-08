using TL;

namespace WTC.Extensions.Linq.Wrappers;

public class UpdatesBaseWrapper
{
    internal static readonly Dictionary<long, User> Users = new();
    internal static readonly Dictionary<long, ChatBase> Chats = new();
    private UpdatesBaseWrapper(UpdatesBase updatesBase) => UpdatesBase = updatesBase;
    internal UpdatesBase UpdatesBase { get; }
    public static UpdatesBaseWrapper From(UpdatesBase u) => new(u);

    public void Collector(Dictionary<long, User> users, Dictionary<long, ChatBase> chats) =>
        UpdatesBase.CollectUsersChats(users, chats);
}