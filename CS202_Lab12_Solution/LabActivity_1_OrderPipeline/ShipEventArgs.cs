using System;

namespace LabActivity_1_OrderPipeline
{
    public class ShipEventArgs : EventArgs
    {
        public string Product { get; }
        public bool IsExpress { get; }

        public ShipEventArgs(string product, bool isExpress)
        {
            Product = product;
            IsExpress = isExpress;
        }
    }
}
