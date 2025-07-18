﻿using Maple2.Model.Enum;
using Maple2.PacketLib.Tools;
using Maple2.Server.Core.Constants;
using Maple2.Server.Game.PacketHandlers.Field;
using Maple2.Server.Game.Session;

namespace Maple2.Server.Game.PacketHandlers;

public class SurvivalHandler : FieldPacketHandler {
    public override RecvOp OpCode => RecvOp.Survival;

    private enum Command : byte {
        Equip = 8,
    }

    public override void Handle(GameSession session, IByteReader packet) {
        var command = packet.Read<Command>();

        switch (command) {
            case Command.Equip:
                HandleEquip(session, packet);
                return;
        }
    }

    private static void HandleEquip(GameSession session, IByteReader packet) {
        var slot = packet.Read<MedalType>();
        int medalId = packet.ReadInt();

        session.Survival.Equip(slot, medalId);
    }
}
