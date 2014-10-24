using System;
using LibGit2Sharp;
using LibGit2Sharp.Tests.TestHelpers;
using Xunit;
using System.Globalization;
using System.IO;

namespace LibGit2Sharp.Tests
{
    public class GlobalSettingsFixture : BaseFixture
    {
        [Fact]
        public void CanGetMinimumCompiledInFeatures()
        {
            BuiltInFeatures features = GlobalSettings.Features();

            Assert.True(features.HasFlag(BuiltInFeatures.Threads));
            Assert.True(features.HasFlag(BuiltInFeatures.Https));

            bool hasSsh;
            using (var sr = new StreamReader(typeof(GlobalSettingsFixture).Assembly.GetManifestResourceStream("LibGit2Sharp.Tests.ssh_used")))
            {
                if (!bool.TryParse(sr.ReadLine(), out hasSsh))
                    hasSsh = false;
            }
            Assert.Equal(hasSsh, features.HasFlag(BuiltInFeatures.Ssh));
        }
    }
}
