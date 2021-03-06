﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Graphics.Containers;
using osu.Game.Online.API.Requests;
using osu.Game.Overlays;
using osu.Game.Overlays.BeatmapListing;
using osuTK;

namespace osu.Game.Tests.Visual.UserInterface
{
    public class TestSceneBeatmapSearchFilter : OsuTestScene
    {
        public override IReadOnlyList<Type> RequiredTypes => new[]
        {
            typeof(BeatmapSearchFilterRow<>),
            typeof(BeatmapSearchRulesetFilterRow),
            typeof(BeatmapSearchSmallFilterRow<>),
        };

        [Cached]
        private readonly OverlayColourProvider colourProvider = new OverlayColourProvider(OverlayColourScheme.Blue);

        private readonly ReverseChildIDFillFlowContainer<Drawable> resizableContainer;

        public TestSceneBeatmapSearchFilter()
        {
            Add(resizableContainer = new ReverseChildIDFillFlowContainer<Drawable>
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                AutoSizeAxes = Axes.Y,
                RelativeSizeAxes = Axes.X,
                Direction = FillDirection.Vertical,
                Spacing = new Vector2(0, 10),
                Children = new Drawable[]
                {
                    new BeatmapSearchRulesetFilterRow(),
                    new BeatmapSearchFilterRow<BeatmapSearchCategory>("Categories"),
                    new BeatmapSearchSmallFilterRow<BeatmapSearchCategory>("Header Name")
                }
            });
        }

        [Test]
        public void TestResize()
        {
            AddStep("Resize to 0.3", () => resizableContainer.ResizeWidthTo(0.3f, 1000));
            AddStep("Resize to 1", () => resizableContainer.ResizeWidthTo(1, 1000));
        }
    }
}
