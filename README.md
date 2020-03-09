# test-nbitcoin-compatibility

This proves that the new and old Schnorr blinding signature implementations are compatible regarless of the message endianess.

There are two project:

* old.csproj: uses NBitcoin before the secp256k1 branch was merged
* new.csproj: uses NBitcoin with secp256k1 merged.

This two projects use the same source code. This code allows us to blind a harcoded message, sign it and verify it.


1. Clone the repository
2. Open a console/terminal (terminal 1)
3. `dotnet build test-nbitcoin-compatibility.sln` 
4. `./build/old/old blind-verify` this will show you a blinded message.
5. Copy the blinded message into the clipboard
6. Open a new terminal (terminal 2) and type: `./build/new/new sign` 
7. Paste the blinded message previously saved in the clipboard into the terminal. This will show you the blinded signature.
8. Copy the blinded signature from the terminal 2 to the terminal 1
9. It will verify the blinded signature.
