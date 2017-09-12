using System;
using System.Collections.Generic;
using System.Linq;

// TODO: Be aware of empty Disallow, ignore that, and be aware it may contradict *

namespace RobotsTxtReader
{
    public class Program
    {
        public static string[] TestRobotsTxtFiles = {
            @"User-agent: *
Disallow: /fiction/chapter/*/vote
Disallow: /fictions/review/
Disallow: /syndication/",
            @"User-agent: 008
Disallow: /

User-agent:*
Disallow:",
            @"# robots.txt file for YouTube
# Created in the distant future (the year 2000) after
# the robotic uprising of the mid 90's which wiped out all humans.

User-agent: Mediapartners-Google*
Disallow:

User-agent: *
Disallow: /channel/*/community
Disallow: /comment
Disallow: /get_video
Disallow: /get_video_info
Disallow: /login
Disallow: /results
Disallow: /signup
Disallow: /t/terms
Disallow: /timedtext_video
Disallow: /user/*/community
Disallow: /verify_age
Disallow: /watch_ajax
Disallow: /watch_fragments_ajax
Disallow: /watch_popup
Disallow: /watch_queue_ajax

Sitemap: https://www.youtube.com/yt/advertise/sitemap.xml",
            @"User-agent: *
Disallow:

# too many repeated hits, too quick
User-agent: litefinder
Disallow: /

# Yahoo. too many repeated hits, too quick
User-agent: Slurp
Disallow: /

# too many repeated hits, too quick
User-agent: Baidu
Disallow: /",
            @"# Notice: Crawling Facebook is prohibited unless you have express written
# permission. See: http://www.facebook.com/apps/site_scraping_tos_terms.php

User-agent: Applebot
Disallow: /ajax/
Disallow: /album.php
Disallow: /checkpoint/
Disallow: /contact_importer/
Disallow: /feeds/
Disallow: /file_download.php
Disallow: /hashtag/
Disallow: /l.php
Disallow: /live/
Disallow: /moments_app/
Disallow: /p.php
Disallow: /photo.php
Disallow: /photos.php
Disallow: /sharer/

User-agent: baiduspider
Disallow: /ajax/
Disallow: /album.php
Disallow: /checkpoint/
Disallow: /contact_importer/
Disallow: /feeds/
Disallow: /file_download.php
Disallow: /hashtag/
Disallow: /l.php
Disallow: /live/
Disallow: /moments_app/
Disallow: /p.php
Disallow: /photo.php
Disallow: /photos.php
Disallow: /sharer/

User-agent: Bingbot
Disallow: /ajax/
Disallow: /album.php
Disallow: /checkpoint/
Disallow: /contact_importer/
Disallow: /feeds/
Disallow: /file_download.php
Disallow: /hashtag/
Disallow: /l.php
Disallow: /live/
Disallow: /moments_app/
Disallow: /p.php
Disallow: /photo.php
Disallow: /photos.php
Disallow: /sharer/

User-agent: Googlebot
Disallow: /ajax/
Disallow: /album.php
Disallow: /checkpoint/
Disallow: /contact_importer/
Disallow: /feeds/
Disallow: /file_download.php
Disallow: /hashtag/
Disallow: /l.php
Disallow: /live/
Disallow: /moments_app/
Disallow: /p.php
Disallow: /photo.php
Disallow: /photos.php
Disallow: /sharer/

User-agent: ia_archiver
Disallow: /
Disallow: /ajax/
Disallow: /album.php
Disallow: /checkpoint/
Disallow: /contact_importer/
Disallow: /feeds/
Disallow: /file_download.php
Disallow: /hashtag/
Disallow: /l.php
Disallow: /live/
Disallow: /moments_app/
Disallow: /p.php
Disallow: /photo.php
Disallow: /photos.php
Disallow: /sharer/

User-agent: msnbot
Disallow: /ajax/
Disallow: /album.php
Disallow: /checkpoint/
Disallow: /contact_importer/
Disallow: /feeds/
Disallow: /file_download.php
Disallow: /hashtag/
Disallow: /l.php
Disallow: /live/
Disallow: /moments_app/
Disallow: /p.php
Disallow: /photo.php
Disallow: /photos.php
Disallow: /sharer/

User-agent: Naverbot
Disallow: /ajax/
Disallow: /album.php
Disallow: /checkpoint/
Disallow: /contact_importer/
Disallow: /feeds/
Disallow: /file_download.php
Disallow: /hashtag/
Disallow: /l.php
Disallow: /live/
Disallow: /moments_app/
Disallow: /p.php
Disallow: /photo.php
Disallow: /photos.php
Disallow: /sharer/

User-agent: seznambot
Disallow: /ajax/
Disallow: /album.php
Disallow: /checkpoint/
Disallow: /contact_importer/
Disallow: /feeds/
Disallow: /file_download.php
Disallow: /hashtag/
Disallow: /l.php
Disallow: /live/
Disallow: /moments_app/
Disallow: /p.php
Disallow: /photo.php
Disallow: /photos.php
Disallow: /sharer/

User-agent: Slurp
Disallow: /ajax/
Disallow: /album.php
Disallow: /checkpoint/
Disallow: /contact_importer/
Disallow: /feeds/
Disallow: /file_download.php
Disallow: /hashtag/
Disallow: /l.php
Disallow: /live/
Disallow: /moments_app/
Disallow: /p.php
Disallow: /photo.php
Disallow: /photos.php
Disallow: /sharer/

User-agent: teoma
Disallow: /ajax/
Disallow: /album.php
Disallow: /checkpoint/
Disallow: /contact_importer/
Disallow: /feeds/
Disallow: /file_download.php
Disallow: /hashtag/
Disallow: /l.php
Disallow: /live/
Disallow: /moments_app/
Disallow: /p.php
Disallow: /photo.php
Disallow: /photos.php
Disallow: /sharer/

User-agent: Twitterbot
Disallow: /ajax/
Disallow: /album.php
Disallow: /checkpoint/
Disallow: /contact_importer/
Disallow: /feeds/
Disallow: /file_download.php
Disallow: /hashtag/
Disallow: /l.php
Disallow: /live/
Disallow: /moments_app/
Disallow: /p.php
Disallow: /photo.php
Disallow: /photos.php
Disallow: /sharer/

User-agent: Yandex
Disallow: /ajax/
Disallow: /album.php
Disallow: /checkpoint/
Disallow: /contact_importer/
Disallow: /feeds/
Disallow: /file_download.php
Disallow: /hashtag/
Disallow: /l.php
Disallow: /live/
Disallow: /moments_app/
Disallow: /p.php
Disallow: /photo.php
Disallow: /photos.php
Disallow: /sharer/

User-agent: Yeti
Disallow: /ajax/
Disallow: /album.php
Disallow: /checkpoint/
Disallow: /contact_importer/
Disallow: /feeds/
Disallow: /file_download.php
Disallow: /hashtag/
Disallow: /l.php
Disallow: /live/
Disallow: /moments_app/
Disallow: /p.php
Disallow: /photo.php
Disallow: /photos.php
Disallow: /sharer/

User-agent: Applebot
Allow: /ajax/pagelet/generic.php/PagePostsSectionPagelet
Allow: /safetycheck/

User-agent: baiduspider
Allow: /ajax/pagelet/generic.php/PagePostsSectionPagelet
Allow: /safetycheck/

User-agent: Bingbot
Allow: /ajax/pagelet/generic.php/PagePostsSectionPagelet
Allow: /safetycheck/

User-agent: Googlebot
Allow: /ajax/pagelet/generic.php/PagePostsSectionPagelet
Allow: /safetycheck/

User-agent: ia_archiver
Allow: /about/privacy
Allow: /ajax/pagelet/generic.php/PagePostsSectionPagelet
Allow: /full_data_use_policy
Allow: /legal/terms
Allow: /policy.php
Allow: /safetycheck/

User-agent: msnbot
Allow: /ajax/pagelet/generic.php/PagePostsSectionPagelet
Allow: /safetycheck/

User-agent: Naverbot
Allow: /ajax/pagelet/generic.php/PagePostsSectionPagelet
Allow: /safetycheck/

User-agent: seznambot
Allow: /ajax/pagelet/generic.php/PagePostsSectionPagelet
Allow: /safetycheck/

User-agent: Slurp
Allow: /ajax/pagelet/generic.php/PagePostsSectionPagelet
Allow: /safetycheck/

User-agent: teoma
Allow: /ajax/pagelet/generic.php/PagePostsSectionPagelet
Allow: /safetycheck/

User-agent: Twitterbot
Allow: /ajax/pagelet/generic.php/PagePostsSectionPagelet
Allow: /safetycheck/

User-agent: Yandex
Allow: /ajax/pagelet/generic.php/PagePostsSectionPagelet
Allow: /safetycheck/

User-agent: Yeti
Allow: /ajax/pagelet/generic.php/PagePostsSectionPagelet
Allow: /safetycheck/

User-agent: *
Disallow: /
"
        };

        public static void Main(string[] args)
        {
            foreach (var robotstxt in TestRobotsTxtFiles)
            {
                Console.WriteLine("Agent: " + "*");
                foreach (var rule in RobotsTxtParser.GetRulesApplyingForMe(robotstxt, "Twitterbot"))
                {
                    Console.WriteLine(rule);
                }
                Console.WriteLine();

                //foreach (var parserAgentRule in parser.AgentRules)
                //{
                //    Console.WriteLine("Agent: " + parserAgentRule.Key);
                //    foreach (var rule in parserAgentRule.Value)
                //    {
                //        Console.WriteLine(rule);
                //    }
                //    Console.WriteLine("\n# ---\n\n");
                //}
            }

            Console.ReadKey();
        }
    }

    public static class RobotsTxtParser
    {

        public static string[] GetRulesApplyingForAll(string robotsFile)
        {
            return Parse(robotsFile)["*"].ToArray();
        }

        public static string[] GetRulesApplyingForMe(string robotsFile, string botName)
        {
            var appliesToMe = new List<string>();
            var agentRules = Parse(robotsFile);

            if (agentRules.ContainsKey("*"))
            {
                appliesToMe.AddRange(agentRules["*"]);
            }

            if (agentRules.ContainsKey(botName))
            {
                appliesToMe.AddRange(agentRules[botName]);
            }

            return appliesToMe.ToArray();
        }
        
        public static Dictionary<string, List<string>> Parse(string robotsFile)
        {
            var agentRules = new Dictionary<string, List<string>>();

            var lines = robotsFile.Split('\n');
            var currentAgent = string.Empty;
            var splitter = new[] { ' ', ':' };

            foreach (var line in lines)
            {
                if (currentAgent.Equals(string.Empty) && line.StartsWith("User-agent:"))
                {
                    currentAgent = line.Split(splitter, 2).Last().Trim();
                    if (!agentRules.ContainsKey(currentAgent))
                    {
                        agentRules.Add(currentAgent, new List<string>());
                    }
                }
                else if (!currentAgent.Equals(string.Empty) && line.StartsWith("Disallow:"))
                {
                    agentRules[currentAgent].Add(line.Split(splitter, 2).Last());
                }
                else if (string.IsNullOrWhiteSpace(line))
                {
                    currentAgent = string.Empty;
                }
            }

            return agentRules;
        }
    }
}