using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Pos2Web
{
    public static class PageAnimations
    {

        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            //Create StoryBoard
            var sb = new Storyboard();

            //Add Slide From Right animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            sb.AddFadeIn(seconds);
            //Start Animation
            sb.Begin(page);

            //Make page visible
            page.Visibility = Visibility.Visible;

            //animasyonun bitmesini bekle
            await Task.Delay((int)seconds * 1000);    
        }
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            //Create StoryBoard
            var sb = new Storyboard();

            //Add Slide From Right animation
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            sb.AddFadeOut(seconds);
            //Start Animation
            sb.Begin(page);

            //Make page visible
            page.Visibility = Visibility.Visible;

            //animasyonun bitmesini bekle
            await Task.Delay((int)seconds * 1000);    
        }

    }
}
