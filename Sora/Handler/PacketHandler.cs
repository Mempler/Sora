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

using Shared.Enums;
using Shared.Handlers;
using Shared.Helpers;
using Sora.Objects;
using Sora.Packets.Client;
using SendIrcMessage = Sora.Packets.Client.SendIrcMessage;

namespace Sora.Handler
{
    internal class PacketHandler
    {
        [Handler(HandlerTypes.PacketHandler)]
        public void HandlePackets(Presence pr, PacketId packetId, MStreamReader data)
        {
            switch (packetId)
            {
                case PacketId.ClientSendUserStatus:
                    Handlers.ExecuteHandler(HandlerTypes.ClientSendUserStatus, pr,
                                            data.ReadPacket<SendUserStatus>().Status);
                    break;
                case PacketId.ClientPong:
                    Handlers.ExecuteHandler(HandlerTypes.ClientPong, pr);
                    break;
                case PacketId.ClientRequestStatusUpdate:
                    Handlers.ExecuteHandler(HandlerTypes.ClientRequestStatusUpdate, pr);
                    break;
                case PacketId.ClientUserStatsRequest:
                    Handlers.ExecuteHandler(HandlerTypes.ClientUserStatsRequest, pr,
                                            data.ReadPacket<UserStatsRequest>().Userids);
                    break;
                case PacketId.ClientChannelJoin:
                    Handlers.ExecuteHandler(HandlerTypes.ClientChannelJoin, pr,
                                            data.ReadPacket<ChannelJoin>().ChannelName);
                    break;
                case PacketId.ClientChannelLeave:
                    Handlers.ExecuteHandler(HandlerTypes.ClientChannelLeave, pr,
                                            data.ReadPacket<ChannelLeave>().ChannelName);
                    break;
                case PacketId.ClientSendIrcMessagePrivate:
                case PacketId.ClientSendIrcMessage:
                    SendIrcMessage msg = data.ReadPacket<SendIrcMessage>();
                    if (msg.Msg.ChannelTarget.StartsWith("#"))
                        Handlers.ExecuteHandler(HandlerTypes.ClientSendIrcMessage, pr, msg.Msg);
                    else
                        Handlers.ExecuteHandler(HandlerTypes.ClientSendIrcMessagePrivate, pr, msg.Msg);
                    break;
                case PacketId.ClientExit:
                    Handlers.ExecuteHandler(HandlerTypes.ClientExit, pr,
                                            data.ReadPacket<Exit>().ErrorState);
                    break;
                case PacketId.ClientFriendAdd:
                    Handlers.ExecuteHandler(HandlerTypes.ClientFriendAdd, pr,
                                            data.ReadPacket<FriendAdd>().FriendId);
                    break;
                case PacketId.ClientFriendRemove:
                    Handlers.ExecuteHandler(HandlerTypes.ClientFriendRemove, pr,
                                            data.ReadPacket<FriendRemove>().FriendId);
                    break;
                case PacketId.ClientStartSpectating:
                    Handlers.ExecuteHandler(HandlerTypes.ClientStartSpectating, pr,
                                            data.ReadPacket<StartSpectating>().ToSpectateId);
                    break;
                case PacketId.ClientStopSpectating:
                    Handlers.ExecuteHandler(HandlerTypes.ClientStopSpectating, pr);
                    break;
                case PacketId.ClientCantSpectate:
                    Handlers.ExecuteHandler(HandlerTypes.ClientCantSpectate, pr);
                    break;
                case PacketId.ClientSpectateFrames:
                    Handlers.ExecuteHandler(HandlerTypes.ClientSpectateFrames, pr,
                                            data.ReadPacket<SpectatorFrames>().Frames);
                    break;
                case PacketId.ClientReceiveUpdates:
                    Handlers.ExecuteHandler(HandlerTypes.ClientReceiveUpdates, pr,
                                            data.ReadPacket<Packets.Client.ReceiveUpdates>().UserId);
                    break;
                case PacketId.ClientLobbyJoin:
                    Handlers.ExecuteHandler(HandlerTypes.ClientLobbyJoin, pr);
                    break;
                case PacketId.ClientLobbyPart:
                    Handlers.ExecuteHandler(HandlerTypes.ClientLobbyPart, pr);
                    break;
                case PacketId.ClientMatchCreate:
                    Handlers.ExecuteHandler(HandlerTypes.ClientMatchCreate, pr,
                                            data.ReadPacket<MatchCreate>().Room);
                    break;
                default:
                    Logger.L.Debug($"PacketId: {packetId}");
                    break;
            }
        }
    }
}