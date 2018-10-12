﻿#region copyright

/*
MIT License

Copyright (c) 2018 Robin A. P.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

#endregion

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Shared.Database.Models
{
    public class LeaderboardRx
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int Id { get; set; }

        [Required] [DefaultValue(0)] public ulong RankedScoreOsu { get; set; }
        [Required] [DefaultValue(0)] public ulong RankedScoreTaiko { get; set; }
        [Required] [DefaultValue(0)] public ulong RankedScoreCtb { get; set; }
        [Required] [DefaultValue(0)] public ulong RankedScoreMania { get; set; }

        [Required] [DefaultValue(0)] public ulong TotalScoreOsu { get; set; }
        [Required] [DefaultValue(0)] public ulong TotalScoreTaiko { get; set; }
        [Required] [DefaultValue(0)] public ulong TotalScoreCtb { get; set; }
        [Required] [DefaultValue(0)] public ulong TotalScoreMania { get; set; }

        [Required] [DefaultValue(0)] public ulong Count300Osu { get; set; }
        [Required] [DefaultValue(0)] public ulong Count300Taiko { get; set; }
        [Required] [DefaultValue(0)] public ulong Count300Ctb { get; set; }
        [Required] [DefaultValue(0)] public ulong Count300Mania { get; set; }


        [Required] [DefaultValue(0)] public ulong Count100Osu { get; set; }
        [Required] [DefaultValue(0)] public ulong Count100Taiko { get; set; }
        [Required] [DefaultValue(0)] public ulong Count100Ctb { get; set; }
        [Required] [DefaultValue(0)] public ulong Count100Mania { get; set; }


        [Required] [DefaultValue(0)] public ulong Count50Osu { get; set; }
        [Required] [DefaultValue(0)] public ulong Count50Taiko { get; set; }
        [Required] [DefaultValue(0)] public ulong Count50Ctb { get; set; }
        [Required] [DefaultValue(0)] public ulong Count50Mania { get; set; }


        [Required] [DefaultValue(0)] public ulong CountMissOsu { get; set; }
        [Required] [DefaultValue(0)] public ulong CountMissTaiko { get; set; }
        [Required] [DefaultValue(0)] public ulong CountMissCtb { get; set; }
        [Required] [DefaultValue(0)] public ulong CountMissMania { get; set; }

        [Required] [DefaultValue(0)] public ulong PlayCountOsu { get; set; }
        [Required] [DefaultValue(0)] public ulong PlayCountTaiko { get; set; }
        [Required] [DefaultValue(0)] public ulong PlayCountCtb { get; set; }
        [Required] [DefaultValue(0)] public ulong PlayCountMania { get; set; }

        [Required] [DefaultValue(0)] public double PeppyPointsOsu { get; set; }
        [Required] [DefaultValue(0)] public double PeppyPointsTaiko { get; set; }
        [Required] [DefaultValue(0)] public double PeppyPointsCtb { get; set; }
        [Required] [DefaultValue(0)] public double PeppyPointsMania { get; set; }

        public static LeaderboardRx GetLeaderboard(int userId)
        {
            using (SoraContext db = new SoraContext())
            {
                LeaderboardRx result = db.LeaderboardRx.Where(t => t.Id == userId).Select(e => e).FirstOrDefault();
                if (result != null) return result;
                db.LeaderboardRx.Add(new LeaderboardRx { Id = userId });
                db.SaveChanges();
                return new LeaderboardRx { Id = userId };
            }
        }

        public static LeaderboardRx GetLeaderboard(Users user) { return GetLeaderboard(user.Id); }
    }
}