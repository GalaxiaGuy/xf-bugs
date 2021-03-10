using ObjCRuntime;

namespace AkamaiBMPiOS310
{
	[Native]
	public enum CYFLogLevel : ulong
	{
		Info = 4,
		Warn,
		Error,
		None = 15
	}
}