#Protocol Buffers Ć Code Generator

Parses a .proto file and generates serializers for Java, C#, JavaScript, ActionScript, D, Perl and PHP using [Cito Ć translator](http://cito.sourceforge.net/).

It's based on https://silentorbit.com/protobuf/.

# Status

It seems to be working. It's correctly serializing basic messages with int32, string, bytes, repeated, and enums.

But it's not fully tested.

* When targetting C, it leaks memory because "delete" is not used.
* Messages can't be nested.
* ProtoPlatform.StringToBytes and ProtoPlatform.BytesToString in ProtocolParser.cs only support C# and Java. Need to add more languages.


# Licence, Apache License version 2.0

All source code and generated code is licensed under the Apache License Version 2.0.
