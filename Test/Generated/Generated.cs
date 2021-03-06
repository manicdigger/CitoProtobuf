﻿// Classes and structures being serialized

// Generated by ProtocolBuffer
// - a pure c# code generation implementation of protocol buffers
// Report bugs to: https://silentorbit.com/protobuf/

// DO NOT EDIT
// This file will be overwritten when CodeGenerator is run.
// To make custom modifications, edit the .proto file and add //:external before the message line
// then write the code and the changes in a separate file.
using System;
using System.Collections.Generic;

namespace Personal
{
    public partial class Person
    {
        public enum PhoneType
        {
            MOBILE = 0,
            HOME = 1,
            WORK = 2,
        }
        
        public string Name { get; set; }
        
        public int Id { get; set; }
        
        public string Email { get; set; }
        
        public List<Personal.Person.PhoneNumber> Phone { get; set; }
        
        // ProtocolBuffers wire field id
        public const int NameFieldID = 1;
        public const int IdFieldID = 2;
        public const int EmailFieldID = 3;
        public const int PhoneFieldID = 4;
        public partial class PhoneNumber
        {
            public string Number { get; set; }
            
            public Personal.Person.PhoneType Type { get; set; }
            
            // ProtocolBuffers wire field id
            public const int NumberFieldID = 1;
            public const int TypeFieldID = 2;
        }
        
    }
    
    public partial class AddressBook
    {
        public List<Personal.Person> List { get; set; }
        
        // ProtocolBuffers wire field id
        public const int ListFieldID = 1;
    }
    
}
namespace Local
{
    /// <summary>This is a demonstration of features only present in ProtoBuf Code Generator</summary>
    internal partial class LocalFeatures
    {
        /// <summary>Make class field of type TimeSpan, serialized to Ticks</summary>
        public TimeSpan Uptime { get; set; }
        
        /// <summary>Make class field of type DateTime, serialized to Ticks</summary>
        public DateTime DueDate { get; set; }
        
        //public double Amount { get; set; } // Implemented by user elsewhere
        /// <summary>Custom field access types. Default: public</summary>
        private string Denial { get; set; }
        
        protected string Secret { get; set; }
        
        internal string Internal { get; set; }
        
        public string PR { get; set; }
        
        /// <summary>Generate a c# readonly field</summary>
        public readonly Mine.MyMessageV1 TestingReadOnly = new Mine.MyMessageV1();
        
        /// <summary>When deserializing this one must be set to a class before</summary>
        public LocalFeatureTest.InterfaceTest MyInterface { get; set; }
        
        public LocalFeatureTest.StructTest MyStruct;
        
        public TestB.ExternalStruct MyExtStruct;
        
        public TestB.ExternalClass MyExtClass { get; set; }
        
        public LocalFeatureTest.TopEnum MyEnum { get; set; }
        
        // ProtocolBuffers wire field id
        public const int UptimeFieldID = 1;
        public const int DueDateFieldID = 2;
        public const int AmountFieldID = 3;
        public const int DenialFieldID = 4;
        public const int SecretFieldID = 5;
        public const int InternalFieldID = 6;
        public const int PRFieldID = 7;
        public const int TestingReadOnlyFieldID = 8;
        public const int MyInterfaceFieldID = 9;
        public const int MyStructFieldID = 10;
        public const int MyExtStructFieldID = 11;
        public const int MyExtClassFieldID = 12;
        public const int MyEnumFieldID = 13;
        // protected virtual void BeforeSerialize() {}
        // protected virtual void AfterDeserialize() {}
        
    }
    
}
namespace LocalFeatureTest
{
    /// <summary>Testing local struct serialization</summary>
    public partial interface InterfaceTest
    {
        // ProtocolBuffers wire field id
    }
    
    /// <summary>Testing local struct serialization</summary>
    public partial struct StructTest
    {
        // ProtocolBuffers wire field id
    }
    
}
namespace TestB
{
    // Written elsewhere
    // public struct ExternalStruct {}
    
    // Written elsewhere
    // public class ExternalClass {}
    
}
namespace Mine
{
    /// <summary>
    /// <para>This class is documented here:</para>
    /// <para>With multiple lines</para>
    /// </summary>
    public partial class MyMessageV1
    {
        /// <summary>This field is important to comment as we just did here</summary>
        public int FieldA { get; set; }
        
        // ProtocolBuffers wire field id
        public const int FieldAFieldID = 1;
        /// <summary>Values for unknown fields.</summary>
        public List<global::SilentOrbit.ProtocolBuffers.KeyValue> PreservedFields;
        
    }
    
}
namespace Yours
{
    public partial class MyMessageV2
    {
        public enum MyEnum
        {
            /// <summary>First test</summary>
            ETest1 = 0,
            /// <summary>Second test</summary>
            ETest2 = 3,
            ETest3 = 2,
        }
        
        public enum AliasedEnum
        {
            Nothing = 0,
            Zero = 0,
            Nada = 0,
            Some = 1,
            ALot = 2,
        }
        
        public int FieldA { get; set; }
        
        public double FieldB { get; set; }
        
        public float FieldC { get; set; }
        
        public int FieldD { get; set; }
        
        public long FieldE { get; set; }
        
        public uint FieldF { get; set; }
        
        public ulong FieldG { get; set; }
        
        public int FieldH { get; set; }
        
        public long FieldI { get; set; }
        
        public uint FieldJ { get; set; }
        
        public ulong FieldK { get; set; }
        
        public int FieldL { get; set; }
        
        public long FieldM { get; set; }
        
        public bool FieldN { get; set; }
        
        public string FieldO { get; set; }
        
        public byte[] FieldP { get; set; }
        
        public Yours.MyMessageV2.MyEnum FieldQ { get; set; }
        
        public Yours.MyMessageV2.MyEnum FieldR { get; set; }
        
        protected string Dummy { get; set; }
        
        public List<uint> FieldT { get; set; }
        
        public List<uint> FieldS { get; set; }
        
        public Theirs.TheirMessage FieldU { get; set; }
        
        public List<Theirs.TheirMessage> FieldV { get; set; }
        
        // ProtocolBuffers wire field id
        public const int FieldAFieldID = 1;
        public const int FieldBFieldID = 2;
        public const int FieldCFieldID = 3;
        public const int FieldDFieldID = 4;
        public const int FieldEFieldID = 5;
        public const int FieldFFieldID = 6;
        public const int FieldGFieldID = 7;
        public const int FieldHFieldID = 8;
        public const int FieldIFieldID = 9;
        public const int FieldJFieldID = 10;
        public const int FieldKFieldID = 11;
        public const int FieldLFieldID = 12;
        public const int FieldMFieldID = 13;
        public const int FieldNFieldID = 14;
        public const int FieldOFieldID = 15;
        public const int FieldPFieldID = 16;
        public const int FieldQFieldID = 17;
        public const int FieldRFieldID = 18;
        public const int DummyFieldID = 19;
        public const int FieldTFieldID = 20;
        public const int FieldSFieldID = 21;
        public const int FieldUFieldID = 22;
        public const int FieldVFieldID = 23;
    }
    
}
namespace Theirs
{
    public partial class TheirMessage
    {
        public int FieldA { get; set; }
        
        // ProtocolBuffers wire field id
        public const int FieldAFieldID = 1;
    }
    
}
namespace Proto.test
{
    /// <summary>Message without any low id(< 16) fields</summary>
    public partial class LongMessage
    {
        public int FieldX1 { get; set; }
        
        public int FieldX2 { get; set; }
        
        public int FieldX3 { get; set; }
        
        public int FieldX4 { get; set; }
        
        // ProtocolBuffers wire field id
        public const int FieldX1FieldID = 32;
        public const int FieldX2FieldID = 64;
        public const int FieldX3FieldID = 96;
        public const int FieldX4FieldID = 100;
    }
    
    /// <summary>Nested testing</summary>
    public partial class Data
    {
        public double Somefield { get; set; }
        
        // ProtocolBuffers wire field id
        public const int SomefieldFieldID = 1;
    }
    
    public partial class Container
    {
        public Proto.test.Container.Nested MyNestedMessage { get; set; }
        
        /// <summary>Name collision test</summary>
        public Proto.test.Container.Nested NestedField { get; set; }
        
        // ProtocolBuffers wire field id
        public const int MyNestedMessageFieldID = 1;
        public const int NestedFieldFieldID = 2;
        public partial class Nested
        {
            public Proto.test.Data NestedData { get; set; }
            
            // ProtocolBuffers wire field id
            public const int NestedDataFieldID = 1;
        }
        
    }
    
    public partial class MyMessage
    {
        public int Foo { get; set; }
        
        public string Bar { get; set; }
        
        // ProtocolBuffers wire field id
        public const int FooFieldID = 1;
        public const int BarFieldID = 2;
    }
    
}
namespace LocalFeatureTest
{
    public enum TopEnum
    {
        First = 1,
        Last = 1000000,
    }
    
    
}
namespace Proto.test
{
    public enum MyEnum
    {
        FOO = 1,
        BAR = 2,
    }
    
    
}
