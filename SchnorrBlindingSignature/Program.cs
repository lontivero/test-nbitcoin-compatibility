using System;
using NBitcoin;
using NBitcoin.Crypto;
using NBitcoin.DataEncoders;

namespace SchnorrBlindingSignature
{
    class Program
    {
        static void Main(string[] args)
        {
            var requester = new SchnorrBlinding.Requester();
            var r = new Key(Encoders.Hex.DecodeData("31E151628AED2A6ABF7155809CF4F3C762E7160F38B4DA56B784D9045190CFA0"));
            var key = new Key(Encoders.Hex.DecodeData("B7E151628AED2A6ABF7158809CF4F3C762E7160F38B4DA56A784D9045190CFEF"));
            var message = new uint256(Encoders.Hex.DecodeData("243F6A8885A308D313198A2E03707344A4093822299F31D0082EFA98EC4E6C89"));

            switch (args[0])
            {
                case "blind-verify":
                    var blindedMessage = requester.BlindMessage(message, r.PubKey, key.PubKey);

                    Console.WriteLine(blindedMessage);

                    var blindedSignatureInput = Console.ReadLine();
                    var blindedSignature2 = uint256.Parse(blindedSignatureInput);
                    var unblindedSignature = requester.UnblindSignature(blindedSignature2);
                    var success = SchnorrBlinding.VerifySignature(message, unblindedSignature, key.PubKey);
                    Console.WriteLine(success);
                    return;
                case "sign":
                    var signer = new SchnorrBlinding.Signer(key, r);
                    var blindedMessageInput = Console.ReadLine();
                    var blindedMessage2 = uint256.Parse(blindedMessageInput);
                    var blindSignature = signer.Sign(blindedMessage2);
                    Console.WriteLine(blindSignature);
                    return; 
            }
        }
    }
}
