using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ProtoBuf;

namespace HelloWorldApp.BusinessObjects
{
	/// <summary>
	/// This is an example from the http://www.sharpserializer.com 
	/// Please download the full source code with HelloWorld demo to see more details.
	/// </summary>
	[Serializable, DataContract, ProtoContract]
	public class RootContainer
	{
		[DataMember, ProtoMember(1)]
		public SByte SimpleSByte { get; set; }

		/// <summary>
		/// Int is of simple type and is converted to SimpleProperty
		/// </summary>
		[DataMember, ProtoMember(2)]
		public int SimpleInt { get; set; }

		/// <summary>
		/// 4 Byte Float
		/// </summary>
		[DataMember, ProtoMember(3)]
		public Single SimpleSingle { get; set; }

		/// <summary>
		/// Double is simple type too.
		/// </summary>
		[DataMember, ProtoMember(4)]
		public double SimpleDouble { get; set; }

		/// <summary>
		/// DateTime is also simple type
		/// </summary>
		[DataMember, ProtoMember(5)]
		public DateTime SimpleDateTime { get; set; }

		/// <summary>
		/// TimeSpan is simple type
		/// </summary>
		[DataMember, ProtoMember(6)]
		public TimeSpan SimpleTimeSpan { get; set; }

		/// <summary>
		/// Every enumeration is simple type
		/// </summary>
		[DataMember, ProtoMember(7)]
		public SimpleEnum SimpleEnum { get; set; }

		/// <summary>
		/// Enumeration with FlagsAttribute is SimpleType. 
		/// It is correct serialized if the result of the flag combination has unique int value,
		/// i.e. Flag1 = 2, Flag2 = 4, Flag3 = 8 ...
		/// </summary>
		[DataMember, ProtoMember(8)]
		public FlagEnum FlagsEnum { get; set; }

		/// <summary>
		/// Decimal is 16 bytes long
		/// </summary>
		[DataMember, ProtoMember(9)]
		public decimal SimpleDecimal { get; set; }

		/// <summary>
		/// String is always of simple type and will be serialized as SimpleProperty. 
		/// If the string is null, it will be serialized as NullProperty
		/// </summary>
		[DataMember, ProtoMember(10)]
		public string SimpleString { get; set; }

		/// <summary>
		/// Default will be string.Empty serialized.
		/// </summary>
		[DataMember, ProtoMember(11)]
		public string EmptyString { get; set; }

		/// <summary>
		/// Structures are handled as objects during serialization
		/// They are serialized as ComplexProperty
		/// </summary>
		[DataMember, ProtoMember(12)]
		public AdvancedStruct AdvancedStruct { get; set; }

		/// <summary>
		/// One dimensional array of simple type.
		/// It is serialized as SingleDimensionalArrayProperty
		/// </summary>
		[DataMember, ProtoMember(13)]
		public string[] SingleArray { get; set; }

		/// <summary>
		/// Multidimensional array of simple type.
		/// Is is serialized as MultiDimensionalArrayProperty
		/// </summary>
		[DataMember, ProtoMember(14)]
		public string[,] DoubleArray { get; set; }

		/// <summary>
		/// Single array of derived objects. 
		/// This is polymorphic collection - Items derive from the interface
		/// </summary>
		[DataMember, ProtoMember(15)]
		public IComplexObject[] PolymorphicSingleArray { get; set; }

		/// <summary>
		/// Generic list is serialized as a collection.
		/// It is serialized as CollectionProperty
		/// </summary>
		[DataMember, ProtoMember(16)]
		public IList<string> GenericList { get; set; }

		/// <summary>
		/// Generic Dictionary of simple types.
		/// Is is serialized as DictionaryProperty
		/// </summary>
		[DataMember, ProtoMember(17)]
		public IDictionary<int, string> GenericDictionary { get; set; }

		/// <summary>
		/// Generic dictionary where values are inherited from the value type
		/// </summary>
		[DataMember, ProtoMember(18)]
		public IDictionary<int, IComplexObject> GenericDictionaryOfPolymorphicValues { get; set; }

		/// <summary>
		/// Polymorphic property. Object instance derives from the property type
		/// Is serialized as ComplexProperty
		/// </summary>
		[DataMember, ProtoMember(19)]
		public IComplexObject ComplexObject { get; set; }

		/// <summary>
		/// Collection where item values are 
		/// derived from the collection item type
		/// </summary>
		[DataMember, ProtoMember(20)]
		public ComplexObjectPolymorphicCollection ComplexObjectCollection { get; set; }

		/// <summary>
		/// Dictionary where values are derived 
		/// from the prefedined dictionary value type
		/// </summary>
		[DataMember, ProtoMember(21)]
		public ComplexObjectPolymorphicDictionary ComplexObjectDictionary { get; set; }

		/// <summary>
		/// List items are derived from the generic attribute. 
		/// This is polymorphic attribute.
		/// </summary>
		[DataMember, ProtoMember(22)]
		public IList<IComplexObject> GenericListOfComplexObjects { get; set; }

		/// <summary>
		/// Generic object with polymorphic attribute.
		/// It is serialized as ComplexProperty
		/// </summary>
		[DataMember, ProtoMember(23)]
		public GenericObject<IComplexObject> GenericObjectOfComplexObject { get; set; }

		/// <summary>
		/// Multidimensional array of generic object with polymorphic attribute
		/// </summary>
		[DataMember, ProtoMember(24)]
		public GenericObject<IComplexObject>[,] MultiArrayOfGenericObjectWithPolymorphicArgument { get; set; }

		/// <summary>
		/// Array of objects where every item can be of other type
		/// It is serialized as SingleDimensionalArrayProperty
		/// </summary>
		[DataMember, ProtoMember(25)]
		public object[] SingleArrayOfObjects { get; set; }


		public static RootContainer[] CreateContainerArray(int itemCount)
		{
			var result = new List<RootContainer>();
			for (int i = 0; i < itemCount; i++)
			{
				result.Add(RootContainer.CreateFakeRoot());
			}
			return result.ToArray();
		}

		public static RootContainer CreateFakeRoot()
		{
			var root = new RootContainer();

			root.SimpleSByte = -33;
			root.SimpleInt = 42;
			root.SimpleSingle = -352;
			root.SimpleDouble = 42.42;
			root.SimpleDateTime = new DateTime(2004, 5, 5);
			root.SimpleTimeSpan = new TimeSpan(5, 4, 3);
			root.SimpleEnum = SimpleEnum.Three;
			root.FlagsEnum = FlagEnum.Alfa | FlagEnum.Beta;
			root.SimpleDecimal = Convert.ToDecimal(17.123);
			root.SimpleString = "sth";
			root.EmptyString = string.Empty;
			root.AdvancedStruct = new AdvancedStruct() { DateTime = new DateTime(2010, 4, 10), SimpleText = "nix" };

			root.SingleArray = new[] { "ala", "ma", null, "kota" };
			root.DoubleArray = new[,] { { "k1", "k2" }, { "b1", "b2" }, { "z1", "z2" } };

			root.PolymorphicSingleArray = new IComplexObject[] { new ComplexObject() { SimpleInt = 999 } };

			root.GenericList = new List<string> { "item1", "item2", "item3" };
			root.GenericDictionary = new Dictionary<int, string>();
			root.GenericDictionary.Add(5, null);
			root.GenericDictionary.Add(10, "ten");
			root.GenericDictionary.Add(20, "twenty");

			root.GenericDictionaryOfPolymorphicValues = new Dictionary<int, IComplexObject>();
			root.GenericDictionaryOfPolymorphicValues.Add(2012, new ComplexObject() { SimpleInt = 2012000 });

			root.ComplexObject = new ComplexObject { SimpleInt = 33 };
			root.ComplexObjectCollection = new ComplexObjectPolymorphicCollection { new ComplexObject { SimpleInt = 11 }, new ComplexObject { SimpleInt = 12 } };
			root.ComplexObjectDictionary = new ComplexObjectPolymorphicDictionary();
			root.ComplexObjectDictionary.Add(100, new ComplexObject { SimpleInt = 101 });
			root.ComplexObjectDictionary.Add(200, new ComplexObject { SimpleInt = 202 });
			root.ComplexObjectDictionary.Add(300, null);

			root.GenericListOfComplexObjects = new List<IComplexObject> { new ComplexObject { SimpleInt = 303 } };
			root.GenericObjectOfComplexObject = new GenericObject<IComplexObject>(new ComplexObject { SimpleInt = 12345 });

			root.MultiArrayOfGenericObjectWithPolymorphicArgument = new GenericObject<IComplexObject>[1, 1];
			root.MultiArrayOfGenericObjectWithPolymorphicArgument[0, 0] = new GenericObject<IComplexObject>() { Data = new ComplexObject() { SimpleInt = 1357 } };

			// it contains objects of different types and a nested array
			root.SingleArrayOfObjects = new object[] { 42, "nothing to say", false, BusinessObjects.SimpleEnum.Three, null, new object[] { 42, "nothing to say", false, BusinessObjects.SimpleEnum.Three, null } };

			return root;
		}
	}

	public enum SimpleEnum
	{
		One,
		Two,
		Three
	}

	[Flags]
	public enum FlagEnum
	{
		Alfa = 2,
		Beta = 4,
		Gamma = 8
	}
}