﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class C2S_ClientReady : GamePacket // 0x52
    {
        public override GamePacketID ID => GamePacketID.C2S_ClientReady;

        public uint RandomInt { get; set; }

        public TipConfig TipConfig { get; set; } = new TipConfig();


        protected override void ReadBody(ByteReader reader)
        {
            this.RandomInt = reader.ReadUInt32();
            this.TipConfig = reader.ReadTipConfig();
            reader.ReadPad(4);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(RandomInt);
            writer.WriteTipConfig(TipConfig);
            writer.WritePad(4);
        }
    }
}
