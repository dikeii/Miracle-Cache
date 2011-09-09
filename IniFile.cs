using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace PacketMonitor
{
    public class IniFile
    {
        public string path;
        public IniFile(string INIPath)
        {
            path = INIPath;
            if (File.Exists(path))
            {
                Read();
            }
            else
            {
                Console.WriteLine("El Archivo Config.ini no existe.!!");
            }
        }
        public void Read()
        {
            #region IniSectionSelect
            string[] Lines = File.ReadAllLines(path);
            string Ssection = "";
            foreach (string Line in Lines)
            {
                if (Line.Length > 0)
                {
                    if (Line[0] == '[' && Line[Line.Length - 1] == ']')
                    {
                        Ssection = Line;
                        IniSectionStructure Section = new IniSectionStructure();
                        Section.SectionName = Ssection;
                        Section.Variables = new Dictionary<string, IniValueStructure>();
                        Sections.Add(Ssection, Section);
                    }
                    else
                    {
                        IniValueStructure IvS = new IniValueStructure();
                        IvS.Variable = Line.Split('=')[0];
                        IvS.Value = Line.Split('=')[1];
                        IniSectionStructure Section = null;
                        Sections.TryGetValue(Ssection, out Section);
                        if (Section != null)
                        {
                            if (!Section.Variables.ContainsKey(IvS.Variable))
                                Section.Variables.Add(IvS.Variable, IvS);
                        }
                    }
                }
            }
            #endregion
        }
        Dictionary<string, IniSectionStructure> Sections = new Dictionary<string, IniSectionStructure>();
        public void Close()
        {
            Sections.Clear();
        }

        class IniValueStructure
        {
            public string Variable;
            public string Value;
        }
        class IniSectionStructure
        {
            public Dictionary<string, IniValueStructure> Variables;
            public string SectionName;
        }
        #region Read
        public byte ReadByte(string Section, string Key)
        {
            string section = "[" + Section + "]";
            IniSectionStructure ISS = null;
            Sections.TryGetValue(section, out ISS);
            if (ISS != null)
            {
                IniValueStructure IVS = null;
                ISS.Variables.TryGetValue(Key, out IVS);
                if (IVS != null)
                    return byte.Parse(IVS.Value);
            }
            return 0;
        }
        public sbyte ReadSbyte(string Section, string Key)
        {
            string section = "[" + Section + "]";
            IniSectionStructure ISS = null;
            Sections.TryGetValue(section, out ISS);
            if (ISS != null)
            {
                IniValueStructure IVS = null;
                ISS.Variables.TryGetValue(Key, out IVS);
                if (IVS != null)
                    return sbyte.Parse(IVS.Value);
            }
            return 0;
        }
        public short ReadInt16(string Section, string Key)
        {
            string section = "[" + Section + "]";
            IniSectionStructure ISS = null;
            Sections.TryGetValue(section, out ISS);
            if (ISS != null)
            {
                IniValueStructure IVS = null;
                ISS.Variables.TryGetValue(Key, out IVS);
                if (IVS != null)
                    return short.Parse(IVS.Value);
            }
            return 0;
        }
        public short Readint(string Section, string Key)
        {
            string section = "[" + Section + "]";
            IniSectionStructure ISS = null;
            Sections.TryGetValue(section, out ISS);
            if (ISS != null)
            {
                IniValueStructure IVS = null;
                ISS.Variables.TryGetValue(Key, out IVS);
                if (IVS != null)
                    return short.Parse(IVS.Value);
            }
            return 0;
        }
        public int ReadInt32(string Section, string Key)
        {
            string section = "[" + Section + "]";
            IniSectionStructure ISS = null;
            Sections.TryGetValue(section, out ISS);
            if (ISS != null)
            {
                IniValueStructure IVS = null;
                ISS.Variables.TryGetValue(Key, out IVS);
                if (IVS != null)
                    return int.Parse(IVS.Value);
            }
            return 0;
        }
        public long ReadInt64(string Section, string Key)
        {
            string section = "[" + Section + "]";
            IniSectionStructure ISS = null;
            Sections.TryGetValue(section, out ISS);
            if (ISS != null)
            {
                IniValueStructure IVS = null;
                ISS.Variables.TryGetValue(Key, out IVS);
                if (IVS != null)
                    return long.Parse(IVS.Value);
            }
            return 0;
        }
        public ushort ReadUInt16(string Section, string Key)
        {
            string section = "[" + Section + "]";
            IniSectionStructure ISS = null;
            Sections.TryGetValue(section, out ISS);
            if (ISS != null)
            {
                IniValueStructure IVS = null;
                ISS.Variables.TryGetValue(Key, out IVS);
                if (IVS != null)
                    return ushort.Parse(IVS.Value);
            }
            return 0;
        }
        public uint ReadUInt32(string Section, string Key)
        {
            string section = "[" + Section + "]";
            IniSectionStructure ISS = null;
            Sections.TryGetValue(section, out ISS);
            if (ISS != null)
            {
                IniValueStructure IVS = null;
                ISS.Variables.TryGetValue(Key, out IVS);
                if (IVS != null)
                    return uint.Parse(IVS.Value);
            }
            return 0;
        }
        public ulong ReadUInt64(string Section, string Key)
        {
            string section = "[" + Section + "]";
            IniSectionStructure ISS = null;
            Sections.TryGetValue(section, out ISS);
            if (ISS != null)
            {
                IniValueStructure IVS = null;
                ISS.Variables.TryGetValue(Key, out IVS);
                if (IVS != null)
                    return ulong.Parse(IVS.Value);
            }
            return 0;
        }
        public double ReadDouble(string Section, string Key)
        {
            string section = "[" + Section + "]";
            IniSectionStructure ISS = null;
            Sections.TryGetValue(section, out ISS);
            if (ISS != null)
            {
                IniValueStructure IVS = null;
                ISS.Variables.TryGetValue(Key, out IVS);
                if (IVS != null)
                    return double.Parse(IVS.Value);
            }
            return 0;
        }
        public float ReadFloat(string Section, string Key)
        {
            string section = "[" + Section + "]";
            IniSectionStructure ISS = null;
            Sections.TryGetValue(section, out ISS);
            if (ISS != null)
            {
                IniValueStructure IVS = null;
                ISS.Variables.TryGetValue(Key, out IVS);
                if (IVS != null)
                    return float.Parse(IVS.Value);
            }
            return 0;
        }
        public string ReadString(string Section, string Key)
        {
            string section = "[" + Section + "]";
            IniSectionStructure ISS = null;
            Sections.TryGetValue(section, out ISS);
            if (ISS != null)
            {
                IniValueStructure IVS = null;
                ISS.Variables.TryGetValue(Key, out IVS);
                if (IVS != null)
                    return IVS.Value;
            }
            return "";
        }
        public bool ReadBoolean(string Section, string Key)
        {
            string section = "[" + Section + "]";
            IniSectionStructure ISS = null;
            Sections.TryGetValue(section, out ISS);
            if (ISS != null)
            {
                IniValueStructure IVS = null;
                ISS.Variables.TryGetValue(Key, out IVS);
                if (IVS != null)
                    return byte.Parse(IVS.Value) == 1 ? true : false; ;
            }
            return false;
        }
        #endregion
    }
}
