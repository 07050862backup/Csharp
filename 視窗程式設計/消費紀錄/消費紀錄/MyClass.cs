using System;
using System.Collections.Generic;
using System.Text;

namespace 消費紀錄
{
    public struct ITEM
    {
        public string name;
        public float unitPrice;
        public uint number;

        public ITEM(string name, float unitPrice, uint number)
        {
            this.name = name;
            this.unitPrice = unitPrice;
            this.number = number;
        }
    }
}
