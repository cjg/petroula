using System;

namespace GradsLibrary
{
    public class Dimension
    {
        private string name;
        private bool varying;
        private double start;
        private double end;
        private Grads grads;

        public delegate void DimensionEventHandler(Dimension source);
        public event DimensionEventHandler DimensionChanged;

        public Dimension(string name, Grads grads)
        {
            this.grads = grads;
            this.name = name;
            CommandOutput co = grads.IssueCommand("q dims");
            if (co.ResultCode != 0)
                throw new Exception("Cannot query grads!");
            parse_output(co.OutputArray);
        }

        public void OnDimensionChanged(Dimension source)
        {
            CommandOutput co = grads.IssueCommand("q dims");
            if (co.ResultCode != 0)
                throw new Exception("Cannot query grads!");
            parse_output(co.OutputArray);
        }

        private void parse_output(string[] output)
        {
            foreach (string line in output)
            {
                string s = line.Replace("  ", "\t");
                while (s.Contains("  "))
                    s = s.Replace("  ", " ");
                while (s.Contains("\t\t"))
                    s = s.Replace("\t\t", "\t");
                s = s.Replace("\t ", "\t").Replace(" \t", "\t");
                string[] splitted = s.Split('\t');
                if (splitted.Length != 3)
                    continue;
                varying = splitted[0].Substring(splitted[0].LastIndexOf(' ') + 1).Equals("varying");
                if (splitted[1].StartsWith(name + " "))
                    s = splitted[1];
                else if (splitted[2].StartsWith(name + " "))
                    s = splitted[2];
                else continue;
                s = s.Substring(s.IndexOf('=') + 2);
                if (!varying)
                {
                    start = double.Parse(s);
                    end = start;
                }
                else
                {
                    start = double.Parse(s.Substring(0, s.IndexOf(' ')));
                    s = s.Substring(s.LastIndexOf(' ') + 1);
                    end = double.Parse(s);
                }
                return;
            }
            throw new Exception("Dimension " + name + " not found!");
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public bool Varying
        {
            get
            {
                return varying;
            }
        }

        public double Start
        {
            get { return start; }
            set
            {
                CommandOutput co = grads.IssueCommand("set " + name + " " + value + " " + End);
                if (co.ResultCode != 0)
                    throw new Exception("Cannot set " + name + " to " + value + " " + End);
                start = value;
                DimensionChanged(this);
            }
        }

        public double End
        {
            get { return end; }
            set
            {
                CommandOutput co = grads.IssueCommand("set " + name + " " + Start + " " + value);
                if (co.ResultCode != 0)
                    throw new Exception("Cannot set " + name + " to " + Start + " " + value);
                end = value;
                DimensionChanged(this);
            }
        }

        public double Value
        {
            get { return start; }
            set
            {
                CommandOutput co = grads.IssueCommand("set " + name + " " + value);
                if (co.ResultCode != 0)
                    throw new Exception("Cannot set " + name + " to " + value);
                start = value;
                end = value;
                if (DimensionChanged != null)
                    DimensionChanged(this);
            }
        }

        public override string ToString()
        {
            string s = "Dimension: " + name;
            if (varying)
                s += " varying from " + start + " to " + end;
            else
                s += " fixed at " + start;
            return s;
        }
    }
}
