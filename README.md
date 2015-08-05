# nefarious-octo-spork
minimal-ish sample of how to use bindingRedirect

0. Temporarily rename driver.exe.config.
1. Use "sn -k keyfile.snk" to generate a key pair.
2. Compile ext.cs with "csc /t:library ext.cs".
3. Compile int.cs with "csc /t:library int.cs /r:ext.dll".
4. Compile it with "csc driver.cs /r:int.dll"; observe that ext.dll wasn't mentioned on that command line.
5. Run driver.exe; you should get output something like this:
"Asked for version, got [External.ext.thing(): [ext, Version=1.0.0.1, Culture=neutral, PublicKeyToken=ebdf360c9c4270fe]]", although the public key token may differ.
6. Update ext.cs, changing the version to 1.0.1.5, and recompile it.
7. Run driver.ex, you'll get an error like this: "Unhandled Exception: System.IO.FileLoadException: Could not load file or assembly 'ext, Version=1.0.0.1, Culture=neutral, PublicKeyToken=ebdf360c9c4270fe' or one of its dependencies. The located assembly's manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)
   at Intermediate.Int.GetExt()
   at driver.Main(String[] args)".
8. Rename driver.exe.config from whatever you had changed the name to.  Make sure the public key token matches the one from your version of ext.dll if it's different from above.  Output is now "Asked for version, got [External.ext.thing(): [ext, Version=1.0.1.5, Culture=neutral, PublicKeyToken=ebdf360c9c4270fe]]".
9. Profit!

