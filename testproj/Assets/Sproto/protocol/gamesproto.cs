// Generated by sprotodump. DO NOT EDIT!
// source: D:\unityclient\testproj\Assets\Sproto\protocol\/game.sproto

using System;
using Sproto;
using System.Collections.Generic;

namespace SprotoType { 
	public class chat {
	
		public class request : SprotoTypeBase {
			private static int max_field_count = 1;
			
			
			private string _msg; // tag 0
			public string msg {
				get { return _msg; }
				set { base.has_field.set_field (0, true); _msg = value; }
			}
			public bool HasMsg {
				get { return base.has_field.has_field (0); }
			}

			public request () : base(max_field_count) {}

			public request (byte[] buffer) : base(max_field_count, buffer) {
				this.decode ();
			}

			protected override void decode () {
				int tag = -1;
				while (-1 != (tag = base.deserialize.read_tag ())) {
					switch (tag) {
					case 0:
						this.msg = base.deserialize.read_string ();
						break;
					default:
						base.deserialize.read_unknow_data ();
						break;
					}
				}
			}

			public override int encode (SprotoStream stream) {
				base.serialize.open (stream);

				if (base.has_field.has_field (0)) {
					base.serialize.write_string (this.msg, 0);
				}

				return base.serialize.close ();
			}
		}


		public class response : SprotoTypeBase {
			private static int max_field_count = 2;
			
			
			private Int64 _error_code; // tag 0
			public Int64 error_code {
				get { return _error_code; }
				set { base.has_field.set_field (0, true); _error_code = value; }
			}
			public bool HasError_code {
				get { return base.has_field.has_field (0); }
			}

			private string _msg; // tag 1
			public string msg {
				get { return _msg; }
				set { base.has_field.set_field (1, true); _msg = value; }
			}
			public bool HasMsg {
				get { return base.has_field.has_field (1); }
			}

			public response () : base(max_field_count) {}

			public response (byte[] buffer) : base(max_field_count, buffer) {
				this.decode ();
			}

			protected override void decode () {
				int tag = -1;
				while (-1 != (tag = base.deserialize.read_tag ())) {
					switch (tag) {
					case 0:
						this.error_code = base.deserialize.read_integer ();
						break;
					case 1:
						this.msg = base.deserialize.read_string ();
						break;
					default:
						base.deserialize.read_unknow_data ();
						break;
					}
				}
			}

			public override int encode (SprotoStream stream) {
				base.serialize.open (stream);

				if (base.has_field.has_field (0)) {
					base.serialize.write_integer (this.error_code, 0);
				}

				if (base.has_field.has_field (1)) {
					base.serialize.write_string (this.msg, 1);
				}

				return base.serialize.close ();
			}
		}


	}


	public class chatInfo {
	
		public class request : SprotoTypeBase {
			private static int max_field_count = 2;
			
			
			private string _msg; // tag 0
			public string msg {
				get { return _msg; }
				set { base.has_field.set_field (0, true); _msg = value; }
			}
			public bool HasMsg {
				get { return base.has_field.has_field (0); }
			}

			private string _sender; // tag 1
			public string sender {
				get { return _sender; }
				set { base.has_field.set_field (1, true); _sender = value; }
			}
			public bool HasSender {
				get { return base.has_field.has_field (1); }
			}

			public request () : base(max_field_count) {}

			public request (byte[] buffer) : base(max_field_count, buffer) {
				this.decode ();
			}

			protected override void decode () {
				int tag = -1;
				while (-1 != (tag = base.deserialize.read_tag ())) {
					switch (tag) {
					case 0:
						this.msg = base.deserialize.read_string ();
						break;
					case 1:
						this.sender = base.deserialize.read_string ();
						break;
					default:
						base.deserialize.read_unknow_data ();
						break;
					}
				}
			}

			public override int encode (SprotoStream stream) {
				base.serialize.open (stream);

				if (base.has_field.has_field (0)) {
					base.serialize.write_string (this.msg, 0);
				}

				if (base.has_field.has_field (1)) {
					base.serialize.write_string (this.sender, 1);
				}

				return base.serialize.close ();
			}
		}


	}


	public class createuser {
	
		public class request : SprotoTypeBase {
			private static int max_field_count = 2;
			
			
			private Int64 _pos; // tag 0
			public Int64 pos {
				get { return _pos; }
				set { base.has_field.set_field (0, true); _pos = value; }
			}
			public bool HasPos {
				get { return base.has_field.has_field (0); }
			}

			private string _name; // tag 1
			public string name {
				get { return _name; }
				set { base.has_field.set_field (1, true); _name = value; }
			}
			public bool HasName {
				get { return base.has_field.has_field (1); }
			}

			public request () : base(max_field_count) {}

			public request (byte[] buffer) : base(max_field_count, buffer) {
				this.decode ();
			}

			protected override void decode () {
				int tag = -1;
				while (-1 != (tag = base.deserialize.read_tag ())) {
					switch (tag) {
					case 0:
						this.pos = base.deserialize.read_integer ();
						break;
					case 1:
						this.name = base.deserialize.read_string ();
						break;
					default:
						base.deserialize.read_unknow_data ();
						break;
					}
				}
			}

			public override int encode (SprotoStream stream) {
				base.serialize.open (stream);

				if (base.has_field.has_field (0)) {
					base.serialize.write_integer (this.pos, 0);
				}

				if (base.has_field.has_field (1)) {
					base.serialize.write_string (this.name, 1);
				}

				return base.serialize.close ();
			}
		}


	}


	public class joinroom {
	
		public class request : SprotoTypeBase {
			private static int max_field_count = 2;
			
			
			private Int64 _pos; // tag 0
			public Int64 pos {
				get { return _pos; }
				set { base.has_field.set_field (0, true); _pos = value; }
			}
			public bool HasPos {
				get { return base.has_field.has_field (0); }
			}

			private string _name; // tag 1
			public string name {
				get { return _name; }
				set { base.has_field.set_field (1, true); _name = value; }
			}
			public bool HasName {
				get { return base.has_field.has_field (1); }
			}

			public request () : base(max_field_count) {}

			public request (byte[] buffer) : base(max_field_count, buffer) {
				this.decode ();
			}

			protected override void decode () {
				int tag = -1;
				while (-1 != (tag = base.deserialize.read_tag ())) {
					switch (tag) {
					case 0:
						this.pos = base.deserialize.read_integer ();
						break;
					case 1:
						this.name = base.deserialize.read_string ();
						break;
					default:
						base.deserialize.read_unknow_data ();
						break;
					}
				}
			}

			public override int encode (SprotoStream stream) {
				base.serialize.open (stream);

				if (base.has_field.has_field (0)) {
					base.serialize.write_integer (this.pos, 0);
				}

				if (base.has_field.has_field (1)) {
					base.serialize.write_string (this.name, 1);
				}

				return base.serialize.close ();
			}
		}


	}


	public class package : SprotoTypeBase {
		private static int max_field_count = 2;
		
		
		private Int64 _type; // tag 0
		public Int64 type {
			get { return _type; }
			set { base.has_field.set_field (0, true); _type = value; }
		}
		public bool HasType {
			get { return base.has_field.has_field (0); }
		}

		private Int64 _session; // tag 1
		public Int64 session {
			get { return _session; }
			set { base.has_field.set_field (1, true); _session = value; }
		}
		public bool HasSession {
			get { return base.has_field.has_field (1); }
		}

		public package () : base(max_field_count) {}

		public package (byte[] buffer) : base(max_field_count, buffer) {
			this.decode ();
		}

		protected override void decode () {
			int tag = -1;
			while (-1 != (tag = base.deserialize.read_tag ())) {
				switch (tag) {
				case 0:
					this.type = base.deserialize.read_integer ();
					break;
				case 1:
					this.session = base.deserialize.read_integer ();
					break;
				default:
					base.deserialize.read_unknow_data ();
					break;
				}
			}
		}

		public override int encode (SprotoStream stream) {
			base.serialize.open (stream);

			if (base.has_field.has_field (0)) {
				base.serialize.write_integer (this.type, 0);
			}

			if (base.has_field.has_field (1)) {
				base.serialize.write_integer (this.session, 1);
			}

			return base.serialize.close ();
		}
	}


	public class playermove {
	
		public class request : SprotoTypeBase {
			private static int max_field_count = 2;
			
			
			private string _name; // tag 0
			public string name {
				get { return _name; }
				set { base.has_field.set_field (0, true); _name = value; }
			}
			public bool HasName {
				get { return base.has_field.has_field (0); }
			}

			private string _move_msg; // tag 1
			public string move_msg {
				get { return _move_msg; }
				set { base.has_field.set_field (1, true); _move_msg = value; }
			}
			public bool HasMove_msg {
				get { return base.has_field.has_field (1); }
			}

			public request () : base(max_field_count) {}

			public request (byte[] buffer) : base(max_field_count, buffer) {
				this.decode ();
			}

			protected override void decode () {
				int tag = -1;
				while (-1 != (tag = base.deserialize.read_tag ())) {
					switch (tag) {
					case 0:
						this.name = base.deserialize.read_string ();
						break;
					case 1:
						this.move_msg = base.deserialize.read_string ();
						break;
					default:
						base.deserialize.read_unknow_data ();
						break;
					}
				}
			}

			public override int encode (SprotoStream stream) {
				base.serialize.open (stream);

				if (base.has_field.has_field (0)) {
					base.serialize.write_string (this.name, 0);
				}

				if (base.has_field.has_field (1)) {
					base.serialize.write_string (this.move_msg, 1);
				}

				return base.serialize.close ();
			}
		}


	}


	public class sayhello {
	
		public class request : SprotoTypeBase {
			private static int max_field_count = 1;
			
			
			private string _what; // tag 0
			public string what {
				get { return _what; }
				set { base.has_field.set_field (0, true); _what = value; }
			}
			public bool HasWhat {
				get { return base.has_field.has_field (0); }
			}

			public request () : base(max_field_count) {}

			public request (byte[] buffer) : base(max_field_count, buffer) {
				this.decode ();
			}

			protected override void decode () {
				int tag = -1;
				while (-1 != (tag = base.deserialize.read_tag ())) {
					switch (tag) {
					case 0:
						this.what = base.deserialize.read_string ();
						break;
					default:
						base.deserialize.read_unknow_data ();
						break;
					}
				}
			}

			public override int encode (SprotoStream stream) {
				base.serialize.open (stream);

				if (base.has_field.has_field (0)) {
					base.serialize.write_string (this.what, 0);
				}

				return base.serialize.close ();
			}
		}


		public class response : SprotoTypeBase {
			private static int max_field_count = 2;
			
			
			private Int64 _error_code; // tag 0
			public Int64 error_code {
				get { return _error_code; }
				set { base.has_field.set_field (0, true); _error_code = value; }
			}
			public bool HasError_code {
				get { return base.has_field.has_field (0); }
			}

			private string _msg; // tag 1
			public string msg {
				get { return _msg; }
				set { base.has_field.set_field (1, true); _msg = value; }
			}
			public bool HasMsg {
				get { return base.has_field.has_field (1); }
			}

			public response () : base(max_field_count) {}

			public response (byte[] buffer) : base(max_field_count, buffer) {
				this.decode ();
			}

			protected override void decode () {
				int tag = -1;
				while (-1 != (tag = base.deserialize.read_tag ())) {
					switch (tag) {
					case 0:
						this.error_code = base.deserialize.read_integer ();
						break;
					case 1:
						this.msg = base.deserialize.read_string ();
						break;
					default:
						base.deserialize.read_unknow_data ();
						break;
					}
				}
			}

			public override int encode (SprotoStream stream) {
				base.serialize.open (stream);

				if (base.has_field.has_field (0)) {
					base.serialize.write_integer (this.error_code, 0);
				}

				if (base.has_field.has_field (1)) {
					base.serialize.write_string (this.msg, 1);
				}

				return base.serialize.close ();
			}
		}


	}


}


public class Protocol : ProtocolBase {
	public static  Protocol Instance = new Protocol();
	private Protocol() {
		Protocol.SetProtocol<chat> (chat.Tag);
		Protocol.SetRequest<SprotoType.chat.request> (chat.Tag);
		Protocol.SetResponse<SprotoType.chat.response> (chat.Tag);

		Protocol.SetProtocol<chatInfo> (chatInfo.Tag);
		Protocol.SetRequest<SprotoType.chatInfo.request> (chatInfo.Tag);

		Protocol.SetProtocol<createuser> (createuser.Tag);
		Protocol.SetRequest<SprotoType.createuser.request> (createuser.Tag);

		Protocol.SetProtocol<heartbeat> (heartbeat.Tag);

		Protocol.SetProtocol<joinroom> (joinroom.Tag);
		Protocol.SetRequest<SprotoType.joinroom.request> (joinroom.Tag);

		Protocol.SetProtocol<playermove> (playermove.Tag);
		Protocol.SetRequest<SprotoType.playermove.request> (playermove.Tag);

		Protocol.SetProtocol<sayhello> (sayhello.Tag);
		Protocol.SetRequest<SprotoType.sayhello.request> (sayhello.Tag);
		Protocol.SetResponse<SprotoType.sayhello.response> (sayhello.Tag);

	}

	public class chat {
		public const int Tag = 2;
	}

	public class chatInfo {
		public const int Tag = 4;
	}

	public class createuser {
		public const int Tag = 6;
	}

	public class heartbeat {
		public const int Tag = 3;
	}

	public class joinroom {
		public const int Tag = 5;
	}

	public class playermove {
		public const int Tag = 7;
	}

	public class sayhello {
		public const int Tag = 1;
	}

}