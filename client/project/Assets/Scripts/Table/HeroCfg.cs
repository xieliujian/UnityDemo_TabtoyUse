// Generated by github.com/davyxu/tabtoy
// Version: 2.9.0
// DO NOT EDIT!!
using System.Collections.Generic;

namespace gtmGame
{
	
	// Defined in table: Globals
	public enum ActorType
	{
		
		
		Leader = 0, // 唐僧
		
		
		Monkey = 1, // 孙悟空
		
		
		Pig = 2, // 猪八戒
		
		
		Hammer = 3, // 沙僧
	
	}
	
	

	// Defined in table: HeroCfg
	
	public partial class HeroCfg
	{
	
		public tabtoy.Logger TableLogger = new tabtoy.Logger();
	
		
		/// <summary> 
		/// Hero
		/// </summary>
		public List<HeroDefine> Hero = new List<HeroDefine>(); 
	
	
		#region Index code
	 	Dictionary<long, HeroDefine> _HeroByID = new Dictionary<long, HeroDefine>();
        public HeroDefine GetHeroByID(long ID, HeroDefine def = default(HeroDefine))
        {
            HeroDefine ret;
            if ( _HeroByID.TryGetValue( ID, out ret ) )
            {
                return ret;
            }
			
			if ( def == default(HeroDefine) )
			{
				TableLogger.ErrorLine("GetHeroByID failed, ID: {0}", ID);
			}

            return def;
        }
		
		public string GetBuildID(){
			return "d41d8cd98f00b204e9800998ecf8427e";
		}
	
		#endregion
		#region Deserialize code
		
		static tabtoy.DeserializeHandler<HeroCfg> _HeroCfgDeserializeHandler;
		static tabtoy.DeserializeHandler<HeroCfg> HeroCfgDeserializeHandler
		{
			get
			{
				if (_HeroCfgDeserializeHandler == null )
				{
					_HeroCfgDeserializeHandler = new tabtoy.DeserializeHandler<HeroCfg>(Deserialize);
				}

				return _HeroCfgDeserializeHandler;
			}
		}
		public static void Deserialize( HeroCfg ins, tabtoy.DataReader reader )
		{
			
 			int tag = -1;
            while ( -1 != (tag = reader.ReadTag()))
            {
                switch (tag)
                { 
                	case 0xa0000:
                	{
						ins.Hero.Add( reader.ReadStruct<HeroDefine>(HeroDefineDeserializeHandler) );
                	}
                	break; 
                }
             } 

			
			// Build Hero Index
			for( int i = 0;i< ins.Hero.Count;i++)
			{
				var element = ins.Hero[i];
				
				ins._HeroByID.Add(element.ID, element);
				
			}
			
		}
		static tabtoy.DeserializeHandler<Vec2> _Vec2DeserializeHandler;
		static tabtoy.DeserializeHandler<Vec2> Vec2DeserializeHandler
		{
			get
			{
				if (_Vec2DeserializeHandler == null )
				{
					_Vec2DeserializeHandler = new tabtoy.DeserializeHandler<Vec2>(Deserialize);
				}

				return _Vec2DeserializeHandler;
			}
		}
		public static void Deserialize( Vec2 ins, tabtoy.DataReader reader )
		{
			
 			int tag = -1;
            while ( -1 != (tag = reader.ReadTag()))
            {
                switch (tag)
                { 
                	case 0x10000:
                	{
						ins.X = reader.ReadInt32();
                	}
                	break; 
                	case 0x10001:
                	{
						ins.Y = reader.ReadInt32();
                	}
                	break; 
                }
             } 

			
		}
		static tabtoy.DeserializeHandler<HeroDefine> _HeroDefineDeserializeHandler;
		static tabtoy.DeserializeHandler<HeroDefine> HeroDefineDeserializeHandler
		{
			get
			{
				if (_HeroDefineDeserializeHandler == null )
				{
					_HeroDefineDeserializeHandler = new tabtoy.DeserializeHandler<HeroDefine>(Deserialize);
				}

				return _HeroDefineDeserializeHandler;
			}
		}
		public static void Deserialize( HeroDefine ins, tabtoy.DataReader reader )
		{
			
 			int tag = -1;
            while ( -1 != (tag = reader.ReadTag()))
            {
                switch (tag)
                { 
                	case 0x20000:
                	{
						ins.ID = reader.ReadInt64();
                	}
                	break; 
                	case 0x60001:
                	{
						ins.Name = reader.ReadString();
                	}
                	break; 
                	case 0x60002:
                	{
						ins.Modelpath = reader.ReadString();
                	}
                	break; 
                }
             } 

			
		}
		#endregion
	

	} 

	// Defined in table: Globals
	
	public partial class Vec2
	{
	
		
		
		public int X = 0; 
		
		
		public int Y = 0; 
	
	

	} 

	// Defined in table: Hero
	[System.Serializable]
	public partial class HeroDefine
	{
	
		
		/// <summary> 
		/// 唯一ID
		/// </summary>
		public long ID = 0; 
		
		/// <summary> 
		/// 名称
		/// </summary>
		public string Name = ""; 
		
		/// <summary> 
		/// 模型路径
		/// </summary>
		public string Modelpath = ""; 
	
	

	} 

}
