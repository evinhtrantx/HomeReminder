﻿using Microsoft.Toolkit.Uwp.Notifications;
using Reminder;


var audio = new ToastAudio
{
    Loop = true
};
ConfigLoader configLoader = new ConfigLoader();
IList<Config> schedules = ConfigLoader.GetConfigs();
var currentTime = DateTime.Now.ToString("HH:mm");
foreach (var schedule in schedules)
{
    foreach (var date in schedule.SpecificDates)
    {
        if (date == DateOnly.FromDateTime(DateTime.Today))
        {
            ScheduleMessage(schedule.Messages);
            break;
        }
    }
    foreach(var dow in schedule.DayOfWeeks)
    {
        if (dow == DateTime.Today.DayOfWeek)
        {
            ScheduleMessage(schedule.Messages);
            break;
        }
    }
}
/*
var dismissSnoozeActions = new ToastActionsSnoozeAndDismiss();
var msg1 = new ToastContentBuilder()
    .AddText("alerts have been setup for today")
    .SetToastScenario(ToastScenario.Alarm);
msg1.Content.Actions = dismissSnoozeActions;
msg1.Show();
*/

void ScheduleMessage(MessageByTime[] messages)
{
    foreach (var message in messages)
    {
        if (message.Time.CompareTo(currentTime) > 0)
        {
            var dismissSnoozeActions = new ToastActionsSnoozeAndDismiss();
            var msg1 = new ToastContentBuilder()
                .AddText(message.messageText)
                .AddAudio(audio)
                .SetToastScenario(ToastScenario.Alarm);
            msg1.Content.Actions = dismissSnoozeActions;
            msg1.Schedule(DateTimeOffset.Parse(message.Time));
        }
    }
}