using System;

namespace AbstractVSInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }



    public abstract class Mobile
    {
        public void Call()
        {
            Console.WriteLine("Calling...");
        }

        public void SMS()
        {
            Console.WriteLine("SMS");
        }

        public abstract string getColor();
        public abstract string getModel();
    }


    public class IPhone5 : Mobile
    {
        public override string getColor()
        {
            throw new NotImplementedException();
        }

        public override string getModel()
        {
            throw new NotImplementedException();
        }
    }


    ///Iphone 7 has new feature of firgerprint , if we add in abstract class it will be commonly
    ///shared which is not right, i.e. iphone5 doesnt have fingerprint.
    ///

    public interface IFingerPrint
    {
        void FingerPrintUnock();
    }

    public class IPhone7 : Mobile,IFingerPrint
    {
        public void FingerPrintUnock()
        {
            throw new NotImplementedException();
        }

        public override string getColor()
        {
            throw new NotImplementedException();
        }

        public override string getModel()
        {
            throw new NotImplementedException();
        }
    }
}
