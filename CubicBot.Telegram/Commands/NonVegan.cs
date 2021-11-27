﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CubicBot.Telegram.Commands
{
    public static class NonVegan
    {
        public static readonly string[] Food = new string[]
        {
            "🍏", "🍎", "🍐", "🍊", "🍋", "🍌", "🍉", "🍇", "🍓", "🫐",
            "🍈", "🍒", "🍑", "🥭", "🍍", "🥥", "🥝", "🍅", "🍆", "🥑",
            "🥦", "🥬", "🥒", "🌶", "🫑", "🌽", "🥕", "🫒", "🧄", "🧅",
            "🥔", "🍠", "🥐", "🥯", "🍞", "🥖", "🥨", "🧀", "🥚", "🍳",
            "🧈", "🥞", "🧇", "🥓", "🥩", "🍗", "🍖", "🦴", "🌭", "🍔",
            "🍟", "🍕", "🫓", "🥪", "🥙", "🧆", "🌮", "🌯", "🫔", "🥗",
            "🥘", "🫕", "🥫", "🍝", "🍜", "🍲", "🍛", "🍣", "🍱", "🥟",
            "🦪", "🍤", "🍙", "🍚", "🍘", "🍥", "🥠", "🥮", "🍢", "🍡",
            "🍧", "🍨", "🍦", "🥧", "🧁", "🍰", "🎂", "🍮", "🍭", "🍬",
            "🍫", "🍿", "🍩", "🍪", "🌰", "🥜", "🍯",
        };

        public static readonly CubicBotCommand[] Commands = new CubicBotCommand[]
        {
            new("eat", "☃️ Do you want to eat a snowman?", EatAsync),
        };

        public static Task EatAsync(ITelegramBotClient botClient, Message message, string? argument, Config config, Data data, CancellationToken cancellationToken = default)
        {
            if (message.ReplyToMessage is Message targetMessage)
            {
                return botClient.SendTextMessageAsync(message.Chat.Id,
                                                      $"{message.From?.FirstName} ate {targetMessage.From?.FirstName}! 🍴😋",
                                                      replyToMessageId: targetMessage.MessageId,
                                                      cancellationToken: cancellationToken);
            }
            else if (argument is string targetName)
            {
                return botClient.SendTextMessageAsync(message.Chat.Id,
                                                      $"{message.From?.FirstName} ate {targetName}! 🍴😋",
                                                      cancellationToken: cancellationToken);
            }
            else
            {
                var foodIndex = Random.Shared.Next(Food.Length);
                var food = Food[foodIndex];
                return botClient.SendTextMessageAsync(message.Chat.Id,
                                                      food,
                                                      replyToMessageId: message.MessageId,
                                                      cancellationToken: cancellationToken);
            }
        }
    }
}
