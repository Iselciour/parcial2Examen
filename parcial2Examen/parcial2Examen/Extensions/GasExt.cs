using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace parcial2Examen.Extensions
{
	public static class GasExt
	{
		public static async void SafeFireAndForget(this Task gas,
												   bool returnToCallingContext,
												   Action<Exception> onException = null)
		{
			try
			{
				await gas.ConfigureAwait(returnToCallingContext);
			}
			catch (Exception ex) when (onException != null)
			{
				onException(ex);
			}
		}
	}
}