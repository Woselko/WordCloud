using KnowledgePicker.WordCloud;
using KnowledgePicker.WordCloud.Coloring;
using KnowledgePicker.WordCloud.Drawing;
using KnowledgePicker.WordCloud.Layouts;
using KnowledgePicker.WordCloud.Primitives;
using KnowledgePicker.WordCloud.Sizers;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCloudGenerator
{
    public class WordCloudGenerator
    {
        public WordCloudGenerator() { }

        public string Generate()
        {
            var frequencies = new Dictionary<string, int>
            {
                { "Woselko", 6 },
                { "Blazor", 3 },
                { "Programming", 8 },
                { "FunctionApp", 4 },
                { "Algorithms", 5 },
                { "Git", 3 },
                { "Pizza", 4 },
                { "Dictionary", 5 },
                { "WebApp", 10 },
                { "Coding", 5 },
                { "Frontend", 3 },
                { "WordCloud", 4 },
                { "API", 5 },
                { "C#", 10 },
                { "Backend", 5 },
            };

            IEnumerable<WordCloudEntry> wordEntries = frequencies.Select(p => new WordCloudEntry(p.Key, p.Value));


            var wordCloud = new WordCloudInput(wordEntries)
            {
                Width = 1920*2,
                Height = 2160,
                //Width = 1000,
                //Height = 1000,
                MinFontSize = 100,
                MaxFontSize = 200
            };


            var sizer = new LogSizer(wordCloud);
            using var engine = new SkGraphicEngine(sizer, wordCloud);
            var layout = new SpiralLayout(wordCloud);
            var randomColorizer = new RandomColorizer(); // optional
            var wcg = new WordCloudGenerator<SKBitmap>(wordCloud, engine, layout, randomColorizer);

            //var colorizer = new SpecificColorizer(
            //new Dictionary<string, Color>
            //{
            //    ["KnowledgePicker"] = Color.FromArgb(0x0f3057),
            //    ["WordCloud"] = Color.FromArgb(0xe25a5a)
            //},
            //fallback: new RandomColorizer()); // fallback argument is optional

            //var typeface = SKTypeface.FromFamilyName("DejaVu Serif", SKFontStyle.Normal);
            //using var engine = new SkGraphicEngine(sizer, wordCloud, typeface);

            IEnumerable<(LayoutItem Item, double FontSize)> items = wcg.Arrange();


            using var final = new SKBitmap(wordCloud.Width, wordCloud.Height);
            using var canvas = new SKCanvas(final);

            // Draw on white background.
            canvas.Clear(SKColors.Transparent);
            //canvas.Clear(SKColors.Black);
            using var bitmap = wcg.Draw();
            canvas.DrawBitmap(bitmap, 0, 0);

            // Save to PNG.
            using var data = final.Encode(SKEncodedImageFormat.Png, int.MaxValue);
            using var writer = File.Create("fontsizePNG.png");
            data.SaveTo(writer);

            return "wordcloud";
        }
    }

    public class RectangleLayout : BaseLayout
    {
        public RectangleLayout(WordCloudInput wordCloud)
            : base(wordCloud)
        {
        }

        public override bool TryFindFreeRectangle(SizeD size, out RectangleD foundRectangle)
        {
            foundRectangle = RectangleD.Empty;

            double x = base.Center.X - size.Width / 2.0;
            double y = base.Center.Y - size.Height / 2.0;
            foundRectangle = new RectangleD(x, y, size.Width, size.Height);

            if (IsInsideSurface(foundRectangle) && !IsTaken(foundRectangle))
            {
                return true;
            }

            return false;
        }

        public override ILayout Clone()
        {
            return new RectangleLayout(base.WordCloud);
        }
    }
}
