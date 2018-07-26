using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluacionG5.COMMON
{
    public class Item
    {
        private string _value;
        private string _text;

        public Item() { }

        public Item(string text, string value)
        {
            _text = text;
            _value = value;
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}
