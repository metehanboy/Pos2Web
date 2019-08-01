using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Pos2Web
{
    public static class StoryBoardHelpers
    {
        public static void AddSlideFromRight(this Storyboard storyBoard, float seconds, double offset, float deceleration = 0.9f)
        {

            //Create the margin animate from right
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = deceleration
            };

            //set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            //add this storyboard
            storyBoard.Children.Add(animation);

        }
        public static void AddSlideToLeft(this Storyboard storyBoard, float seconds, double offset, float deceleration = 0.9f)
        {

            //Create the margin animate from right
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = deceleration
            };

            //set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            //add this storyboard
            storyBoard.Children.Add(animation);

        }

        public static void AddFadeIn(this Storyboard storyBoard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            storyBoard.Children.Add(animation);
        }
        public static void AddFadeOut(this Storyboard storyBoard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            storyBoard.Children.Add(animation);
        }
    }
}
