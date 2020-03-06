# test-nbitcoin-compatibility

This proves that the new and old Schnorr blinding signature implementations are compatible regarless of the message endianess.

There are two project:

* master.csproj: a project that uses the current NBitcoin master branch, and
* secp256k1.csproj: a project that uses the NBitcoin secp256k1 branch.

This two projects use the same source code. This code allows us to blind a harcoded message, sign it and verify it.


1. Clone the repository
2. Open **two** consoles/terminals in the `SchnorrBlindingSignature` folder
3. In terminal 1: `dotnet run --project master.csproj -- blind-verify` this will show you a blinded message.
4. Copy the blinded message into the clipboard
5. In terminal 2: `dotnet run --project secp256k1.csproj -- sign` 
6. Paste the blinded message previously saved in the clipboard into the terminal. This will show you the blinded signature.
7. Copy the blinded signature from the terminal 2 to the terminal 1
8. It will verify the blinded signature.
