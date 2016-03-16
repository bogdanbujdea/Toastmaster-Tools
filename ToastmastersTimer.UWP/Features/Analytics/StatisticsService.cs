using System;
using System.Collections.Generic;

namespace ToastmastersTimer.UWP.Features.Analytics
{
    public class StatisticsService : IStatisticsService
    {
        public StatisticsService()
        {
            LoadEvents();
        }
        public void RegisterPage(string page)
        {
            try
            {
                GoogleAnalytics.EasyTracker.GetTracker().SendView(page);
            }
            catch (Exception)
            {
            }
        }

        private void LoadEvents()
        {
            EventCategories = new Dictionary<EventCategory, string>();
            EventActions = new Dictionary<EventAction, string>();
            EventCategories[EventCategory.UserEvent] = "user_event";
            EventCategories[EventCategory.AppEvent] = "app_event";
            EventActions[EventAction.Timer] = "Timer";
        }

        public Dictionary<EventCategory, string> EventCategories { get; set; }
        public Dictionary<EventAction, string> EventActions { get; set; }

        public void RegisterButtonPress(string button)
        {
            try
            {
                GoogleAnalytics.EasyTracker.GetTracker().SendEvent("ui_action", "button_press", button, 0);
            }
            catch (Exception)
            {

            }
        }

        public void RegisterEvent(EventCategory category, EventAction action, string eventName)
        {
            try
            {
                GoogleAnalytics.EasyTracker.GetTracker().SendEvent(EventCategories[category], EventActions[action], eventName, 0);

            }
            catch (Exception)
            {

            }
        }

        public void RegisterEvent(EventCategory eventCategory, string action, string eventName)
        {
            try
            {
                GoogleAnalytics.EasyTracker.GetTracker().SendEvent(EventCategories[eventCategory], action, eventName, 0);

            }
            catch (Exception)
            {

            }
        }
    }

    public enum EventAction
    {
        Timer
    }

    public enum EventCategory
    {
        UserEvent,
        AppEvent
    }
}