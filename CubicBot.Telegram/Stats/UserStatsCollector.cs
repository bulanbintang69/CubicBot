﻿using CubicBot.Telegram.Utils;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CubicBot.Telegram.Stats;

/// <summary>
/// Stats collector for private chats and group members.
/// </summary>
public abstract class UserStatsCollector : StatsCollector
{
    /// <summary>
    /// Collects stats for the user in private chat or group.
    /// </summary>
    /// <param name="message">Input message.</param>
    /// <param name="userData">User data object.</param>
    /// <param name="groupData">
    /// If the message is from a group, the group data object.
    /// Otherwise, null.
    /// </param>
    public abstract void CollectUser(Message message, UserData userData, GroupData? groupData);

    /// <summary>
    /// Optionally, responds to the message.
    /// Override this method to generate responses.
    /// </summary>
    /// <param name="botClient">The Telegram bot client.</param>
    /// <param name="message">Input message.</param>
    /// <param name="userData">User data object.</param>
    /// <param name="groupData">
    /// If the message is from a group, the group data object.
    /// Otherwise, null.
    /// </param>
    /// <param name="cancellationToken">A token that may be used to cancel the respond operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public virtual Task RespondAsync(ITelegramBotClient botClient, Message message, UserData userData, GroupData? groupData, CancellationToken cancellationToken) => Task.CompletedTask;

    public override Task CollectAsync(ITelegramBotClient botClient, Message message, Data data, CancellationToken cancellationToken = default)
    {
        if (!IsCollectable(message))
        {
            return Task.CompletedTask;
        }

        var userId = ChatHelper.GetMessageSenderId(message);

        var groupData = message.Chat.Type switch
        {
            ChatType.Private => null,
            _ => data.GetOrCreateGroupData(message.Chat.Id),
        };

        var userData = message.Chat.Type switch
        {
            ChatType.Private => data.GetOrCreateUserData(userId),
            _ => groupData!.GetOrCreateUserData(userId),
        };

        CollectUser(message, userData, groupData);

        return RespondAsync(botClient, message, userData, groupData, cancellationToken);
    }
}
