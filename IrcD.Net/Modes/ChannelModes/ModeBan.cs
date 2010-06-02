﻿/*
 *  The ircd.net project is an IRC deamon implementation for the .NET Plattform
 *  It should run on both .NET and Mono
 * 
 *  Copyright (c) 2009-2010 Thomas Bruderer <apophis@apophis.ch>
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using IrcD.ServerReplies;

namespace IrcD.Modes.ChannelModes
{
    class ModeBan : ChannelMode, IParameterListA
    {
        public ModeBan()
            : base('b')
        {
        }


        private readonly List<string> banList = new List<string>();
        public List<string> Parameter
        {
            get { return banList; }
        }

        public void SendList(UserInfo info, ChannelInfo chan)
        {
            foreach (var ban in banList)
            {
                info.IrcDaemon.Replies.SendBanList(info, chan, ban);
            }
            info.IrcDaemon.Replies.SendEndOfBanList(info, chan);
        }

        public override bool HandleEvent(IrcCommandType ircCommand, ChannelInfo channel, UserInfo user, List<string> args)
        {
            return true;
        }
    }
}
