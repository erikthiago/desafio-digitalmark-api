using Flunt.Notifications;
using System.Collections.Generic;

namespace SistEnferHos.Domain.Extensions
{
    public static class NotifiableExtensions
    {

        public static string Messages(this IReadOnlyCollection<Notification> notifications)
        {
            List<string> message = new List<string>();

            foreach (var item in notifications)
            {
                message.Add($"{item.Message}");
            }

            return string.Join("\r\n ", message);
        }
    }
}
